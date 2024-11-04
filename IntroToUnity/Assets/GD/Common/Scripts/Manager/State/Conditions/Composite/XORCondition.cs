using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A composite condition that is met when exactly one child condition is met.
    /// </summary>
    [CreateAssetMenu(menuName = "GD/Conditions/Composite/XORCondition")]
    public class XORCondition : CompositeCondition
    {
        /// <summary>
        /// Evaluates the condition logic: returns true if exactly one child condition is met.
        /// </summary>
        /// <returns>True if exactly one child condition is met; otherwise, false.</returns>
        protected override bool EvaluateCondition()
        {
            // Sort conditions by priority before evaluation
            SortConditionsByPriority();

            int metCount = 0;

            foreach (var condition in conditions)
            {
                if (condition.Evaluate())
                {
                    metCount++;
                    // If more than one condition is met, return false
                    if (metCount > 1)
                    {
                        return false;
                    }
                }
            }

            // If exactly one condition is met
            if (metCount == 1)
            {
                if (TimeMet == -1f)
                {
                    TimeMet = Time.timeSinceLevelLoad;
                    OnConditionMet?.Invoke();
                }
                return true;
            }

            // If none or more than one condition is met
            return false;
        }
    }
}