using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    [SerializeField] NewRocketControl newRocketControl;

    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] AudioSource engineAudio;

    //private float thrusterInput;

    // Update is called once per frame
    void Update()
    {
        //SetThruster();
        //PlayThrusterSound();
    }

    public void SetThruster(float thrusterInput)
    {
        //thrusterInput = newRocketControl.thrusterInput;
        if (thrusterInput > 0)
        {
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
    /*
        void PlayThrusterSound(){
            if (thrusterInput > 0.5 && engineAudio.isPlaying == false)
            {
                engineAudio.Play();
            }
            if (thrusterInput <= 0.5 && engineAudio.isPlaying == true)
            {
                engineAudio.Stop();
            }
        }
        */
}
