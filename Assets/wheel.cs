using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider frontLeftWheel;
    public WheelCollider frontRightWheel;
    public WheelCollider rearLeftWheel;
    public WheelCollider rearRightWheel;

    public Transform frontLeftTransform;
    public Transform frontRightTransform;
    public Transform rearLeftTransform;
    public Transform rearRightTransform;

    public float maxSteerAngle = 30f;
    public float motorForce = 500f;

    void FixedUpdate()
    {
        // Besturing
        float steer = Input.GetAxis("Horizontal") * maxSteerAngle;
        frontLeftWheel.steerAngle = steer;
        frontRightWheel.steerAngle = steer;

        // Gas geven
        float throttle = Input.GetAxis("Vertical") * motorForce;
        rearLeftWheel.motorTorque = throttle;
        rearRightWheel.motorTorque = throttle;

        // Update de wielposities
        UpdateWheel(frontLeftWheel, frontLeftTransform);
        UpdateWheel(frontRightWheel, frontRightTransform);
        UpdateWheel(rearLeftWheel, rearLeftTransform);
        UpdateWheel(rearRightWheel, rearRightTransform);
    }

    void UpdateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        transform.position = position;
        transform.rotation = rotation;
    }
}
