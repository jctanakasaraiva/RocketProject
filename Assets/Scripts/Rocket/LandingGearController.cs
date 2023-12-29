using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearController : MonoBehaviour
{
    [SerializeField] private bool landingGearActivate = true;

    [SerializeField] private Animator animator;

    [SerializeField] private PolygonCollider2D polygonCollider2D;

    [SerializeField] private AudioSource landingGearSound;

    [Range(0.1f, 1f)]
    [SerializeField] private float landingGearFactor;

    [SerializeField] private float landingGearSpeed;
    public float LandingGearSpeed => landingGearSpeed;

    private void Start()
    {
        animator.SetBool("LandingGearOff", landingGearActivate);
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        LandingGearInputControl();
        LandingGearSpeedUpdate();
    }

    private void LandingGearInputControl()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            landingGearActivate = !landingGearActivate;

            landingGearSound.Play();

            animator.SetBool("LandingGearOff", landingGearActivate);

            polygonCollider2D.enabled = landingGearActivate;
        }
    }

    private void LandingGearSpeedUpdate()
    {
        if (landingGearActivate)
        {
            landingGearSpeed = landingGearFactor;
        }
        else
        {
            landingGearSpeed = 1f;
        }
    }
}
