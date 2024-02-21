using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/** Ambience zone that adjusts emitter position based on player distance **/

[RequireComponent(typeof(BoxCollider))]
public class DistanceBasedAmbienceZone : MonoBehaviour
{
    // Audio event
    [SerializeField]
    AK.Wwise.Event audioEvent;

    // Player distance RTPC
    [SerializeField]
    AK.Wwise.RTPC playerDistanceRtpc;

    // Audio emitter
    [SerializeField]
    GameObject emitter;

    // Player for whom we track distance
    [SerializeField]
    GameObject player;

    // Collider that determines the zone bounds
    Collider zoneCollider;

    // Start is called before the first frame update
    void Start()
    {
        // Find our zone collider
        zoneCollider = GetComponent<Collider>();

        // Play our audio emitter
        audioEvent.Post(emitter);
    }

    // Update is called once per frame
    void Update()
    {
        // Move emitter to closest point to player, within zone
        Vector3 playerPosition = player.transform.position;
        Vector3 closestPointToPlayer = zoneCollider.ClosestPoint(playerPosition);
        emitter.transform.position = closestPointToPlayer;

        // Set emitter volume (via RTPC) based on distance to player
        float distanceToPlayer = Vector3.Distance(playerPosition, closestPointToPlayer);
        playerDistanceRtpc.SetValue(emitter, distanceToPlayer);
    }
}
