using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLimit : MonoBehaviour
{
    public float radius = 5f; // The radius of the circular area
    private Vector3 circleCenter; // The center of the circular area

    private void Start()
    {
        circleCenter = transform.position; // Set the center of the circular area to the starting position of the object this script is attached to
    }

    private void Update()
    {
        Vector3 playerPos = transform.position; // Get the current position of the object this script is attached to
        float distanceFromCenter = Vector3.Distance(playerPos, circleCenter); // Calculate the distance from the center of the circular area

        // If the distance from the center is greater than the radius, limit the player's movement to within the circular area
        if (distanceFromCenter > radius)
        {
            transform.position = circleCenter + (playerPos - circleCenter).normalized * radius;
        }
    }
}
