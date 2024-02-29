using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Component that triggers footstep audio on a timer. **/

[RequireComponent(typeof(PlayerMovementAudioComponent))]
public class TimerBasedFootstepAudioTrigger : MonoBehaviour
{
    [SerializeField]
    float timerBasedFootstepsWalkInterval = 0.4f; // Timer interval (in seconds) for footsteps when walking

    [SerializeField]
    float timerBasedFootstepsRunInterval = 0.3f; // Timer interval (in seconds) for footsteps when running

    [SerializeField]
    float timerBasedFootstepsRunSpeedThreshold = 6f; // Speed threshold to determine run vs. walk

    // ----

    CharacterController characterController; // Cached reference to the character controller
    PlayerMovementAudioComponent movementAudioComponent; // Cached reference to the movement audio component
    float timerBasedFootstepsTimeElapsed = 0f; // How much time has elapsed since our last footstep

    // ----

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        movementAudioComponent = GetComponent<PlayerMovementAudioComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        // Do nothing (early return) if we have no character controller or movement audio component
        if (characterController == null || movementAudioComponent == null)
        {
            return;
        }

        // Reset elapsed time and early return if we're not moving
        bool isMoving = characterController.velocity.magnitude > 0f;
        if (!isMoving)
        {
            timerBasedFootstepsTimeElapsed = 0f;
            return;
        }

        // Determine current timer interval based on whether we're currently walking or running
        bool isRunning = characterController.velocity.magnitude > timerBasedFootstepsRunSpeedThreshold;
        float timerBasedFootstepsInterval = isRunning ? timerBasedFootstepsRunInterval : timerBasedFootstepsWalkInterval;

        // Timer interval has been reached; trigger a footstep
        if (timerBasedFootstepsTimeElapsed >= timerBasedFootstepsInterval)
        {
            movementAudioComponent.PlayFootstepAudio();
            timerBasedFootstepsTimeElapsed = 0f;
        }
        else
        {
            // Increment time elapsed
            timerBasedFootstepsTimeElapsed += Time.deltaTime;
        }
    }
}
