using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    [SerializeField] private int score;
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;
    [SerializeField] private GameObject destructionAnimation;
    [SerializeField] private AudioSource collectedAudio;

    [SerializeField] private float satelliteCountdownTimer;

    bool itemDead;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        itemDead = false;
    }

    private void Update()
    {
        SatelliteTimer();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collectedAudio.Play();
            GameController.instance.totalScore += score;
            destroySatellite();
        }
    }

    private void SatelliteTimer()
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

    private void DestroySatellite()
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
