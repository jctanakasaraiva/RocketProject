using UnityEngine;

public class LandingGearCollider : MonoBehaviour
{
    public bool onPlatform;

    [SerializeField] private RocketStatusControl rocketStatusControl;

    private void OnCollisionEnter2D(Collision2D collider)
    {
        onPlatform = (collider.gameObject.tag == "Platform");

        if (collider.gameObject.tag != "Item" && onPlatform == false && rocketStatusControl.isDead == false)
        {
            RocketDestruction.instance.RocketExplosion();
        }

        if (collider.gameObject.tag == "Platform")
        {
            NewRocketControl.instance.rocketFuelValue = 100f;
            VernierThrusterControl.instance.vernierThrusterFuel = 100f;
        }
    }
}
