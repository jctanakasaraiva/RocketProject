using System;
using UnityEngine;
using UnityEngine.UI;

public class NewRocketControl : MonoBehaviour
{
    public static NewRocketControl instance;
    public bool isAlive;
    public float thrusterInput;
    public float steeringInput;
    private float rotationAngle;
    [SerializeField] private float thrustMultiplier;
    public float rocketFuelValue = 100;
    public float rocketFuelMultiplier;
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
    [SerializeField] private VernierThrusterControl vernierThrusterControl;

    private void Awake() => instance = this;

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
        if (isAlive)
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
                rocketFuelValue = rocketFuelValue - rocketFuelMultiplier * Time.deltaTime;
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
    }

    private void ApplyRocketSteering()
    {
        if (thrusterInput > 0)
        {
            rotationAngle -= steeringInput * rotationSpeed;
            rocketRigidBody2D.MoveRotation(rotationAngle);
        }
        else
        {
            rotationAngle = rocketRigidBody2D.rotation;
            rocketRigidBody2D.MoveRotation(rotationAngle);
        }
    }

    private void ApplyRocketVernierThruster()
    {
        if (isAlive)
        {
            float fuelValue = vernierThrusterControl.vernierThrusterFuel;
            if (fuelValue > 0)
            {
                Vector2 vernierThruster = new Vector2(0, 0);
                if (Input.GetKey(KeyCode.E))
                {
                    vernierThruster = transform.right * -vernierThrusterMultiplier;
                    VernierThrusterSignal = vernierThruster.normalized.x;
                    vernierThrusterControl.EnableVernierThruster();
                }
                if (Input.GetKey(KeyCode.Q))
                {
                    vernierThruster = transform.right * vernierThrusterMultiplier;
                    VernierThrusterSignal = vernierThruster.normalized.x;
                    vernierThrusterControl.EnableVernierThruster();
                }
                if (Input.GetKey(KeyCode.Q) == false && Input.GetKey(KeyCode.E) == false)
                {
                    vernierThrusterControl.DisableVernierThruster();
                }
                rocketRigidBody2D.AddForce(vernierThruster, ForceMode2D.Force);
            }
            else
            {
                vernierThrusterControl.DisableVernierThruster();
            }
        }
    }

    private void SetInput()
    {
        if (isAlive)
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
