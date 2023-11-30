using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDestruction : MonoBehaviour
{
    bool isDead = false;

    public AudioSource explosionAudio;

    public Rigidbody2D rocketRigidBody2D;

    public SpriteRenderer rocketSpriteRenderer;
    public SpriteRenderer thrusterSpriteRenderer;
    public SpriteRenderer landingGearSpriteRenderer;
    public SpriteRenderer explosionSpriteRenderer;

    public Animator explosionAnimator;

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Sea" && isDead == false)
        {
            RocketExplosion();
        }
    }

    void RocketExplosion()
    {
        Vector2 deadVelocity = new Vector2(0f, 0f);
        isDead = true;
        explosionAudio.Play();
        rocketRigidBody2D.velocity = deadVelocity;
        explosionSpriteRenderer.enabled = true;
        explosionAnimator.enabled = true;
        rocketSpriteRenderer.enabled = false;
        thrusterSpriteRenderer.enabled = false;
        landingGearSpriteRenderer.enabled = false;
        Destroy(gameObject, 1f);
    }
}
