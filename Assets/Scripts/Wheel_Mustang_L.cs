using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationL : MonoBehaviour
{
    public float rotationMultiplier = 30f; // Multiplier to adjust rotation speed based on car speed
    private MustangMovement mustangMovement; // Reference to the car's movement script
    public float minimumRotationSpeed = 100f; // Minimum rotation speed

    void Start()
    {
        // Get the MustangMovement component from the parent or the same GameObject
        mustangMovement = GetComponentInParent<MustangMovement>();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && mustangMovement != null) // Check if the race has started
        {
            // Rotate the wheel based on the car's current speed, reversing the direction
            float rotationSpeed = -mustangMovement.currentSpeed * rotationMultiplier;
            rotationSpeed = Mathf.Min(rotationSpeed, -minimumRotationSpeed); // Ensure minimum rotation speed
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}