using UnityEngine;

public class WheelRotator40 : MonoBehaviour
{
    public float rotationMultiplier = 10f; // Multiplier to adjust rotation speed based on car speed
    private Model40Movement model40Movement; // Reference to the car's movement script
    public float minimumRotationSpeed = 100f; // Minimum rotation speed

    void Start()
    {
        // Get the Model40Movement component from the parent or the same GameObject
        model40Movement = GetComponentInParent<Model40Movement>();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && model40Movement != null) // Check if the race has started
        {
            // Rotate the wheel based on the car's current speed
            float rotationSpeed = model40Movement.currentSpeed * rotationMultiplier;
            rotationSpeed = Mathf.Max(rotationSpeed, minimumRotationSpeed); // Ensure minimum rotation speed
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // Change to Vector3.forward for Z-axis rotation
        }
    }
}