using System;
using UnityEngine;

public class InputHandler : MonoBehaviour, IInputProvider
{
    [SerializeField][AutoAssign] private InputReader inputReader;

    [Header("Buffer Settings")]
    [SerializeField] private float bufferTime = 0.2f;
    private float jumpBufferTimer;
    private float dashBufferTimer;
    private float attackBufferTimer;

    // Interface
    public Vector2 MoveInput { get; private set; }

    public bool HasJumpBuffer => jumpBufferTimer > 0;

    public bool HasDashBuffer => dashBufferTimer > 0;

    public bool HasAttackBuffer => attackBufferTimer > 0;

    public void ConsumeAttackBuffer() => attackBufferTimer = 0;

    public void ConsumeDashBuffer() => dashBufferTimer = 0;

    public void ConsumeJumpBuffer() => jumpBufferTimer = 0;

    // Registration
    private void Awake() => ServiceLocator.Register<IInputProvider>(this);

    private void OnEnable()
    {
        inputReader.MoveEvent += OnMove;
        inputReader.JumpEvent += OnJump;
        inputReader.DashEvent += OnDash;
        inputReader.AttackEvent += OnAttack;
    }

    private void OnMove(Vector2 vector) => MoveInput = vector;
    private void OnJump() => jumpBufferTimer = bufferTime;
    private void OnDash() => dashBufferTimer = bufferTime;
    private void OnAttack() => attackBufferTimer = bufferTime;

    private void Update()
    {
        jumpBufferTimer -= Time.deltaTime;
        dashBufferTimer -= Time.deltaTime;
        attackBufferTimer -= Time.deltaTime;
    }

    // Unregistration
    private void OnDisable()
    {
        inputReader.MoveEvent -= OnMove;
        inputReader.JumpEvent -= OnJump;
        inputReader.DashEvent -= OnDash;
        inputReader.AttackEvent -= OnAttack;
    }

    private void OnDestroy()
    {
        ServiceLocator.Unregister<IInputProvider>();
    }
}