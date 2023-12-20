using UnityEngine;

public class RocketSoundControl : MonoBehaviour
{
    [SerializeField] private AudioSource engineAudio;
    private float rocketAcceleration;

    // Update is called once per frame
    void Update()
    {
        PlayEngineAudio();
    }

    public void PlayEngineAudio()
    {
        rocketAcceleration = NewRocketControl.instance.SteeringInput;
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
