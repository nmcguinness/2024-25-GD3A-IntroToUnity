using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using GD.Types; // Include Odin Inspector namespace

namespace GD.Tasks
{
    [CreateAssetMenu(fileName = "Task", menuName = "GD/Tasks/Task")]
    public class Task : ScriptableGameObject
    {
        #region Fields

        // Group settings under a foldout
        [FoldoutGroup("Settings", expanded: true), SerializeField, Tooltip("Initial delay in seconds before the task is first executed")]
        private float delay = 0f;

        [FoldoutGroup("Settings"), SerializeField, Tooltip("Interval in seconds between task repetitions")]
        private float repeatInterval = 0f;

        [FoldoutGroup("Settings"), SerializeField, Tooltip("Number of times the task should repeat. 1 = execute once, N = execute N times, -1 = infinite repetitions")]
        private int repeatCount = 1;

        // UnityEvents for task start and completion
        [FoldoutGroup("Events"), SerializeField, Tooltip("Event invoked when the task starts")]
        private UnityEvent onStarted = new UnityEvent();

        [FoldoutGroup("Events"), SerializeField, Tooltip("Event invoked when the task executes")]
        private UnityEvent onExecute = new UnityEvent();

        [FoldoutGroup("Events"), SerializeField, Tooltip("Event invoked when the task completes")]
        private UnityEvent onCompleted = new UnityEvent();

        // Non-serialized runtime fields
        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, Tooltip("Tracks how many times the task has been executed")]
        private int currentExecutions = 0;

        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, Tooltip("The scheduled time when the task should be executed")]
        private float scheduledTime;

        #endregion Fields

        #region Properties

        // Public properties to access private fields
        [FoldoutGroup("Settings"), PropertyOrder(0)]
        public float Delay
        {
            get => delay;
            set => delay = value;
        }

        [FoldoutGroup("Settings"), PropertyOrder(1)]
        public float RepeatInterval
        {
            get => repeatInterval;
            set => repeatInterval = value;
        }

        [FoldoutGroup("Settings"), PropertyOrder(2)]
        public int RepeatCount
        {
            get => repeatCount;
            set => repeatCount = value;
        }

        [FoldoutGroup("Events"), PropertyOrder(3)]
        public UnityEvent OnStarted
        {
            get => onStarted;
            set => onStarted = value;
        }

        [FoldoutGroup("Events"), PropertyOrder(4)]
        public UnityEvent OnExecute
        {
            get => onExecute;
            set => onExecute = value;
        }

        [FoldoutGroup("Events"), PropertyOrder(5)]
        public UnityEvent OnCompleted
        {
            get => onCompleted;
            set => onCompleted = value;
        }

        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, PropertyOrder(6)]
        public int CurrentExecutions
        {
            get => currentExecutions;
            private set => currentExecutions = value;
        }

        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, PropertyOrder(7)]
        public float ScheduledTime
        {
            get => scheduledTime;
            internal set => scheduledTime = value;
        }

        #endregion Properties

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
        /// </summary>
        public void Execute()
        {
            // Increment the execution count
            CurrentExecutions++;

            // Invoke the OnStarted event
            OnStarted?.Invoke();

            // Task-specific logic can be added here
            OnExecute?.Invoke();

            // Invoke the OnCompleted event
            OnCompleted?.Invoke();
        }

        /// <summary>
        /// Resets the task's execution data.
        /// </summary>
        public void ResetTask()
        {
            CurrentExecutions = 0;
        }

        #endregion Methods
    }
}