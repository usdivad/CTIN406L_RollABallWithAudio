using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Emitter that plays audio when collided with **/

[RequireComponent(typeof(AudioSource))]
public class CollisionAudioEmitter : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event collisionEvent;

    [SerializeField]
    AK.Wwise.RTPC collisionVelocityNormalizedRtpc;

    [SerializeField]
    float maxCollisionVelocity = 15f; // Max velocity to use for collisions

    // Called when another object collides with this game object
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ouch!");

        PlayAudio(collision.relativeVelocity.magnitude);
    }

    // Play audio for collision
    void PlayAudio(float velocity)
    {
        // Scale the volume based on collision velocity...
        // (we can still do the normalizing on the game-engine-side if we'd like)
        float velocityNormalized = Mathf.Clamp01(velocity / maxCollisionVelocity);
        collisionVelocityNormalizedRtpc.SetValue(this.gameObject, velocityNormalized);

        // ... then post the event
        collisionEvent.Post(this.gameObject);

        Debug.LogFormat("Collision: Velocity={0}, Normalized={1}", velocity, velocityNormalized);
    }
}
