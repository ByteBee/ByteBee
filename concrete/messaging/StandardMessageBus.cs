using System;
using System.Collections.Generic;
using System.Linq;
using ByteBee.Framework.Messaging.Contract;
using ByteBee.Framework.Messaging.Contract.Exceptions;
using ByteBee.Framework.Messaging.Contract.DataClasses;

namespace ByteBee.Framework.Messaging.Impl
{
    public sealed class StandardMessageBus : IMessageBus
    {
        private readonly Dictionary<Type, IList<MessageBusActor>> _actors =
            new Dictionary<Type, IList<MessageBusActor>>();

        public int ActorCount => _actors.SelectMany(s => s.Value).Count();

        public void Register<TMessage>(Action<TMessage> handler) where TMessage : IMessage
        {
            Register(handler, message => true);
        }

        public void Register<TMessage>(Action<TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage
        {
            ThrowIfHandlerIsNull(handler);
            ThrowIfFilterIsNull(filter);

            Type sensorType = typeof(TMessage);
            var actor = new MessageBusActor
            {
                Handler = handler,
                Filter = filter
            };

            RegisterMessageType(sensorType);
            ThrowIfActorIsAlreadyDefined(sensorType, actor);
            RegisterActor(sensorType, actor);
        }

        private void ThrowIfHandlerIsNull<TMessage>(Action<TMessage> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
        }

        private void ThrowIfFilterIsNull<TMessage>(Func<TMessage, bool> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
        }

        private void RegisterMessageType(Type sensorType)
        {
            bool hasActorsForGivenSensor = _actors.ContainsKey(sensorType);
            if (hasActorsForGivenSensor == false)
            {
                _actors.Add(sensorType, new List<MessageBusActor>());
            }
        }

        private void ThrowIfActorIsAlreadyDefined(Type sensorType, MessageBusActor actor)
        {
            bool actorIsAlreadyDefined = _actors[sensorType].Any(s => s.Handler == actor.Handler);
            if (actorIsAlreadyDefined)
            {
                throw new DuplicatedActorException($"Current actor is already registered for the message {sensorType.FullName}");
            }
        }

        private void RegisterActor(Type sensorType, MessageBusActor actor)
        {
            _actors[sensorType].Add(actor);
        }

        public void Publish<TMessage>() where TMessage : IMessage
        {
            Publish<TMessage>(new object[0]);
        }

        public void Publish<TMessage>(object[] constructorArgs) where TMessage : IMessage
        {
            var message = (TMessage)Activator.CreateInstance(typeof(TMessage), args: constructorArgs);
            Publish(message);
        }

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            Type sensorType = message.GetType();

            bool hasActorsForGivenSensor = _actors.ContainsKey(sensorType);
            if (hasActorsForGivenSensor == false)
            {
                return;
            }

            ActivateAllActorsForThisSensor(sensorType, message);
        }

        public event Action<MessageBusErrorEventArgs> HandlerThrowsException;
        public event Action<MessageBusErrorEventArgs> FilterThrowsException;

        private void ActivateAllActorsForThisSensor<TMessage>(Type sensorType, TMessage message) where TMessage : IMessage
        {
            IList<MessageBusActor> actorsForType = _actors[sensorType];
            foreach (MessageBusActor actor in actorsForType)
            {
                bool doesFilterMatch = DoesActorFilterMatch(actor, message);
                if (doesFilterMatch)
                {
                    ExecuteActorsLogic(actor, message);
                }
            }
        }

        private bool DoesActorFilterMatch<TMessage>(MessageBusActor actor, TMessage message) where TMessage : IMessage
        {
            try
            {
                return (bool)actor.Filter.DynamicInvoke(message);
            }
            catch (Exception ex)
            {
                var eventArgs = new MessageBusErrorEventArgs(message, ex);
                FilterThrowsException?.Invoke(eventArgs);
                return false;
            }
        }

        private void ExecuteActorsLogic<TMessage>(MessageBusActor actor, TMessage message) where TMessage : IMessage
        {
            try
            {
                actor.Handler.DynamicInvoke(message);
            }
            catch (Exception ex)
            {
                var eventArgs = new MessageBusErrorEventArgs(message, ex);
                HandlerThrowsException?.Invoke(eventArgs);
            }
        }
    }
}