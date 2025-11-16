public class Move : State
{
    readonly PlayerContext ctx;
    public Move(StateMachine machine, State parent, PlayerContext ctx) : base(machine, parent)
    {
        this.ctx = ctx;
    }
    //protected override void OnEnter()
    //{
    //    base.OnEnter();
    //    player.Anim.Play("Run");
    //}
    //protected override void OnUpdate()
    //{
    //    base.OnUpdate();
    //    float inputX = player.Input.Horizontal;
    //    player.SetVelocityX(inputX * player.MoveSpeed);
    //    if (inputX == 0)
    //    {
    //        Machine.ChangeState(((Grounded)Parent).Idle);
    //    }
    //}
}