public class PlayerRoot : State
{
    public Grounded Grounded;
    public AirBorne AirBorne;
    readonly PlayerContext ctx;

    public PlayerRoot(StateMachine machine, PlayerContext ctx) : base(machine, null)
    {
        this.ctx = ctx;
        Grounded = new(machine, this, ctx);
        AirBorne = new(machine, this, ctx);
    }

    protected override State InitialState() => Grounded;
    
}