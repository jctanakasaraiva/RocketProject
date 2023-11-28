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
    void Start()
    {
        instance = this;
        TimerToInstance = 0;
    }

    void Update()
    {
        RandomInstanceItems();
        TimerToInstanceCountDown();
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


}
