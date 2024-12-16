using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationR : MonoBehaviour
{
    public float rotationMultiplier = 10f; // Multiplier to adjust rotation speed based on car speed
    private MustangMovement mustangMovement; // Reference to the car's movement script

    void Start()
    {
        // Get the MustangMovement component from the parent or the same GameObject
        mustangMovement = GetComponentInParent<MustangMovement>();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && mustangMovement != null) // Check if the race has started
        {
            // Rotate the wheel based on the car's current speed
            float rotationSpeed = mustangMovement.currentSpeed * rotationMultiplier;
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}