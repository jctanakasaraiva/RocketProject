
using Unity.Mathematics;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    [SerializeField] NewRocketControl newRocketControl;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] AudioSource engineAudio;

    [SerializeField] float thrusterAngle;
    [SerializeField] float thrusterXPosition;

    public void SetThruster(float thrusterInput)
    {
        if (thrusterInput >= 0)
        {

            if (newRocketControl.steeringInput > 0)
            {
                transform.localPosition = new Vector3(thrusterXPosition, transform.localPosition.y, transform.localPosition.z);
                transform.localRotation = Quaternion.Euler(0, 0, thrusterAngle);
            }
            if (newRocketControl.steeringInput < 0)
            {
                transform.localPosition = new Vector3(-thrusterXPosition, transform.localPosition.y, transform.localPosition.z);
                transform.localRotation = Quaternion.Euler(0, 0, -thrusterAngle);
            }
            if (newRocketControl.steeringInput == 0)
            {
                transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            spriteRenderer.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = false;
        }

        if (thrusterInput > 0.5 && engineAudio.isPlaying == false)
        {
            engineAudio.Play();
        }
        if (thrusterInput <= 0.5 && engineAudio.isPlaying == true)
        {
            engineAudio.Stop();
        }
    }
}
