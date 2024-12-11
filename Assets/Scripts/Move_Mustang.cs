using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MustangMovement : MonoBehaviour
{
    public float acceleration = 3.12f; // Acceleration in meters per second squared
    public float topSpeed = 50.28f; // Top speed in meters per second (181 km/h)
    private float currentSpeed = 0f; // Current speed of the car

    void Update()
    {
        // Calculate the new speed
        currentSpeed += acceleration * Time.deltaTime;

        // Clamp the speed to the top speed
        currentSpeed = Mathf.Clamp(currentSpeed, 0, topSpeed);

        // Move the car along the Z-axis
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}