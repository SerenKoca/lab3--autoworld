using UnityEngine;

public class WheelRotatorT : MonoBehaviour
{
    public float rotationSpeedT = 100f; // Rotatiesnelheid in graden per seconde

    void Update()
    {
        // Laat het wiel roteren om de Z-as
        transform.Rotate(Vector3.forward * rotationSpeedT * Time.deltaTime);
    }
}
