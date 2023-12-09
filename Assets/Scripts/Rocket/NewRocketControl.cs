using System;
using UnityEngine;
using UnityEngine.UI;

public class NewRocketControl : MonoBehaviour
{
    public float thrusterInput;
    private float steeringInput;
    private float rotationAngle;

    private float rocketFuel = 100f;
    private float vernierFuel = 100f;

    [SerializeField] private Text screenRocketAngle;

    public float thrustMultiplier;
    public float reverseThrustMultiplier;
    public float vernierThrusterMultiplier;

    private float rocketUpVelocity;

    public float RocketVerticalMaxSpeed;
    public float RocketHorizontalMaxSpeed;

    public float rotationSpeed;

    public float dragValue;
    public float dragTime;

    [SerializeField] private Rigidbody2D rocketRigidBody2D;

    [SerializeField] private LandingGearController landingGearController;

    void Update()
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
        if (rocketUpVelocity > RocketVerticalMaxSpeed && thrusterInput > 0)
        {
            return;
        }
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
        if (Input.GetKey(KeyCode.Q))
        {
            vernierThruster = transform.right * -vernierThrusterMultiplier;
        }
        if (Input.GetKey(KeyCode.E))
        {
            vernierThruster = transform.right * vernierThrusterMultiplier;
        }
        rocketRigidBody2D.AddForce(vernierThruster, ForceMode2D.Force);
    }

    private void SetInput()
    {
        thrusterInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
    }

    private void UpdateScreenRocketAngle()
    {
        int rocketAngle = (int)transform.rotation.eulerAngles.z;
        if (rocketAngle < 180)
        {
            screenRocketAngle.text = (-rocketAngle).ToString() + "°";
        }
        else
        {
            screenRocketAngle.text = (360 - rocketAngle).ToString() + "°";
        }
    }
}
