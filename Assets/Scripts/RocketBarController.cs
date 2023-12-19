using UnityEngine;
using UnityEngine.UI;

public class RocketBarController : MonoBehaviour
{
    [SerializeField] private Image rocketFuelBarFill;
    [SerializeField] private float rocketBarValue;
    [SerializeField] private AudioSource FuelAlertSound;
    [SerializeField] private Gradient gradient;

    void Update()
    {
        UpdateFuelBar();
    }

    public void UpdateFuelBar()
    {
        rocketBarValue = NewRocketControl.instance.rocketFuelValue;
        if (rocketBarValue >= 0 && rocketBarValue <= 100)
        {
            Vector3 vernierBarScale = rocketFuelBarFill.rectTransform.localScale;
            vernierBarScale.y = rocketBarValue / 100;
            rocketFuelBarFill.rectTransform.localScale = vernierBarScale;
        }
        if (rocketBarValue <= 30 && FuelAlertSound.isPlaying == false)
        {
            FuelAlertSound.Play();
        }
        if (rocketBarValue > 30 && FuelAlertSound.isPlaying)
        {
            FuelAlertSound.Stop();
        }
        if (rocketBarValue <= 0)
        {
            RocketDestruction.instance.RocketExplosion();
        }
        rocketFuelBarFill.color = gradient.Evaluate(rocketBarValue / 100);
    }
}
