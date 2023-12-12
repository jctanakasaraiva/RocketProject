using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestruction : MonoBehaviour
{
    public bool isAlive;

    [SerializeField] AudioSource explosionAudio;

    [SerializeField] private Rigidbody2D rocketRigidBody2D;

    [SerializeField] private SpriteRenderer rocketSpriteRenderer;
    [SerializeField] private SpriteRenderer thrusterSpriteRenderer;
    [SerializeField] private SpriteRenderer landingGearSpriteRenderer;
    [SerializeField] private SpriteRenderer explosionSpriteRenderer;

    [SerializeField] private Animator explosionAnimator;

    public void RocketExplosion()
    {
        if (isAlive)
        {
            isAlive = false;
            explosionAudio.Play();
            Vector2 deadVelocity = new Vector2(0f, 0f);
            rocketRigidBody2D.velocity = deadVelocity;
            explosionSpriteRenderer.enabled = true;
            explosionAnimator.enabled = true;
            rocketSpriteRenderer.enabled = false;
            thrusterSpriteRenderer.enabled = false;
            landingGearSpriteRenderer.enabled = false;
            Destroy(gameObject, 1f);
        }

    }
}
