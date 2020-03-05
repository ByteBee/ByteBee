using ByteBee.Framework.Messaging.Abstractions;
using ByteBee.Framework.Messaging.Abstractions.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ByteBee.Framework.Messaging
{
    public sealed class StandardMessageBus : IMessageBus
    {
        private readonly Dictionary<Type, IList<MessageBusActor>> _actors =
            new Dictionary<Type, IList<MessageBusActor>>();

        private Func<Type, object> _resolverCallback;

        public int ActorCount => _actors.SelectMany(s => s.Value).Count();

        public bool BreakOnException { get; set; }

        public void Register<TMessage>(Action<TMessage> handler) where TMessage : IMessage
        {
            Register(handler, message => true);
        }

        public void Register<TMessage>(Action<TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage
        {
            Throw.IfHandlerIsNull(handler);
            Throw.IfFilterIsNull(filter);

            Type sensorType = typeof(TMessage);
            var actor = new MessageBusActor
            {
                Handler = handler,
                Filter = filter,
            };

            RegisterMessageType(sensorType);
            ThrowIfActorIsAlreadyDefined(sensorType, actor);
            RegisterActor(sensorType, actor);
        }

        public void SetResolverCallback(Func<Type, object> resolverCallback)
        {
            Throw.IfResolverCallbackIsNull(resolverCallback);

            _resolverCallback = resolverCallback;
        }

        public void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler) where TMessage : IMessage
        {
            Register(handler, message => true);
        }

        public void Register<TResolver, TMessage>(Action<TResolver, TMessage> handler, Func<TMessage, bool> filter) where TMessage : IMessage
        {
            Throw.IfHandlerIsNull(handler);
            Throw.IfFilterIsNull(filter);

            Type sensorType = typeof(TMessage);
            var actor = new MessageBusActor
            {
                Handler = handler,
                Filter = filter,
                ResolverType = typeof(TResolver)
            };

            RegisterMessageType(sensorType);
            ThrowIfActorIsAlreadyDefined(sensorType, actor);
            RegisterActor(sensorType, actor);
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
                Throw.DuplicatedActorException($"Current actor is already registered for the message {sensorType.FullName}");
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

        public void Publish<TMessage>(params object[] constructorArgs) where TMessage : IMessage
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

            ThrowIfResolverIsNeededButNoDefined(sensorType);
            ActivateAllActorsForThisSensor(sensorType, message);
        }

        public event Action<MessageBusErrorEventArgs> HandlerThrowsException;
        public event Action<MessageBusErrorEventArgs> FilterThrowsException;

        private void ThrowIfResolverIsNeededButNoDefined(Type sensorType)
        {
            bool isResolverCallbackNeeded = _actors[sensorType].Any(x => x.ResolverType != null);
            bool isResolverCallbackMissing = _resolverCallback == null;
            if (isResolverCallbackNeeded && isResolverCallbackMissing)
            {
                Throw.MissingResolverCallbackException();
            }
        }

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
                bool isOnyTheFlySubscription = actor.ResolverType != null;
                if (isOnyTheFlySubscription)
                {
                    object resolver = _resolverCallback(actor.ResolverType);
                    actor.Handler.DynamicInvoke(resolver, message);
                }
                else
                {
                    actor.Handler.DynamicInvoke(message);    
                }
            }
            catch (TargetInvocationException tie)
            {
                var eventArgs = new MessageBusErrorEventArgs(message, tie.InnerException);
                HandlerThrowsException?.Invoke(eventArgs);

                if (BreakOnException)
                {
                    throw tie.InnerException;
                }
            }
            catch (Exception ex)
            {
                var eventArgs = new MessageBusErrorEventArgs(message, ex);
                HandlerThrowsException?.Invoke(eventArgs);

                if (BreakOnException)
                {
                    throw;
                }
            }
        }
    }
}