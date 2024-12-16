using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model40Movement : MonoBehaviour
{
    // Acceleration in meters per second squared
    private float acceleration = 1.34f;
    // Maximum speed in meters per second (converted from 122 km/h)
    private float maxSpeed = 33.89f;
    // Current speed
    public float currentSpeed = 0f;
    // Deceleration in meters per second squared
    private float deceleration;
    // Flag to check if the race is finished
    public bool raceFinished = false; // Make this public to be consistent
    // Time to come to a full stop in seconds
    private float stopTime = 2f;

    void Update()
    {
        if (RaceStarter.raceStarted && !raceFinished) // Check if the race has started
        {
            // Calculate the new speed, ensuring it does not exceed maxSpeed
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

            // Move the object along the X-axis based on the current speed
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

            // Check if the car has crossed the finish line
            if (transform.position.z >= 100f)
            {
                raceFinished = true;
                deceleration = currentSpeed / stopTime; // Calculate deceleration needed to stop in 2 seconds
                Debug.Log("Race finished. Deceleration: " + deceleration);
            }
        }
        else if (raceFinished)
        {
            // Gradually decelerate the car
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0); // Ensure the speed doesn't go below 0

            // Move the object along the X-axis based on the current speed
            transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

            Debug.Log("Decelerating. Current speed: " + currentSpeed);
        }
    }
}