public class Grounded : State
{
    readonly PlayerContext ctx;
    public readonly Idle Idle;
    public readonly Move Move;

    public Grounded(StateMachine machine, State parent, PlayerContext ctx) : base(machine, parent)
    {
        this.ctx = ctx;
        Idle = new(machine, this, ctx);
        Move = new(machine, this, ctx);
    }

    protected override State InitialState() => Idle;
    protected override State GetTransition()
    {
        //return ((PlayerRoot)Parent).AirBorne;
        return this;
    }
}