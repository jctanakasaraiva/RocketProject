using UnityEngine;

public class TopDownRocketController : MonoBehaviour
{
    [Header("Rocket Settings")]

    public float driftFactor = 0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor = 3.5f;
    public float maxSpeed = 4f;
    [Range(0.1f, 1f)]
    public float landingGearFactor;

    private float landingGearSpeed;

    float accelerationInput = 0;
    float steeringInput = 0;
    float rotationAngle = 0;

    float velocityVsUp = 0;

    public GameObject thruster;
    public GameObject ExplosionAnimation;

    public AudioSource engineAudio;
    public AudioSource explosionAudio;

    bool isDead = false;

    Rigidbody2D rocketRigidBody2D;

    [SerializeField] private LandingGearController landingGearController;
    [SerializeField] GameObject rocketExplosion;

    void Awake()
    {
        rocketRigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayEngineAudio();
    }

    void FixedUpdate()
    {
        LandingGearForce();

        ApplyEngineForce();

        KillOrthogonalVelocity();

        ApplySteering();
    }

    void LandingGearForce()
    {
        if (landingGearController.landingGearActivate)
        {
            landingGearSpeed = landingGearFactor;
        }
        else
        {
            landingGearSpeed = 1f;
        }
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

    public void PlayEngineAudio()
    {

        if (accelerationInput > 0.5 && engineAudio.isPlaying == false)
        {
            engineAudio.Play();
        }

        if (accelerationInput <= 0.5 && engineAudio.isPlaying == true)
        {
            engineAudio.Stop();
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Sea" && isDead == false)
        {
            Vector2 deadVelocity = new Vector2(0f, 0f);
            isDead = true;

            explosionAudio.Play();
            rocketRigidBody2D.velocity = deadVelocity;
            rocketExplosion.GetComponent<SpriteRenderer>().enabled = true;
            //ExplosionAnimation.SetActive(true);
            rocketExplosion.GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 1f);
            Debug.Log("Teste");
        }

    }


}
