using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    [SerializeField] private GameObject waves;
    [SerializeField] private float parallaxSpeed;
    private float length;
    private float actualPosition;

    private bool instantiateWave = false;

    private void Start()
    {
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        MoveParallax();
    }

    private void MoveParallax()
    {
        actualPosition = transform.position.x;
        if (instantiateWave == false)
        {
            if (actualPosition <= 0)
            {
                instantiateWave = true;
                GameObject temporaryWave = Instantiate(waves);
                temporaryWave.transform.position = new Vector3(transform.position.x + length - 0.3f, transform.position.y, 0);
            }
        }
        if(actualPosition <= length * -1){
            Destroy(this.gameObject);
        }
        transform.position = new Vector3(actualPosition + parallaxSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}
