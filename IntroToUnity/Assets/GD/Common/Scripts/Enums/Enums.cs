namespace GD.Types
{
    /// <summary>
    /// A five-level priority system used to determine the importance of a task, event, or object.
    /// </summary>
    public enum PriorityLevel : sbyte
    {
        [Description("This is the lowest priority.")]
        Lowest = 1,

        [Description("This is a low priority.")]
        Low = 2,

        [Description("This is a medium priority.")]
        Medium = 3,

        [Description("This is a high priority.")]
        High = 4,

        [Description("This is the highest priority.")]
        Highest = 5
    }
}