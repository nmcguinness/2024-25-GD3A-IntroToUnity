using GD.Audio;
using GD.Types;
using Sirenix.OdinInspector;
using UnityEngine;

public class TestAudioManager : MonoBehaviour
{
    [Title("Audio Clips")]
    [SerializeField]
    private AudioClip backgroundMusicClip;

    [SerializeField]
    private AudioClip sfxClip;

    [SerializeField]
    private AudioClip ambientClip;

    [Title("Test Parameters")]
    [SerializeField]
    private Transform sfxPosition;

    [SerializeField]
    [Range(-80, 0)]
    private float masterVolume = 0f; // Volume in decibels (-80 to 0)

    [SerializeField]
    [Range(0, 1)]
    private float sfxVolume = 0f;    // Volume in decibels (-80 to 0)

    [SerializeField]
    [Range(0, 1)]
    private float backgroundVolume = 0f; // Volume in decibels (-80 to 0)

    private void Update()
    {
        // Test playing background music
        if (Input.GetKeyDown(KeyCode.B))
            AudioManager.Instance.PlaySound(backgroundMusicClip, AudioMixerGroupName.Background);

        // Test playing SFX at a specific position
        if (Input.GetKeyDown(KeyCode.S))
            AudioManager.Instance.PlaySound(sfxClip, AudioMixerGroupName.SFX,
                sfxPosition.position);

        // Test playing ambient sound
        if (Input.GetKeyDown(KeyCode.A))
            AudioManager.Instance.PlaySound(ambientClip, AudioMixerGroupName.Ambient);
    }
}