public class AirBorne : State
{
    readonly PlayerContext ctx;

    public AirBorne(StateMachine machine, State parent, PlayerContext ctx) : base(machine, parent)
    {
        this.ctx = ctx;
    }
}