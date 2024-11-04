using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace GD.State
{
    /// <summary>
    /// Abstract base class for conditions.
    /// </summary>
    public abstract class ConditionBase : ScriptableGameObject
    {
        #region Fields

        /// <summary>
        /// The evaluation strategy for the condition.
        /// </summary>
        [SerializeField]
        [Tooltip("The evaluation strategy for the condition.")]
        [FoldoutGroup("Strategy & Priority")]
        public EvaluateStrategy evaluateStrategy = EvaluateStrategy.EvaluateUntilMet;

        /// <summary>
        /// The priority level of the condition.
        /// </summary>
        [SerializeField]
        [Tooltip("The priority level of the condition (Highest = 1, Lowest = 5).")]
        [FoldoutGroup("Strategy & Priority")]
        public PriorityLevel priorityLevel = PriorityLevel.Lowest; // Default to lowest priority

        /// <summary>
        /// UnityEvent invoked when the condition becomes met.
        /// </summary>
        [SerializeField]
        [Tooltip("UnityEvent invoked when the condition is met.")]
        [FoldoutGroup("Events")]
        public UnityEvent OnConditionMet;

        /// <summary>
        /// Indicates whether the condition has been met.
        /// </summary>
        [SerializeField, ReadOnly]
        [Tooltip("Indicates whether the condition has been met.")]
        [FoldoutGroup("State & Timing")]
        private bool isMet = false;

        /// <summary>
        /// The time in seconds since the level load when the condition was met.
        /// </summary>
        [SerializeField, ReadOnly]
        [Tooltip("The time in seconds since the level load when the condition was met.")]
        [FoldoutGroup("State & Timing")]
        private float timeMet = -1f; // -1 indicates the condition hasn't been met yet

        #endregion Fields

        #region Properties

        public bool IsMet { get => isMet; protected set => isMet = value; }
        public float TimeMet { get => timeMet; protected set => timeMet = value; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Evaluates the condition based on the selected strategy.
        /// </summary>
        /// <returns>True if the condition is met; otherwise, false.</returns>
        public bool Evaluate()
        {
            switch (evaluateStrategy)
            {
                // Evaluate the condition even if it is already met
                case EvaluateStrategy.EvaluateAlways:
                    return EvaluateAlways();

                // Evaluate the condition until it is met, then stop evaluating
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
            bool previousMet = IsMet;
            bool result = EvaluateCondition();

            // If the condition is met, invoke the event
            if (result)
            {
                // Only invoke the event if the condition wasn't met before
                if (!previousMet)
                {
                    IsMet = true;
                    TimeMet = Time.timeSinceLevelLoad;
                    OnConditionMet?.Invoke();
                }
            }
            // If the condition is not met, reset the state
            else
            {
                IsMet = false;
                TimeMet = -1f;
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
            if (IsMet)
                return true;

            bool result = EvaluateCondition();
            if (result)
            {
                IsMet = true;
                TimeMet = Time.timeSinceLevelLoad;
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
            IsMet = false;
            TimeMet = -1f;
        }

        #endregion Methods
    }
}