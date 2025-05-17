using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingIndicator : MonoBehaviour
{
    public Transform player;
    public LayerMask groundLayer;
    public float maxRayDistance = 50f;

    void Update()
    {
        RaycastHit hit;

        // Cast a ray downward from the player to find ground
        if (Physics.Raycast(player.position, Vector3.down, out hit, maxRayDistance, groundLayer))
        {
            Vector3 indicatorPos = hit.point + Vector3.up * 0.05f; // slight lift to avoid z-fighting
            transform.position = new Vector3(hit.point.x, indicatorPos.y, hit.point.z);
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
        else
        {
            // Hide or disable indicator if no ground detected
            transform.position = new Vector3(player.position.x, player.position.y - maxRayDistance, player.position.z);
        }
    }
}
