public class Idle : State
{
    readonly PlayerContext ctx;
    public Idle(StateMachine machine, State parent, PlayerContext ctx) : base(machine, parent)
    {
        this.ctx = ctx;
    }
    protected override void OnEnter()
    {
        //player.SetVelocityX(0);
        //player.Anim.Play("Idle");
    }
}