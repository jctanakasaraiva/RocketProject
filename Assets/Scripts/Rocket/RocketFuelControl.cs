
using UnityEngine;
using UnityEngine.UI;

public class RocketFuelControl : MonoBehaviour
{
    [SerializeField] private float rocketFuelValue;
    [SerializeField] private float rocketFuelMultiplier;
    public Slider slider; // TODO: Remove

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
