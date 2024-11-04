using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GD.Tasks
{
    /// <summary>
    /// The TaskManager class is responsible for scheduling and executing GameTask instances.
    /// It allows you to assign tasks via the Inspector, shows runtime information about active tasks,
    /// and handles task execution and rescheduling.
    /// </summary>
    public class TaskManager : MonoBehaviour
    {
        #region Fields

        [SerializeField, TextArea(2, 4)]
        private string description = string.Empty;

        /// <summary>
        /// List of GameTasks assigned via the Inspector.
        /// You can drag and drop GameTask assets into this list.
        /// </summary>
        [SerializeField, Tooltip("List of GameTasks to schedule. Drag and drop GameTask assets here.")]
        private List<Task> taskList = new List<Task>();

        // Internal list of instantiated tasks being managed
        private List<Task> activeTasks = new List<Task>();

        // Sorted list of tasks: key is the scheduled time, value is a list of tasks scheduled at that time
        private SortedList<float, List<Task>> tasks = new SortedList<float, List<Task>>();

        // Reference to the coroutine running the TaskRunner
        private Coroutine taskCoroutine;

        // Flag to indicate if the task list has changed (e.g., a new task was added)
        private bool taskListChanged = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the number of active tasks currently managed by the TaskManager.
        /// </summary>
        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, LabelText("Active Tasks Count"), PropertyOrder(1)]
        public int ActiveTasksCount => activeTasks.Count;

        /// <summary>
        /// Displays the list of active tasks with their runtime information.
        /// </summary>
        [FoldoutGroup("Runtime Info"), ShowInInspector, ReadOnly, PropertyOrder(2)]
        [TableList(IsReadOnly = true, AlwaysExpanded = true)]
        public List<Task> ActiveTasks => activeTasks;

        #endregion Properties

        #region Methods

        /// <summary>
        /// Unity's Start method. Initializes and schedules tasks assigned in the Inspector.
        /// </summary>
        private void Start()
        {
            // Initialize and add tasks from the Inspector-assigned list
            foreach (var taskAsset in taskList)
            {
                if (taskAsset != null)
                {
                    // Instantiate a runtime copy of the task to avoid shared state
                    Task taskInstance = Instantiate(taskAsset);
                    taskInstance.ResetTask();
                    AddTask(taskInstance);

                    // Keep track of active tasks to manage them if needed
                    activeTasks.Add(taskInstance);
                }
            }
        }

        #endregion Methods

        #region Task Management Methods

        /// <summary>
        /// Adds a new GameTask to the manager.
        /// Resets the task's execution data and schedules it for execution.
        /// </summary>
        /// <param name="task">The GameTask to add and schedule.</param>
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
        /// <param name="task">The GameTask to schedule.</param>
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
                    task.Execute();

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

        #endregion Task Management Methods
    }
}