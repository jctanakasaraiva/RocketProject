using UnityEngine;

public class RocketInputHandler : MonoBehaviour
{
    TopDownRocketController topDownRocketController;

    void Awake()
    {
        topDownRocketController = GetComponent<TopDownRocketController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        topDownRocketController.SetInputVector(inputVector);
    }

}
