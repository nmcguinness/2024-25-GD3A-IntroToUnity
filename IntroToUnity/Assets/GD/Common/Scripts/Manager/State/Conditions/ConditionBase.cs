using GD.Types;
using UnityEngine;
using UnityEngine.Events;

namespace GD.State
{
    /// <summary>
    /// Abstract base class for conditions.
    /// </summary>
    public abstract class ConditionBase : ScriptableObject
    {
        /// <summary>
        /// Indicates whether the condition has been met.
        /// </summary>
        [HideInInspector]
        public bool isMet = false;

        /// <summary>
        /// The time in seconds since the level load when the condition was met.
        /// </summary>
        [HideInInspector]
        public float timeMet = -1f; // -1 indicates the condition hasn't been met yet

        /// <summary>
        /// The evaluation strategy for the condition.
        /// </summary>
        public EvaluateStrategy evaluateStrategy = EvaluateStrategy.EvaluateUntilMet;

        /// <summary>
        /// The priority level of the condition.
        /// </summary>
        public PriorityLevel priorityLevel = PriorityLevel.Lowest; // Default to lowest priority

        /// <summary>
        /// UnityEvent invoked when the condition becomes met.
        /// </summary>
        public UnityEvent OnConditionMet;

        /// <summary>
        /// Evaluates the condition based on the selected strategy.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        public bool Evaluate()
        {
            switch (evaluateStrategy)
            {
                case EvaluateStrategy.EvaluateAlways:
                    return EvaluateAlways();

                case EvaluateStrategy.EvaluateUntilMet:
                    return EvaluateUntilMet();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Always evaluates the condition logic, regardless of whether it is already met.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        private bool EvaluateAlways()
        {
            // Always evaluate the condition logic
            bool previousMet = isMet;
            bool result = EvaluateCondition();

            if (result)
            {
                if (!previousMet)
                {
                    isMet = true;
                    timeMet = Time.timeSinceLevelLoad;
                    OnConditionMet?.Invoke();
                }
            }
            else
            {
                isMet = false;
                timeMet = -1f;
            }

            return result;
        }

        /// <summary>
        /// Evaluates the condition logic until it becomes met, then stops evaluating.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        private bool EvaluateUntilMet()
        {
            // Evaluate until the condition is met, then return true without re-evaluating
            if (isMet)
                return true;

            bool result = EvaluateCondition();
            if (result)
            {
                isMet = true;
                timeMet = Time.timeSinceLevelLoad;
                OnConditionMet?.Invoke();
            }
            return result;
        }

        /// <summary>
        /// The actual condition logic to be implemented by derived classes.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        protected abstract bool EvaluateCondition();

        /// <summary>
        /// Resets the condition state.
        /// </summary>
        public virtual void ResetCondition()
        {
            isMet = false;
            timeMet = -1f;
        }
    }
}