using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Satellite : MonoBehaviour
{

    public int score;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;
    public GameObject destructionAnimation;
    public AudioSource collectedAudio;

    public float satelliteCountdownTimer;

    bool itemDead;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        itemDead = false;
    }

    void Update()
    {
        SatelliteTimer();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectedAudio.Play();
            GameController.instance.totalScore += score;
            destroySatellite();
        }
    }

    void SatelliteTimer()
    {
        if (satelliteCountdownTimer >= 0)
        {
            satelliteCountdownTimer -= Time.deltaTime;
        }
        else
        {
            destroySatellite();
        }
    }

    void destroySatellite()
    {
        destructionAnimation.SetActive(true);
        spriteRenderer.enabled = false;
        capsuleCollider2D.enabled = false;
        Destroy(gameObject, 2f);
        if (itemDead == false)
        {
            GameController.instance.totalInstancedItems -= 1;
            itemDead = true;
        }
    }
}
