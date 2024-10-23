using GD;
using GD.Events;
using UnityEngine;

/// <summary>
/// Sends a health change event every 5 seconds.
/// </summary>
public class HealthChangeSender : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Event to raise when health changes.")]
    private IntGameEvent healthEvent;

    [SerializeField]
    [Range(0.25f, 10)]
    [Tooltip("Time between health change events in seconds.")]
    private float timeBetweenChangesSecs = 2;

    //Track time since last health change event.
    private float timeSinceLastChangeSecs = 0;

    private void Update()
    {
        //Track time since last health change event.
        timeSinceLastChangeSecs += Time.deltaTime;

        //Send a health change event every N seconds.
        if (timeSinceLastChangeSecs > timeBetweenChangesSecs)
        {
            healthEvent.Raise(100);
            timeSinceLastChangeSecs = 0;
        }
    }
}