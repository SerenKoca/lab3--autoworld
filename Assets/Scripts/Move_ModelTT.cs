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

    void Update()
    {
        // Calculate the new speed, ensuring it does not exceed maxSpeed
        currentSpeed += acceleration * Time.deltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        // Move the object along the Z-axis based on the current speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}

