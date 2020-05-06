using ByteBee.Framework.DataTypes;

namespace ByteBee.Framework.Tests.Stubbing.DataLayer.Enums
{
    public class TaskPriority : BeeEnum<TaskPriority, int>
    {
        public static TaskPriority Normal { get; } = new TaskPriority(1, nameof(Normal));
        public static TaskPriority Low { get; } = new TaskPriority(2, nameof(Low));
        public static TaskPriority High { get; } = new TaskPriority(3, nameof(High));
        public static TaskPriority Blocker { get; } = new TaskPriority(4, nameof(Blocker));

        public TaskPriority(int value, string name) : base(value, name)
        {
        }
    }
}