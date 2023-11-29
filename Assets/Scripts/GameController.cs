using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float TimerToInstance;
    public int totalScore;
    public Text scoreText;

    public int totalInstancedItems;

    public static GameController instance;

    public GameObject satellite;
    public GameObject player;
    void Start()
    {
        instance = this;
        TimerToInstance = 0;
    }

    void Update()
    {
        RandomInstanceItems();
        TimerToInstanceCountDown();
        InstanceNewPlayer();
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    void RandomInstanceItems()
    {
        if (totalInstancedItems < 0 & TimerToInstance <= 0)
        {
            GameObject invokeItem = Instantiate(satellite);
            invokeItem.transform.position = new Vector3(Random.Range(-19, 19), Random.Range(-5, 9), 0);
            totalInstancedItems++;
            TimerToInstance = 2;
        }
    }

    void TimerToInstanceCountDown(){
        TimerToInstance -= Time.deltaTime;
    }

    void InstanceNewPlayer(){
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject invokePlayer = Instantiate(player);
            invokePlayer.transform.position = new Vector3(-0.4742927f, -8.06973f, 0);
        }
    }
}
