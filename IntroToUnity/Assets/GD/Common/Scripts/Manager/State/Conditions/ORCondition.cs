// OrCondition.cs
using UnityEngine;

namespace GD.State
{
    /// <summary>
    /// A composite condition that is met when any child condition is met.
    /// </summary>
    [CreateAssetMenu(fileName = "AndCondition", menuName = "GD/Conditions/OR Condition")]
    public class OrCondition : CompositeCondition
    {
        /// <summary>
        /// Evaluates the condition logic: returns true if any child condition is met.
        /// </summary>
        /// <returns>True if any child condition is met; otherwise, false.</returns>
        protected override bool EvaluateCondition()
        {
            // Sort conditions by priority before evaluation
            SortConditionsByPriority();

            foreach (var condition in conditions)
            {
                if (condition.Evaluate())
                {
                    if (timeMet == -1f)
                    {
                        timeMet = Time.timeSinceLevelLoad;
                        OnConditionMet?.Invoke();
                    }
                    return true;
                }
            }
            return false;
        }
    }
}