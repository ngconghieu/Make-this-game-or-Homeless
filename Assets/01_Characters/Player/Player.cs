using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    [SerializeField][AutoAssign] protected Rigidbody2D rb;
    [SerializeField][AutoAssign] protected BoxCollider2D boxCollider;
    [SerializeField][AutoAssign] protected Animator animator;

    IInputProvider input;
    PlayerContext ctx = new();
    StateMachine machine;
    State root;

    private void Awake()
    {
        // HSM
        root = new PlayerRoot(null, ctx);
        var builder = new StateMachineBuilder(root);
        machine = builder.Build();
    }

    private void Start()
    {
        input = ServiceLocator.Get<IInputProvider>();
    }

    private void Update()
    {
        if (input != null) ctx.input = input;

        // input buffer consumption example
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

        machine.Tick(Time.deltaTime);
    }

}

[Serializable]
public class PlayerContext
{
    public Rigidbody2D rb;
    public Animator animator;
    public IInputProvider input;

    public float jumpForce = 10f;
    public float moveSpeed = 5f;
}