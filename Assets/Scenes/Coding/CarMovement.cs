using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float accelerationFactor = 10.0f;  
    public float turnFactor = 6.0f;           
    public float boostMultiplier = 1.8f;      
    public float maxSpeed = 12.0f;            
    public float maxBoostedSpeed = 20.0f;     
    public float drift = 0.5f;                

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
        KillOrthogonalVelocity();
    }

    void ApplyEngineForce()
    {
        if (accelerationInput == 0)
        {
            rb.linearDamping = Mathf.Lerp(rb.linearDamping, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            rb.linearDamping = 0;
        }
            float currentAcceleration = accelerationInput * accelerationFactor;

        float currentMaxSpeed = maxSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentAcceleration *= boostMultiplier;
            currentMaxSpeed = maxBoostedSpeed;
        }

        if (rb.linearVelocity.magnitude < currentMaxSpeed)
        {
            Vector2 engineForceVector = transform.up * currentAcceleration;
            rb.AddForce(engineForceVector, ForceMode2D.Force);
        }
    }

    void ApplySteering()
    {
        float speedFactor = rb.linearVelocity.magnitude / 8f;
        speedFactor = Mathf.Clamp01(speedFactor);

        rotationAngle += steeringInput * turnFactor * speedFactor;
        rb.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;     
        accelerationInput = inputVector.y; 
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rb.linearVelocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);

        rb.linearVelocity = forwardVelocity + rightVelocity * drift;
    }
}
