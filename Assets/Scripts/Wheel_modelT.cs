using UnityEngine;

public class WheelRotatorT : MonoBehaviour
{
    public float rotationMultiplier = 10f; // Multiplier to adjust rotation speed based on car speed
    private ModelTMovement modelTMovement; // Reference to the car's movement script
    public float minimumRotationSpeed = 100f; // Minimum rotation speed

    void Start()
    {
        // Get the ModelTMovement component from the parent or the same GameObject
        modelTMovement = GetComponentInParent<ModelTMovement>();
    }

    void Update()
    {
        if (RaceStarter.raceStarted && modelTMovement != null) // Check if the race has started
        {
            // Rotate the wheel based on the car's current speed
            float rotationSpeed = modelTMovement.currentSpeed * rotationMultiplier;
            rotationSpeed = Mathf.Max(rotationSpeed, minimumRotationSpeed); // Ensure minimum rotation speed
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}