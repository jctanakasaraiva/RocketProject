using UnityEngine;

public class TopDownRocketController : MonoBehaviour // TODO: Remove
{
    [Header("Rocket Settings")]
    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 4f;
    private float landingGearSpeed;
    public float accelerationInput = 0;
    private float steeringInput = 0;
    private float rotationAngle = 0;
    private float velocityVsUp = 0;
    public GameObject thruster;
    public Rigidbody2D rocketRigidBody2D;
    [SerializeField] private LandingGearController landingGearController;

    void FixedUpdate()
    {
        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    void updateLandingGearSpeed(){
        landingGearSpeed = landingGearController.LandingGearSpeed;
    }

    void ApplyEngineForce()
    {
        velocityVsUp = Vector2.Dot(transform.up, rocketRigidBody2D.velocity);
        if (velocityVsUp > maxSpeed && accelerationInput > 0)
        {
            return;
        }
        if (velocityVsUp < maxSpeed && accelerationInput < 0)
        {
            return;
        }
        if (accelerationInput == 0)
        {
            rocketRigidBody2D.drag = Mathf.Lerp(rocketRigidBody2D.drag, 1.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            rocketRigidBody2D.drag = -0;
        }

        Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor * landingGearSpeed;
        rocketRigidBody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor = (rocketRigidBody2D.velocity.magnitude / 8);
        minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);
        rotationAngle -= steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
        rocketRigidBody2D.MoveRotation(rotationAngle);
    }

    void KillOrthogonalVelocity()
    {
        Vector2 forwardVelocity = transform.up * Vector2.Dot(rocketRigidBody2D.velocity, transform.up);
        Vector2 rightVelocity = transform.right * Vector2.Dot(rocketRigidBody2D.velocity, transform.right);
        rocketRigidBody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput = inputVector.x;
        accelerationInput = inputVector.y;
        if (accelerationInput != 0)
        {
            thruster.SetActive(true);
        }
        else
        {
            thruster.SetActive(false);
        }
    }
}
