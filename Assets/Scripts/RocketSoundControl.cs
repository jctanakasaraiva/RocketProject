using UnityEngine;

public class RocketSoundControl : MonoBehaviour
{
    [SerializeField] private TopDownRocketController topDownRocketController;
    public AudioSource engineAudio;


    private float rocketAcceleration;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayEngineAudio();
    }

    public void PlayEngineAudio()
    {
        rocketAcceleration = topDownRocketController.accelerationInput;

        if (rocketAcceleration > 0.5 && engineAudio.isPlaying == false)
        {
            engineAudio.Play();
        }

        if (rocketAcceleration <= 0.5 && engineAudio.isPlaying == true)
        {
            engineAudio.Stop();
        }

    }
}
