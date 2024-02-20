using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player audio **/

public class PlayerFootstepAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event footstepAudioEvent; // Audio event for footsteps

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Concrete;

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Grass;

    float footstepRaycastStartPositionOffset = 0.05f;
    float footstepRaycastDistance = 100f;

    // Handle footsteps
    public void OnFootstep()
    {
        // Cast a ray from the player position (with offset) directly downwards
        Vector3 startPosition = transform.position + (Vector3.up * footstepRaycastStartPositionOffset);
        RaycastHit[] hits = Physics.RaycastAll(startPosition, Vector3.down, footstepRaycastDistance);

        // Iterate through the raycast hits to see if we find any objects that match our surface tags
        for (int i = 0; i < hits.Length; i++)
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
