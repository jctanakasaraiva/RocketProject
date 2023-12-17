using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestruction : MonoBehaviour
{
    public static RocketDestruction instance;

    [SerializeField] AudioSource explosionAudio;
    [SerializeField] private Rigidbody2D rocketRigidBody2D;
    [SerializeField] private SpriteRenderer rocketSpriteRenderer;
    [SerializeField] private SpriteRenderer thrusterSpriteRenderer;
    [SerializeField] private SpriteRenderer landingGearSpriteRenderer;
    [SerializeField] private SpriteRenderer explosionSpriteRenderer;
    [SerializeField] private Animator explosionAnimator;

    private void Awake() => instance = this;

    public void RocketExplosion()
    {
        if (NewRocketControl.instance.isAlive)
        {
            NewRocketControl.instance.isAlive = false;
            explosionAudio.Play();
            Vector2 deadVelocity = new Vector2(0f, 0f);
            rocketRigidBody2D.velocity = deadVelocity;
            explosionSpriteRenderer.enabled = true;
            explosionAnimator.enabled = true;
            rocketSpriteRenderer.enabled = false;
            thrusterSpriteRenderer.enabled = false;
            landingGearSpriteRenderer.enabled = false;
            GameController.instance.totalScore = 0;
            NewRocketControl.instance.rocketFuelValue = 100;
            VernierThrusterControl.instance.vernierThrusterFuel = 100;
            Destroy(gameObject, 1f);

        }

    }
}
