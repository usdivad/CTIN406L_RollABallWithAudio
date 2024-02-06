using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(BoxCollider))]
public class DistanceBasedAmbienceZone : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    AudioSource emitter;

    [SerializeField]
    float maxDistanceToPlayer = 10f;

    Collider zoneCollider;

    // Start is called before the first frame update
    void Start()
    {
        zoneCollider = GetComponent<Collider>();
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
