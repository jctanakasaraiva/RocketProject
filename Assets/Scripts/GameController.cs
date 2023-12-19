using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private float TimerToInstance;
    public int totalScore; // TODO: Decouple
    [SerializeField] private Text scoreText;
    public int rocketAngle; // TODO: Decouple
    [SerializeField] private Text rocketAngleText;
    public Text rocketFuelText; //TODO: Remove
    public float rocketVernierFuel; //TODO: Remove
    public int totalInstancedItems; //TODO: Decouple
    [SerializeField] private GameObject satellitePrefab;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform platformTransform;
    private Vector3 playerSpawnPosition;

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
        UpdateRocketAngle();
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    void UpdateRocketAngle()
    {
        rocketAngleText.text = rocketAngle.ToString();
    }

    void RandomInstanceItems()
    {
        if (totalInstancedItems < 1 & TimerToInstance <= 0)
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
            playerSpawnPosition = new Vector3(0, platformTransform.position.y + 2.13f, 0);
            NewRocketControl.instance.rocketFuelValue = 100;
            GameObject invokePlayer = Instantiate(playerPrefab);
            invokePlayer.transform.position = playerSpawnPosition;
        }
    }
}
