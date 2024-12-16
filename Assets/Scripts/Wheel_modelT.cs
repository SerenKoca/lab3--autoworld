using UnityEngine;

public class WheelRotatorT : MonoBehaviour
{
    public float rotationMultiplier = 10f; // Multiplier to adjust rotation speed based on car speed
    private ModelTMovement modelTMovement; // Reference to the car's movement script

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
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }
    }
}