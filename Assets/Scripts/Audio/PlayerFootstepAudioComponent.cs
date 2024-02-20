using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Component that handles player footstep audio **/

public class PlayerFootstepAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event footstepAudioEvent; // Audio event for footsteps

    // Handle footsteps (called by animation events)
    public void OnFootstep()
    {
        // Post the Wwise event corresponding to footstep audio
        footstepAudioEvent.Post(this.gameObject);
    }
}
