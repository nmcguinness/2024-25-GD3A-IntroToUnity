using Sirenix.OdinInspector;
using System.Collections;
using UnityEngine;

public class CoroutineWaypointDemo : MonoBehaviour
{
    [FoldoutGroup("Waypoints", expanded: true)]
    [SerializeField]
    [Tooltip("List of waypoints the object will move between.")]
    private Transform[] waypoints; // Waypoints array, now private but editable in the Inspector

    [FoldoutGroup("Settings", expanded: true)]
    [SerializeField, Range(0.1f, 10f)]
    [Tooltip("Movement speed of the object.")]
    private float speed = 2f; // Movement speed, adjustable in a range via the Inspector

    [FoldoutGroup("Settings")]
    [SerializeField, Range(0f, 5f)]
    [Tooltip("Delay in seconds before moving to the next waypoint.")]
    private float delay = 1f; // Delay time

    [ShowInInspector, ReadOnly, FoldoutGroup("Runtime Info")]
    [Tooltip("The current waypoint index the object is moving towards.")]
    private int currentWaypointIndex = 0; // Exposed for runtime debugging only

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            // Start the coroutine for moving between waypoints
            StartCoroutine(MoveBetweenWaypoints());
        }
        else
        {
            Debug.LogError("No waypoints assigned!");
        }
    }

    private IEnumerator MoveBetweenWaypoints()
    {
        while (true)
        {
            // Get the target waypoint
            Transform targetWaypoint = waypoints[currentWaypointIndex];

            // Move towards the target waypoint
            while (Vector3.Distance(transform.position, targetWaypoint.position) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetWaypoint.position,
                    speed * Time.deltaTime
                );
                yield return null; // Wait for the next frame
            }

            // Wait for the specified delay
            yield return new WaitForSeconds(delay);

            // Move to the next waypoint (loop back to the start if necessary)
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}