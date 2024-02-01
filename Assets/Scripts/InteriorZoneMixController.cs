using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

/** Trigger zone that controls the interior/exterior mix **/

public class InteriorZoneMixController : MonoBehaviour
{
    // Mixer snapshot to use for interior zone
    [SerializeField]
    AudioMixerSnapshot interiorMixerSnapshot;

    // Mixer snapshot to use for interior zone
    [SerializeField]
    AudioMixerSnapshot exteriorMixerSnapshot;

    // How long the mixer transition should take, in seconds
    [SerializeField]
    float mixTransitionTime = 2f;

    // Player tag
    [SerializeField]
    string playerTag = "Player";

    // Called when another object passes into this one
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            interiorMixerSnapshot.TransitionTo(mixTransitionTime);
            Debug.Log("Entering interior zone");
        }
    }

    // Called when another object passes out of this one
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            exteriorMixerSnapshot.TransitionTo(mixTransitionTime);
            Debug.Log("Exiting interior zone");
        }
    }
}
