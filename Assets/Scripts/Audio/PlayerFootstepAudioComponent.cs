using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player footstep audio **/

public class PlayerFootstepAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event footstepAudioEvent; // Audio event for footsteps

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Concrete; // Switcch for concrete

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Grass; // Switch for grass

    Vector3 footstepRaycastStartPositionOffset = Vector3.up * 0.05f; // Footstep ray position offset
    float footstepRaycastDistance = 100f; // How far to cast the footstep ray for
    float animationEventWeightThreshold = 0.5f; // Anim weight threshold below which we don't play footstep audio

    // Play footstep audio from an animation event (used for third-person footsteps)
    public void PlayFootstepAudioFromAnimationEvent(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > animationEventWeightThreshold)
        {
            PlayFootstepAudio();
        }
    }

    // Play footstep audio directly (used for first-person footsteps)
    public void PlayFootstepAudio()
    {
        // Cast a ray from the player position (with upwards offset) directly downwards
        Vector3 startPosition = transform.position + footstepRaycastStartPositionOffset;
        RaycastHit[] hits = Physics.RaycastAll(startPosition, Vector3.down, footstepRaycastDistance);

        // Iterate through the raycast hits to see if we find any objects that match our surface tags
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Collider hitCollider = hit.collider;

            // If we find a valid surface, we set the appropriate Wwise switch and break out of the loop
            if (hitCollider.CompareTag("Concrete")) // Concrete
            {
                footstepMaterialSwitch_Concrete.SetValue(this.gameObject);
                Debug.Log("PlayFootstepAudio(): Concrete");

                break;
            }
            else if (hitCollider.CompareTag("Grass")) // Grass
            {
                footstepMaterialSwitch_Grass.SetValue(this.gameObject);
                Debug.Log("PlayFootstepAudio(): Grass");

                break;
            }
        }

        // Finally, we post the footstep event to actually play a footstep sound
        footstepAudioEvent.Post(this.gameObject);
    }
}
