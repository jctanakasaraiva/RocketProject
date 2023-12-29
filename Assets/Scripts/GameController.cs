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

    private void Start()
    {
        instance = this;
        TimerToInstance = 0;
    }

    private void Update()
    {
        RandomInstanceItems();
        TimerToInstanceCountDown();
        InstanceNewPlayer();
        UpdateRocketAngle();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    private void UpdateRocketAngle()
    {
        rocketAngleText.text = rocketAngle.ToString();
    }

    private void RandomInstanceItems()
    {
        if (totalInstancedItems < 1 & TimerToInstance <= 0)
        {
            GameObject invokeItem = Instantiate(satellitePrefab);
            invokeItem.transform.position = new Vector3(Random.Range(-19, 19), Random.Range(-5, 9), 0);
            totalInstancedItems++;
            TimerToInstance = 2;
        }
    }

    private void TimerToInstanceCountDown()
    {
        TimerToInstance -= Time.deltaTime;
    }

    private void InstanceNewPlayer()
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
