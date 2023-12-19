using UnityEngine;
using UnityEngine.UI;

public class VernierBarController : MonoBehaviour
{
    [SerializeField] private Image vernierBarFill;
    [SerializeField] private float vernierBarValue;
    [SerializeField] private Gradient gradient;

    void Update()
    {
        UpdateVernierBar();
    }

    public void UpdateVernierBar()
    {
        vernierBarValue = VernierThrusterControl.instance.vernierThrusterFuel;
        if (vernierBarValue >= 0 && vernierBarValue <= 100)
        {
            Vector3 vernierBarScale = vernierBarFill.rectTransform.localScale;
            vernierBarScale.y = vernierBarValue / 100;
            vernierBarFill.rectTransform.localScale = vernierBarScale;
        }
        vernierBarFill.color = gradient.Evaluate(vernierBarValue / 100);
    }
}
