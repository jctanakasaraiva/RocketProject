using System;
using UnityEngine;
using UnityEngine.UI;

public class NewRocketControl : MonoBehaviour
{
    public float thrusterInput;
    private float steeringInput;
    private float rotationAngle;

    //private float vernierFuel = 100f;

    [SerializeField] private float thrustMultiplier;
    public float reverseThrustMultiplier;
    public float vernierThrusterMultiplier;

    private float rocketUpVelocity;
    private float rocketRightVelocity;

    public float rocketVerticalMaxSpeed;
    public float rocketHorizontalMaxSpeed;

    public float rotationSpeed;

    public float rocketAngleValue;

    public float dragValue;
    public float dragTime;

    public float VernierThrusterSignal;

    [SerializeField] private Rigidbody2D rocketRigidBody2D;

    [SerializeField] private LandingGearController landingGearController;

    [SerializeField] private RocketDestruction rocketDestruction;

    [SerializeField] private ThrusterController thrusterController;

    private void FixedUpdate()
    {
        SetInput();
        ApplyRocketThrust();
        ApplyRocketSteering();
        ApplyRocketVernierThruster();
        UpdateScreenRocketAngle();
    }

    private void ApplyRocketThrust()
    {
        rocketUpVelocity = Vector2.Dot(transform.up, rocketRigidBody2D.velocity);
        if (rocketUpVelocity > rocketVerticalMaxSpeed && thrusterInput > 0)
        {
            return;
        }
        if (rocketRightVelocity > rocketHorizontalMaxSpeed && thrusterInput > 0)
        {
            rocketRightVelocity = rocketHorizontalMaxSpeed;
            return;
        }
        rocketRightVelocity = Vector2.Dot(transform.right, rocketRigidBody2D.velocity);
        Vector2 thrustForce = new Vector2(0, 0);
        float landingGearSpeed = landingGearController.landingGearSpeed;
        if (thrusterInput > 0)
        {
            thrustForce = transform.up * thrustMultiplier * thrusterInput * landingGearSpeed;
        }
        if (thrusterInput < 0)
        {
            thrustForce = transform.up * reverseThrustMultiplier * thrusterInput * landingGearSpeed;
        }
        if (thrusterInput == 0)
        {
            rocketRigidBody2D.drag = Mathf.Lerp(rocketRigidBody2D.drag, dragValue, Time.fixedDeltaTime * dragValue);
        }
        else
        {
            rocketRigidBody2D.drag = 0;
        }

        rocketRigidBody2D.AddForce(thrustForce, ForceMode2D.Force);
    }

    private void ApplyRocketSteering()
    {
        rotationAngle -= steeringInput * rotationSpeed;
        rocketRigidBody2D.MoveRotation(rotationAngle);
    }

    private void ApplyRocketVernierThruster()
    {
        Vector2 vernierThruster = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.E))
        {
            vernierThruster = transform.right * -vernierThrusterMultiplier;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            vernierThruster = transform.right * vernierThrusterMultiplier;
        }
        VernierThrusterSignal = vernierThruster.normalized.x;
        rocketRigidBody2D.AddForce(vernierThruster, ForceMode2D.Force);
    }

    private void SetInput()
    {
        if (rocketDestruction.isAlive)
        {
            thrusterInput = Input.GetAxis("Vertical");
            steeringInput = Input.GetAxis("Horizontal");
            thrusterController.SetThruster(thrusterInput);
        }
    }

    private void UpdateScreenRocketAngle()
    {
        int rocketAngle = (int)transform.rotation.eulerAngles.z;
        if (rocketAngle < 180)
        {
            GameController.instance.rocketAngle = -rocketAngle;
        }
        else
        {
            GameController.instance.rocketAngle = 360 - rocketAngle;
        }

    }
}
