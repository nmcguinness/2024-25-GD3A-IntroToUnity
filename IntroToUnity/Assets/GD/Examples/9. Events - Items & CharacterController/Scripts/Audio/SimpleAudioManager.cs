using GD.Items;
using UnityEngine;

public class SimpleAudioManager : MonoBehaviour
{
    public void OnInteractablePickup(ItemData data)
    {
        //TODO - add support for an AudioSource component
        AudioSource.PlayClipAtPoint(data.AudioClip, data.AudioPosition);
    }
}