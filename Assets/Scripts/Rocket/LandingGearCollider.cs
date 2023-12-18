using UnityEngine;

public class LandingGearCollider : MonoBehaviour
{
    public bool onPlatform;

    public float rechargeFuelMultiplier;

    [SerializeField] private RocketStatusControl rocketStatusControl;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        onPlatform = (collider.gameObject.tag == "Platform");
        if (collider.gameObject.tag != "Item" && onPlatform == false && rocketStatusControl.isDead == false)
        {
            RocketDestruction.instance.RocketExplosion();
        }

    }

    private void OnCollisionStay2D(Collision2D Collider)
    {
        if (Collider.gameObject.tag == "Platform")
        {
            if (NewRocketControl.instance.rocketFuelValue <= 100)
            {
                NewRocketControl.instance.rocketFuelValue += rechargeFuelMultiplier * Time.deltaTime;
            }
            if (VernierThrusterControl.instance.vernierThrusterFuel <= 100)
            {
                VernierThrusterControl.instance.vernierThrusterFuel += rechargeFuelMultiplier * Time.deltaTime;
            }

        }
    }
}
