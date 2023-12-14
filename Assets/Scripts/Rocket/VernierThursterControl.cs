using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class VernierThursterControl : MonoBehaviour
{
    [SerializeField] NewRocketControl newRocketControl;

    [SerializeField] AudioSource vernierThrusterSound;


    [SerializeField] SpriteRenderer vernierThrusterSpriteRenderer;

    private void Update()
    {
        EnableVernierThruster();
    }

    private void EnableVernierThruster()
    {
        if (newRocketControl.VernierThrusterSignal == 0)
        {
            vernierThrusterSpriteRenderer.enabled = false;
            vernierThrusterSound.Stop();
        }
        else
        {
            vernierThrusterSpriteRenderer.enabled = true;
            if (vernierThrusterSound.isPlaying == false)
            {
                vernierThrusterSound.Play();
            }
        }

        if (newRocketControl.VernierThrusterSignal < 0 && vernierThrusterSpriteRenderer.flipX == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
            vernierThrusterSpriteRenderer.flipX = true;
        }
        if (newRocketControl.VernierThrusterSignal > 0 && vernierThrusterSpriteRenderer.flipX == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
            vernierThrusterSpriteRenderer.flipX = false;
        }
    }

}
