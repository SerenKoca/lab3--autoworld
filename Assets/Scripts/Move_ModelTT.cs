using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTMovement : MonoBehaviour
{
    // Acceleration in meters per second squared
    private float acceleration = 0.57f;
    // Maximum speed in meters per second (converted from 72 km/h)
    private float maxSpeed = 20f;
    // Current speed
    private float currentSpeed = 0f;
    // Deceleration in meters per second squared
    private float deceleration;
    // Flag to check if the race is finished
    private bool raceFinished = false;
    // Time to come to a full stop in seconds
    private float stopTime = 2f;

    void Update()
    {
        if (!raceFinished)
        {
            // Calculate the new speed, ensuring it does not exceed maxSpeed
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            // Move the object along the Z-axis based on the current speed
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            // Check if the car has crossed the finish line
            if (transform.position.z >= 100f)
            {
                raceFinished = true;
                deceleration = currentSpeed / stopTime; // Calculate deceleration needed to stop in 2 seconds
            }
        }
        else
        {
            // Gradually decelerate the car
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0); // Ensure the speed doesn't go below 0

            // Move the object along the Z-axis based on the current speed
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }
}