using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Vector3 playerSpawnPosition = new Vector3(-0.4742927f, -8.06973f, 0);
    float TimerToInstance;
    public int totalScore;
    public Text scoreText;

    public int totalInstancedItems;

    public static GameController instance;

    public GameObject satellitePrefab;
    public GameObject playerPrefab;
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
            GameObject invokeItem = Instantiate(satellitePrefab);
            invokeItem.transform.position = new Vector3(Random.Range(-19, 19), Random.Range(-5, 9), 0);
            totalInstancedItems++;
            TimerToInstance = 2;
        }
    }

    void TimerToInstanceCountDown()
    {
        TimerToInstance -= Time.deltaTime;
    }

    void InstanceNewPlayer()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameObject invokePlayer = Instantiate(playerPrefab);
            invokePlayer.transform.position = playerSpawnPosition; // new Vector3(-0.4742927f, -8.06973f, 0);
        }
    }
}
