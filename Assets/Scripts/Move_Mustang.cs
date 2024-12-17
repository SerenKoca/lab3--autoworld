using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustangMovement : MonoBehaviour
{
    public float acceleration = 3.12f; // Acceleration in meters per second squared
    public float topSpeed = 50.28f; // Top speed in meters per second (181 km/h)
    public float currentSpeed = 0f; // Current speed of the car
    public bool raceFinished = false; // Flag to check if the race is finished
    private float deceleration; // Deceleration in meters per second squared
    private float stopTime = 2f; // Time to come to a full stop in seconds

    public AudioSource audioSource; // Audio source component
    public AudioClip startClip; // Audio clip for the start
    public AudioClip driveClip; // Audio clip for driving
    public AudioClip brakeClip; // Audio clip for braking
    public AudioClip idleClip; // Audio clip for idling

    void Start()
    {
        // Play the start sound at the beginning
        audioSource.clip = startClip;
        audioSource.Play();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && !raceFinished) // Check if the race has started
        {
            // Calculate the new speed
            currentSpeed += acceleration * Time.deltaTime;
            // Clamp the speed to the top speed
            currentSpeed = Mathf.Clamp(currentSpeed, 0, topSpeed);
            // Move the car along the Z-axis
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            // Play the driving sound if not already playing
            if (audioSource.clip != driveClip)
            {
                audioSource.clip = driveClip;
                audioSource.Play();
            }

            // Check if the car has crossed the finish line
            if (transform.position.z >= 100f)
            {
                raceFinished = true;
                deceleration = currentSpeed / stopTime; // Calculate deceleration needed to stop in 2 seconds
            }
        }
        else if (raceFinished)
        {
            // Gradually decelerate the car
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, 0); // Ensure the speed doesn't go below 0
            // Move the car along the Z-axis
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

            // Play the braking sound if the car is still moving
            if (currentSpeed > 0 && audioSource.clip != brakeClip)
            {
                audioSource.clip = brakeClip;
                audioSource.Play();
            }
            // Play the idle sound once the car has stopped
            else if (currentSpeed == 0 && audioSource.clip != idleClip)
            {
                audioSource.clip = idleClip;
                audioSource.Play();
            }
        }
    }
}