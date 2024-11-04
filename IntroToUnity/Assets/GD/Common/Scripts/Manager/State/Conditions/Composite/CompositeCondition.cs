using System.Linq;

namespace GD.State
{
    /// <summary>
    /// Abstract base class for composite conditions that combine multiple conditions.
    /// </summary>
    public abstract class CompositeCondition : ConditionBase
    {
        /// <summary>
        /// The array of child conditions to evaluate.
        /// </summary>
        public ConditionBase[] conditions;

        /// <summary>
        /// Resets the composite condition and all its child conditions.
        /// </summary>
        public override void ResetCondition()
        {
            base.ResetCondition();
            foreach (var condition in conditions)
            {
                condition.ResetCondition();
            }
        }

        /// <summary>
        /// Sorts the conditions array based on priority levels from highest to lowest.
        /// </summary>
        protected void SortConditionsByPriority()
        {
            // Sort conditions based on priorityLevel (Level1 has highest priority)
            conditions = conditions.OrderBy(c => c.priorityLevel).ToArray();
        }
    }
}