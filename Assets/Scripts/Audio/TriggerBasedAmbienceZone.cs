using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/** Ambience zone that plays/stops an emitter (with fades) based on
    trigger enter/exit **/

[RequireComponent(typeof(BoxCollider))]
public class TriggerBasedAmbienceZone : MonoBehaviour
{
    // Audio emitter
    [SerializeField]
    AudioSource emitter;

    // Player tag, for making sure we only react to player
    [SerializeField]
    string playerTag = "Player";

    // How long to fade audio in and out
    [SerializeField]
    float fadeDuration = 2f;

    // Fade book-keeping
    float fadeTimeElapsed = 0f;  // How long we've been fading for
    float fadeStartVolume = 0f;  // Emitter volume at fade start
    float fadeTargetVolume = 0f; // Target emitter volume at fade end

    // Update is called once per frame
    void Update()
    {
        if (fadeTimeElapsed > fadeDuration) // If we've finished fading...
        {
            emitter.volume = fadeTargetVolume; // ... Ensure we reach the target volume ...

            // ... Stop our emitter after a fade-out is complete ...
            //     (We don't do this for fade-ins)
            if (fadeTargetVolume <= 0f && emitter.isPlaying)
            {
                emitter.Stop();
                Debug.Log("TriggerBasedAmbienceZone: Stopping");
            }

            return; // ... And skip the rest of the Update() function
        }

        // --------

        // Apply fade to emitter volume
        float fadePercentage = Mathf.Clamp01(fadeTimeElapsed / fadeDuration);
        float volume = Mathf.Lerp(fadeStartVolume, fadeTargetVolume, fadePercentage);
        emitter.volume = volume;

        //Debug.LogFormat("TriggerBasedAmbienceZone: Volume={0}", volume);

        // Update elapsed time
        fadeTimeElapsed += Time.deltaTime;
    }

    // Called when another object passes into this one
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            // Play our emitter
            emitter.Play();
            Debug.Log("TriggerBasedAmbienceZone: Playing");

            // Reset fade book-keeping
            fadeStartVolume = emitter.volume;
            fadeTargetVolume = 1f; // Full volume
            fadeTimeElapsed = 0f;
        }
    }

    // Called when another object passes out of this one
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == playerTag)
        {
            // Reset fade book-keeping
            fadeStartVolume = emitter.volume;
            fadeTargetVolume = 0f; // Zero volume
            fadeTimeElapsed = 0f;
        }
    }
}
