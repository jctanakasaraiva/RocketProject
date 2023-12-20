
using UnityEngine;
using UnityEngine.UI;

public class RocketFuelControl : MonoBehaviour
{
    [SerializeField] private float rocketFuelValue;
    [SerializeField] private float rocketFuelMultiplier;

    void Update()
    {
        FuelUpdate();
    }

    public void FuelUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rocketFuelValue = rocketFuelValue - Time.deltaTime * rocketFuelMultiplier;
        }
    }
}
