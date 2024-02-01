using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Emitter that plays audio when collided with **/

[RequireComponent(typeof(AudioSource))]
public class CollisionAudioEmitter : MonoBehaviour
{
    [SerializeField]
    float maxCollisionVelocity = 15f; // Max velocity to use for collisions

    AudioSource audioSource; // Audio source to use for playing SFX

    // Start is called before the first frame update
    void Start()
    {
        // Set the audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Called when another object collides with this game object
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ouch!");

        PlayAudio(collision.relativeVelocity.magnitude);
    }

    // Play audio for collision
    void PlayAudio(float velocity)
    {
        if (audioSource != null)
        {
            // Scale audio source's volume based on collision velocity...
            audioSource.volume = Mathf.Clamp01(velocity / maxCollisionVelocity);

            // ... then play the audio source
            audioSource.Play();

            Debug.LogFormat("Collision: Velocity={0}, Volume={1}", velocity, audioSource.volume);
        }
    }
}
