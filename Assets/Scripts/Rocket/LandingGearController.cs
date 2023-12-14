using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearController : MonoBehaviour
{
    public bool landingGearActivate = true;

    public Animator animator;

    public PolygonCollider2D polygonCollider2D;

    [Range(0.1f, 1f)]
    public float landingGearFactor;

    void Start()
    {
        animator.SetBool("LandingGearOff", landingGearActivate);
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LandingGearInputControl();
        LandingGearSpeedUpdate();
    }

    void LandingGearInputControl()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            landingGearActivate = !landingGearActivate;

            animator.SetBool("LandingGearOff", landingGearActivate);

            polygonCollider2D.enabled = landingGearActivate;
        }
    }

    void LandingGearSpeedUpdate()
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
