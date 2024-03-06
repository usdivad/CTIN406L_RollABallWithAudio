using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetAudioComponent : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.State helmetEquippedState;

    [SerializeField]
    AK.Wwise.State helmetUnequippedState;

    public void OnEquip()
    {
        helmetEquippedState.SetValue();
    }

    public void OnUnequip()
    {
        helmetUnequippedState.SetValue();
    }
}
