using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearController : MonoBehaviour
{

    public float landingGearSpeed;

    public bool landingGearActivate = true;

    public Animator animator;

    public PolygonCollider2D polygonCollider2D;

    void Start()
    {
        animator.SetBool("LandingGearOff", landingGearActivate);
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LandingGearInputControl();
    }

    void LandingGearInputControl()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            landingGearActivate = !landingGearActivate;

            animator.SetBool("LandingGearOff", landingGearActivate);

            polygonCollider2D.enabled = landingGearActivate;

        }
        else
        {
            polygonCollider2D.enabled = landingGearActivate;
        }
    }
}
