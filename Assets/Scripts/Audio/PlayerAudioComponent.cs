using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player audio **/

public class PlayerAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event pickupAudioEvent; // Audio event for playing pickup SFX

    [SerializeField]
    AK.Wwise.Event rollingAudioEvent; // Audio event for playing rolling SFX

    [SerializeField]
    AK.Wwise.Event winAudioEvent; // Audio event for win SFX

    [SerializeField]
    AK.Wwise.RTPC ballSpeedRtpc; // RTPC for the ball speed

    [SerializeField]
    AK.Wwise.Event footstepAudioEvent; // Audio event for footsteps

    // Start is called before the first frame update
    void Start()
    {
        // Begin playing rolling audio loop
        rollingAudioEvent.Post(this.gameObject);
    }

    // Update audio for ball rolling. This is called within PlayerController.FixedUpdate()
    public void UpdateRollingAudio(float velocity)
    {
        // Set ball speed RTPC (volume scaling etc. happens in Wwise)
        ballSpeedRtpc.SetGlobalValue(velocity);
    }

    // Play pickup SFX. Called within PlayerController.OnTriggerEnter()
    public void PlayPickupAudio()
    {
        pickupAudioEvent.Post(this.gameObject);
    }

    // Play win SFX. Called within PlayerController.SetCountText()
    public void PlayWinAudio()
    {
        winAudioEvent.Post(this.gameObject);
    }

    // Handle footsteps
    public void OnFootstep()
    {
        footstepAudioEvent.Post(this.gameObject);
    }
}
