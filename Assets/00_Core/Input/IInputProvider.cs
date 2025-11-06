using System;
using UnityEngine;

public interface IInputProvider
{
    Vector2 MoveInput { get; }
    bool HasJumpBuffer { get; }
    bool HasDashBuffer { get; }
    bool HasAttackBuffer { get; }

    void ConsumeJumpBuffer();
    void ConsumeDashBuffer();
    void ConsumeAttackBuffer();
}