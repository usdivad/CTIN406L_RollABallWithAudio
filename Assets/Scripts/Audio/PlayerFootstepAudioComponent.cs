using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player footstep audio **/
// TODO: Rename this player movement audio component
public class PlayerFootstepAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event footstepAudioEvent; // Audio event for footsteps

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Concrete; // Switcch for concrete

    [SerializeField]
    AK.Wwise.Switch footstepMaterialSwitch_Grass; // Switch for grass

    [SerializeField]
    AK.Wwise.RTPC playerSpeedRtpc; // []

    Vector3 footstepRaycastStartPositionOffset = Vector3.up * 0.05f; // Footstep ray position offset
    float footstepRaycastDistance = 100f; // How far to cast the footstep ray for

    CharacterController characterController; // Cached reference to the character controller

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (characterController == null)
        {
            return;
        }

        playerSpeedRtpc.SetGlobalValue(characterController.velocity.magnitude);

        Debug.Log(characterController.velocity.magnitude);
    }

    // Handle footsteps (called by animation events)
    public void OnFootstep()
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
                Debug.Log("OnFootstep(): Concrete");

                break;
            }
            else if (hitCollider.CompareTag("Grass")) // Grass
            {
                footstepMaterialSwitch_Grass.SetValue(this.gameObject);
                Debug.Log("OnFootstep(): Grass");

                break;
            }
        }

        // Finally, we post the footstep event to actually play a footstep sound
        footstepAudioEvent.Post(this.gameObject);
    }
}
