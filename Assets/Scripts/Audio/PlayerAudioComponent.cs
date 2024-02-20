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

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Concrete;

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Grass;

    float footstepRaycastStartPositionOffset = 0.05f;
    float footstepRaycastDistance = 100f;

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
        // Cast a ray from the player position (with offset) directly downwards
        Vector3 startPosition = transform.position + (Vector3.up * footstepRaycastStartPositionOffset);
        RaycastHit[] hits = Physics.RaycastAll(startPosition, Vector3.down, footstepRaycastDistance);

        // Iterate through the raycast hits to see if we find any objects that match our surface tags
        for (int i=0; i<hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider hitCollider = hit.collider;

            // If we find a valid surface, we set the appropriate Wwise switch and break out of the loop
            if (hitCollider.CompareTag("Concrete"))
            {
                footstepMaterialSwitch_Concrete.SetValue(this.gameObject);
                Debug.Log("OnFootstep(): Concrete");

                break;
            }
            else if (hitCollider.CompareTag("Grass"))
            {
                footstepMaterialSwitch_Grass.SetValue(this.gameObject);
                Debug.Log("OnFootstep(): Grass");

                break;
            }
        }

        // Finally, we post the footstep event to actually play a footstep sound
        footstepAudioEvent.Post(this.gameObject);

        // Additional debug logging (commented out)
        //Debug.LogFormat("OnFootstep(): {0}, {1}", transform.position, hits.Length);
        //Debug.DrawRay(startPosition, Vector3.down);
    }
}
