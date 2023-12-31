using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBodyCollider : MonoBehaviour
{
    [SerializeField] private RocketStatusControl rocketStatusControl;
    [SerializeField] private RocketDestruction rocketDestruction;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Item" && rocketStatusControl.isDead == false)
        {
            rocketDestruction.RocketExplosion();
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag != "Item" && rocketStatusControl.isDead == false)
        {
            rocketDestruction.RocketExplosion();
        }
    }
}
