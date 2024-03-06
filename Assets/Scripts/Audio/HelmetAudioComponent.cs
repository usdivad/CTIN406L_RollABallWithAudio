using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Component that handles audio for a helmet **/
public class HelmetAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.State helmetEquippedState; // State representing helmet equipped

    [SerializeField]
    AK.Wwise.State helmetUnequippedState; // State representing helmet unequipped

    // Called by Helmet when equipped
    public void OnEquip()
    {
        // Set the state to equipped
        helmetEquippedState.SetValue();
    }

    // Called by Helmet when unequipped
    public void OnUnequip()
    {
        // Set the state to unequipped
        helmetUnequippedState.SetValue();
    }
}
