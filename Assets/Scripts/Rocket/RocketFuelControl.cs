
using UnityEngine;
using UnityEngine.UI;

public class RocketFuelControl : MonoBehaviour
{
    public float rocketFuelValue;
    public float rocketFuelMultiplier;
    public Slider slider;

    void Update()
    {
        FuelUpdate();
    }

    public void FuelUpdate()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rocketFuelValue = rocketFuelValue - Time.deltaTime * rocketFuelMultiplier;
            RocketFuelSliderUpdate();
        }

    }

    public void RocketFuelSliderUpdate()
    {
        slider.value = rocketFuelValue;
    }
}
