using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/** Ambience zone that plays/stops an audio event based on
    trigger enter/exit **/

[RequireComponent(typeof(BoxCollider))]
public class TriggerBasedAmbienceZone : MonoBehaviour
{
    // Event for playing ambience audio
    [SerializeField]
    AK.Wwise.Event playEvent;

    // Event for stopping ambience audio
    [SerializeField]
    AK.Wwise.Event stopEvent;

    // Player tag, for making sure we only react to player
    [SerializeField]
    string playerTag = "Player";

    // Called when another object passes into this one
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            // Post our play event
            playEvent.Post(this.gameObject);
            Debug.Log("TriggerBasedAmbienceZone: Playing");
        }
    }

    // Called when another object passes out of this one
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            // Post our stop event
            stopEvent.Post(this.gameObject);
            Debug.Log("TriggerBasedAmbienceZone: Stopping");
        }
    }
}
