using UnityEngine;

public class HealthChangeListener : MonoBehaviour
{
    public void OnPlayerHealthChanged(int delta)
    {
        Debug.Log($"Player health changed by {delta} at {Time.time} secs");
    }
}