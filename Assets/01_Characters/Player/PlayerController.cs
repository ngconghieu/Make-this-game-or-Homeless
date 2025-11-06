using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputProvider input;
    public Vector2 MoveInput;

    private void Start()
    {
        input = ServiceLocator.Get<IInputProvider>();
    }

    private void Update()
    {
        MoveInput = input.MoveInput;

        if (input.HasJumpBuffer)
        {
            Debug.Log("Jump Buffer Consumed");
            input.ConsumeJumpBuffer();
        }

        if (input.HasDashBuffer)
        {
            Debug.Log("Dash Buffer Consumed");
            input.ConsumeDashBuffer();
        }
    }

}