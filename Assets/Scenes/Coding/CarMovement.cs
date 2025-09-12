using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float accelerationFactor = 20.0f;
    public float turnFactor = 1.0f;
    public float boostMultiplier = 2.0f;   // Speed boost when Shift is held
    public float maxSpeed = 10.0f;         // Normal top speed
    public float maxBoostedSpeed = 18.0f;  // Top speed while boosting

    float accelerationInput = 0f;
    float steeringInput = 0f;
    float rotationAngle = 0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyEngineForce();
        ApplySteering();
    }

    void ApplyEngineForce()
    {
        // Base acceleration
        float currentAcceleration = accelerationInput * accelerationFactor;

        // Boost with Shift
        float currentMaxSpeed = maxSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentAcceleration *= boostMultiplier;
            currentMaxSpeed = maxBoostedSpeed;
        }

        // Apply force only if under max speed
        if (rb.linearVelocity.magnitude < currentMaxSpeed)
        {
            Vector2 engineForceVector = transform.up * currentAcceleration;
            rb.AddForce(engineForceVector, ForceMode2D.Force);
        }
    }

    void ApplySteering()
    {
        rotationAngle += steeringInput * turnFactor;
        rb.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;     // Left / Right
        accelerationInput = inputVector.y; // Forward / Back
    }
}
