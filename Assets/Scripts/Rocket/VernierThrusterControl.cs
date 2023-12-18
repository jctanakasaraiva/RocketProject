using UnityEngine;

public class VernierThrusterControl : MonoBehaviour
{
    public static VernierThrusterControl instance;
    [SerializeField] NewRocketControl newRocketControl;
    [SerializeField] AudioSource vernierThrusterSound;
    [SerializeField] SpriteRenderer vernierThrusterSpriteRenderer;
    [SerializeField] public float vernierThrusterFuel = 100;
    [SerializeField] public float vernierThrusterMultiplier;

    private void Awake() => instance = this;

    public void EnableVernierThruster()
    {
        if (newRocketControl.VernierThrusterSignal < 0 && vernierThrusterSpriteRenderer.flipX == false)
        {
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
            vernierThrusterSpriteRenderer.flipX = true;
        }
        if (newRocketControl.VernierThrusterSignal > 0 && vernierThrusterSpriteRenderer.flipX == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x * -1, transform.localPosition.y, transform.localPosition.z);
            vernierThrusterSpriteRenderer.flipX = false;
        }
        if (vernierThrusterSound.isPlaying == false)
        {
            vernierThrusterSound.Play();
        }
        vernierThrusterFuel -= vernierThrusterMultiplier * Time.deltaTime;
        vernierThrusterSpriteRenderer.enabled = true;

    }

    public void DisableVernierThruster()
    {
        vernierThrusterSpriteRenderer.enabled = false;
        vernierThrusterSound.Stop();
    }
}
