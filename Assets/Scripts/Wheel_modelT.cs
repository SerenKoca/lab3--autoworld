using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public float rotationSpeed = 100f; // Rotatiesnelheid in graden per seconde

    void Update()
    {
        // Laat het wiel roteren om de Y-as
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
