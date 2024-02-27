using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles non-player ball audio **/

public class BallAudioComponent : MonoBehaviour
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
    AK.Wwise.State musicIdleState;

    [SerializeField]
    AK.Wwise.State musicPickupState;

    [SerializeField]
    AK.Wwise.State musicWinState;

    [SerializeField]
    AK.Wwise.Event musicPickupTrigger;

    [SerializeField]
    float pickupTimeIncrementAmount = 6f;

    bool isInPickupState = false;
    float pickupTimeRemaining = 0f;
    bool didWin = false;

    // Start is called before the first frame update
    void Start()
    {
        // Begin playing rolling audio loop
        rollingAudioEvent.Post(this.gameObject);
    }

    private void Update()
    {
        if (isInPickupState && !didWin)
        {
            if (pickupTimeRemaining <= 0f)
            {
                musicIdleState.SetValue();
                isInPickupState = false;
                pickupTimeRemaining = 0f;
            }
            else
            {
                pickupTimeRemaining -= Time.deltaTime;
            }

            Debug.Log("Pickup time remaining: " + pickupTimeRemaining);
        }
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
        musicPickupTrigger.Post(this.gameObject);

        if (!didWin)
        {
            musicPickupState.SetValue();
            isInPickupState = true;
            pickupTimeRemaining += pickupTimeIncrementAmount;
        }
    }

    // Play win SFX. Called within PlayerController.SetCountText()
    public void PlayWinAudio()
    {
        winAudioEvent.Post(this.gameObject);
        musicWinState.SetValue();

        didWin = true;
        isInPickupState = false;
    }
}
