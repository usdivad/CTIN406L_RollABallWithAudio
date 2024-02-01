using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player audio **/

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioComponent : MonoBehaviour
{
    [SerializeField]
    AudioSource pickupAudioSource; // Audio source for playing pickup SFX

    [SerializeField]
    AudioSource rollingAudioSource; // Audio source for playing rolling SFX

    [SerializeField]
    AudioClip winAudioClip; // Audio clip for win SFX. Played on pickup source

    [SerializeField]
    float maxRollingVelocity = 10f; // Max velocity for rolling

    // Start is called before the first frame update
    void Start()
    {
        // Begin playing rolling audio loop
        rollingAudioSource.loop = true;
        rollingAudioSource.volume = 0f;
        rollingAudioSource.Play();
    }

    // Update audio for ball rolling. This is called within PlayerController.FixedUpdate()
    public void UpdateRollingAudio(float velocity)
    {
        // Scale rolling volume based on ball velocity
        float volume = Mathf.Clamp(velocity / maxRollingVelocity, 0f, 1f);
        rollingAudioSource.volume = volume;

        Debug.LogFormat("Rolling: Velocity={0}, Volume={1}", velocity, volume);
    }

    // Play pickup SFX. Called within PlayerController.OnTriggerEnter()
    public void PlayPickupAudio()
    {
        pickupAudioSource.Play();
    }

    // Play win SFX. Called within PlayerController.SetCountText()
    public void PlayWinAudio()
    {
        pickupAudioSource.PlayOneShot(winAudioClip, 1f);
    }
}
