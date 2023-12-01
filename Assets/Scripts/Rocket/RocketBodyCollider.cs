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

        if (collider.gameObject.tag == "Edges" && rocketStatusControl.isDead == false)
        {
            rocketDestruction.RocketExplosion();
        }
    }
}
