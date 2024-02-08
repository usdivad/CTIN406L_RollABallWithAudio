using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

/** Ambience zone that adjusts emitter position based on player distance **/

[RequireComponent(typeof(BoxCollider))]
public class DistanceBasedAmbienceZone : MonoBehaviour
{
    // Audio emitter
    [SerializeField]
    AudioSource emitter;

    // Player for whom we track distance
    [SerializeField]
    GameObject player;

    // Max distance to player (above which volume is 0)
    [SerializeField]
    float maxDistanceToPlayer = 10f;

    // Collider that determines the zone bounds
    Collider zoneCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Find our zone collider
        zoneCollider = GetComponent<Collider>();
        
        // Play our audio emitter
        emitter.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Move emitter to closest point to player, within zone
        Vector3 playerPosition = player.transform.position;
        Vector3 closestPointToPlayer = zoneCollider.ClosestPoint(playerPosition);
        emitter.transform.position = closestPointToPlayer;

        // Set emitter volume based on distance to player
        float distanceToPlayer = Vector3.Distance(playerPosition, closestPointToPlayer);
        float distanceScaled = distanceToPlayer / maxDistanceToPlayer;
        float emitterVolume = Mathf.Clamp01(1f - distanceScaled);
        emitter.volume = emitterVolume;
    }
}
