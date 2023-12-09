using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterController : MonoBehaviour
{
    [SerializeField] NewRocketControl newRocketControl;

    [SerializeField] SpriteRenderer spriteRenderer;

    private float thrusterInput;

    [SerializeField] AudioSource engineAudio;

    // Update is called once per frame
    void Update()
    {
        SetInputVector();
        PlayThrusterSound();
    }

    void SetInputVector()
    {
        thrusterInput = newRocketControl.thrusterInput;
        if (thrusterInput != 0)
        {
            spriteRenderer.enabled = true;

        }
        else
        {
            spriteRenderer.enabled = false;
        }
    }

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
}
