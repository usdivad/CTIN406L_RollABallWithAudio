using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

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
    AK.Wwise.Event musicEvent; // Event for music playback

    [SerializeField]
    AK.Wwise.State musicIdleState; // Idle state for music

    [SerializeField]
    AK.Wwise.State musicPickupState; // Pickup state for music

    [SerializeField]
    AK.Wwise.State musicWinState; // Win state for music

    [SerializeField]
    AK.Wwise.Event musicPickupTrigger; // Trigger for pickup stinger

    [SerializeField]
    AK.Wwise.CallbackFlags musicCallbackFlags; // Callback flags for music

    [SerializeField]
    UnityEvent musicBarCallbackEvent; // Event that gets invoked when a bar is reached

    [SerializeField]
    UnityEvent musicBeatCallbackEvent; // Event that gets invoked when a beat is reached

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

        // Begin playing music
        musicEvent.Post(this.gameObject, musicCallbackFlags, MusicSyncCallback);
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

    // Music callback handler
    public void MusicSyncCallback(object inCookie, AkCallbackType inType, object inInfo)
    {
        // Get the callback type
        AkMusicSyncCallbackInfo callbackInfo = (AkMusicSyncCallbackInfo)inInfo;
        AkCallbackType callbackType = callbackInfo.musicSyncType;

        // Invoke events based on callback type -- only bar and beat are handled
        switch (callbackType)
        {
            case AkCallbackType.AK_MusicSyncBar:
                {
                    Debug.Log("Music callback: Bar reached");
                    musicBarCallbackEvent.Invoke();
                }
                break;

            case AkCallbackType.AK_MusicSyncBeat:
                {
                    Debug.Log("Music callback: Beat reached");
                    musicBeatCallbackEvent.Invoke();
                }
                break;

            default:
                { }
                break;
        }
    }
}
