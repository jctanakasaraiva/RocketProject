using UnityEngine;

public class RocketSoundControl : MonoBehaviour
{
    [SerializeField] private TopDownRocketController topDownRocketController;
    [SerializeField] private AudioSource engineAudio;
    private float rocketAcceleration;

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
