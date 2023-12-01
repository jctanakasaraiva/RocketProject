using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingGearCollider : MonoBehaviour
{
    public bool onPlatform;

    private void OnCollisionEnter2D(Collision2D collider) {
        onPlatform = (collider.gameObject.tag == "Platform");
    }
}
