using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using GD.Types;
using GD.Events;

namespace GD.Tasks
{
    /// <summary>
    /// <b>Task</b> represents a scheduled task that can be executed by the <see cref="TaskManager"/>.
    /// It supports delayed execution, repetition, and events for start and completion.
    /// </summary>
    [CreateAssetMenu(fileName = "Task", menuName = "GD/Tasks/Task")]
    public class Task : ScriptableGameObject
    {
        #region Fields

        // Group settings under a foldout
        [FoldoutGroup("Settings"), SerializeField, Tooltip("Initial delay in seconds before the task is first executed")]
        private float delay = 0f;

        [FoldoutGroup("Settings"), SerializeField, Tooltip("Interval in seconds between task repetitions")]
        private float repeatInterval = 0f;

        [FoldoutGroup("Settings"), SerializeField, Tooltip("Number of times the task should repeat. 1 = execute once, N = execute N times, -1 = infinite repetitions")]
        private int repeatCount = 1;

        [FoldoutGroup("Events"), SerializeField, Tooltip("GameEvent invoked when the task completes")]
        private GameEvent onCompleted;

        // Non-serialized runtime fields
        [SerializeField, HideInInspector]
        private int currentExecutions = 0;

        [SerializeField, HideInInspector]
        private float scheduledTime;

        // Public properties to access private fields
        [FoldoutGroup("Settings"), PropertyOrder(0)]
        public float Delay
        {
            get => delay;
            set => delay = Mathf.Max(0f, value);
        }

        [FoldoutGroup("Settings"), PropertyOrder(1)]
        public float RepeatInterval
        {
            get => repeatInterval;
            set => repeatInterval = Mathf.Max(0f, value);
        }

        [FoldoutGroup("Settings"), PropertyOrder(2)]
        public int RepeatCount
        {
            get => repeatCount;
            set
            {
                if (value == 0)
                    throw new System.ArgumentException("RepeatCount cannot be zero.", nameof(value));
                repeatCount = value;
            }
        }

        [FoldoutGroup("Events"), PropertyOrder(4)]
        public GameEvent OnCompleted
        {
            get => onCompleted;
            set => onCompleted = value;
        }

        // Runtime Info for display in TaskManager

        [FoldoutGroup("Runtime Info")]
        [ShowInInspector, ReadOnly, LabelText("Execution Count")]
        [Tooltip("Number of times the task has been executed")]
        public int CurrentExecutions
        {
            get => currentExecutions;
            private set => currentExecutions = value;
        }

        [FoldoutGroup("Runtime Info")]
        [ShowInInspector, ReadOnly, LabelText("Starts In")]
        [Tooltip("Time in seconds until the task is executed")]
        public string TimeUntilNextExecution
        {
            get
            {
                float timeRemaining = ScheduledTime - Time.time;
                return timeRemaining > 0 ? timeRemaining.ToString("F2") + "s" : "Executing";
            }
        }

        [FoldoutGroup("Runtime Info")]
        [ShowInInspector, ReadOnly, LabelText("Scheduled Time")]
        [Tooltip("Time in seconds when the task is scheduled to execute")]
        public float ScheduledTime
        {
            get => scheduledTime;
            set => scheduledTime = value;
        }

        #endregion Fields

        #region Methods

        /// <summary>
        /// Determines if the task should be rescheduled based on the repeat count.
        /// </summary>
        public bool ShouldReschedule()
        {
            // Repeat indefinitely if RepeatCount is -1
            if (RepeatCount == -1)
            {
                return true;
            }

            // Reschedule if CurrentExecutions is less than RepeatCount
            return CurrentExecutions < RepeatCount;
        }

        /// <summary>
        /// Executes the task by invoking the OnStarted and OnCompleted events.
        /// Increments the execution count.
        /// </summary>
        /// <param name="context">The context containing dependencies for the task.</param>
        public virtual void Execute(TaskContext context)
        {
            // Increment the execution count
            CurrentExecutions++;

            // Perform task-specific logic using the context
            PerformTaskLogic(context);

            // Invoke the OnCompleted event
            OnCompleted?.Raise();
        }

        /// <summary>
        /// Performs the task-specific logic. Override this method in subclasses to implement custom behavior.
        /// </summary>
        /// <param name="context">The context containing dependencies for the task.</param>
        protected virtual void PerformTaskLogic(TaskContext context)
        {
            // Default implementation does nothing
            // Subclasses can override this method to implement task-specific logic
        }

        /// <summary>
        /// Resets the task's execution data.
        /// Should be called before scheduling the task to clear previous execution state.
        /// </summary>
        public void ResetTask()
        {
            CurrentExecutions = 0;
        }

        #endregion Methods
    }
}