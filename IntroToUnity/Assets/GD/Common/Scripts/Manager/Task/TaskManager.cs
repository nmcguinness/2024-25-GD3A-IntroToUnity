using GD.Items;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Tasks
{
    /// <summary>
    /// The TaskManager class is responsible for scheduling and executing Task instances.
    /// It allows you to assign tasks via the Inspector, provides runtime control, and displays
    /// detailed runtime information about active tasks.
    /// </summary>
    public class TaskManager : MonoBehaviour
    {
        [FoldoutGroup("Context", expanded: true)]
        [SerializeField]
        [Tooltip("Player reference to evaluate conditions required by the context")]
        private Player player;

        [FoldoutGroup("Context")]
        [SerializeField]
        [Tooltip("Player inventory collection to evaluate conditions required by the context")]
        private InventoryCollection inventoryCollection;

        // Settings foldout group for task configuration
        [FoldoutGroup("Tasks")]
        [Tooltip("List of Tasks to schedule at startup. Drag and drop Task assets here.")]
        public List<Task> taskList = new List<Task>();

        // Runtime Info foldout group for displaying active tasks
        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, LabelText("Active Tasks Count")]
        public int ActiveTasksCount => activeTasks.Count;

        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly]
        [TableList(IsReadOnly = true, AlwaysExpanded = true)]
        public List<Task> ActiveTasks => activeTasks;

        [HorizontalGroup("Buttons")]
        [Button(ButtonSizes.Medium), GUIColor(1f, 0.6f, 0.6f)]
        [LabelText("Pause Tasks")]
        private void PauseTasks()
        {
            isPaused = true;
        }

        [HorizontalGroup("Buttons")]
        [Button(ButtonSizes.Medium), GUIColor(0.6f, 1f, 0.6f)]
        [LabelText("Resume Tasks")]
        private void ResumeTasks()
        {
            isPaused = false;
        }

        // Dependency Injection Context
        private TaskContext taskContext;

        // Internal list of instantiated tasks being managed
        private List<Task> activeTasks = new List<Task>();

        // Sorted list of tasks: key is the scheduled time, value is a list of tasks scheduled at that time
        private SortedList<float, List<Task>> tasks = new SortedList<float, List<Task>>();

        // Reference to the coroutine running the TaskRunner
        private Coroutine taskCoroutine;

        // Flag to indicate if the task list has changed (e.g., a new task was added)
        private bool taskListChanged = false;

        // Flag to indicate if the task execution is paused
        private bool isPaused = false;

        #region Methods

        /// <summary>
        /// Creates a TaskManager instance and initializes the TaskContext.
        /// </summary>
        private void Start()
        {
            // Initialize the TaskContext with required dependencies
            taskContext = new TaskContext(player, inventoryCollection);
        }

        /// <summary>
        /// Adds a new Task to the manager.
        /// Resets the task's execution data and schedules it for execution.
        /// </summary>
        /// <param name="task">The Task to add and schedule.</param>
        public void AddTask(Task task)
        {
            if (task != null)
            {
                // Reset task execution data
                task.ResetTask();

                // Calculate the scheduled time for the task
                task.ScheduledTime = Time.time + task.Delay;

                // Insert the task into the sorted list
                AddTaskToSchedule(task);

                // Indicate that the task list has changed
                taskListChanged = true;

                // If the coroutine is not running, start it
                if (taskCoroutine == null)
                {
                    taskCoroutine = StartCoroutine(TaskRunner());
                }
            }
        }

        /// <summary>
        /// Helper method to add a task to the schedule.
        /// </summary>
        /// <param name="task">The Task to schedule.</param>
        private void AddTaskToSchedule(Task task)
        {
            if (!tasks.ContainsKey(task.ScheduledTime))
            {
                tasks.Add(task.ScheduledTime, new List<Task>());
            }
            tasks[task.ScheduledTime].Add(task);
        }

        /// <summary>
        /// Coroutine that manages the execution of tasks.
        /// Continuously checks for tasks that are due to execute and handles rescheduling if necessary.
        /// </summary>
        private IEnumerator TaskRunner()
        {
            // Continue running as long as there are tasks in the list
            while (tasks.Count > 0)
            {
                // Pause handling
                while (isPaused)
                {
                    yield return null;
                }

                // Reset the task list changed flag
                taskListChanged = false;

                // Get the earliest scheduled time (key) and the list of tasks at that time
                float nextScheduledTime = tasks.Keys[0];
                List<Task> tasksAtTime = tasks.Values[0];

                // Calculate the wait time until the next scheduled time
                float waitTime = nextScheduledTime - Time.time;

                // Wait until it's time to execute the next task or until the task list changes
                while (waitTime > 0f && !taskListChanged)
                {
                    if (isPaused)
                    {
                        // Wait while paused
                        yield return null;
                        continue;
                    }

                    // Wait for the next frame
                    yield return null;

                    // Update the wait time
                    waitTime = nextScheduledTime - Time.time;
                }

                // If the task list changed (e.g., a new task with an earlier time was added), re-evaluate the next task
                if (taskListChanged)
                {
                    continue;
                }

                // Execute all tasks scheduled for this time
                foreach (var task in tasksAtTime)
                {
                    // Pass the context to the task's Execute method
                    task.Execute(taskContext);

                    // Check if the task should be rescheduled
                    if (task.ShouldReschedule())
                    {
                        // Calculate the next scheduled time based on the repeat interval
                        task.ScheduledTime = Time.time + task.RepeatInterval;

                        // Insert the task back into the schedule
                        AddTaskToSchedule(task);

                        // Indicate that the task list has changed
                        taskListChanged = true;
                    }
                    else
                    {
                        // Remove the task from activeTasks if it is completed and not rescheduled
                        activeTasks.Remove(task);
                    }
                }

                // Remove the executed tasks from the list
                tasks.RemoveAt(0);
            }

            // When there are no more tasks, reset the coroutine reference
            taskCoroutine = null;
        }

        #endregion Methods
    }
}