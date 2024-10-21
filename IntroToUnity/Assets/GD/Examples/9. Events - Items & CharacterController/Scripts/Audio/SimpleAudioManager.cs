using GD.Items;
using UnityEngine;

public class SimpleAudioManager : MonoBehaviour
{
    public void OnInteractablePickup(ItemData data)
    {
        Debug.Log("Playing audio clip: " + data.AudioClip.name);
        AudioSource.PlayClipAtPoint(data.AudioClip, transform.position);
    }
}