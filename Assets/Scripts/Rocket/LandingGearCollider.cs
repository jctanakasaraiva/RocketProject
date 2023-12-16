using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearCollider : MonoBehaviour
{
    public bool onPlatform;

    [SerializeField] private RocketStatusControl rocketStatusControl;
    [SerializeField] private RocketDestruction rocketDestruction;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        onPlatform = (collider.gameObject.tag == "Platform");

        if (collider.gameObject.tag != "Item" && onPlatform == false && rocketStatusControl.isDead == false)
        {
            rocketDestruction.RocketExplosion();
        }
    }
}
