using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WheelRotationR : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of the wheel rotation

    void Update()
    {
        // Rotate the wheel around its local X axis
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}