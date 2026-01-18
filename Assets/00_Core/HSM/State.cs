using System.Collections.Generic;

public abstract class State
{
    public readonly StateMachine Machine;
    public readonly State Parent;
    public State ActiveChild;

    public State(StateMachine machine, State parent = null)
    {
        Machine = machine;
        Parent = parent;
    }

    protected virtual State InitialState() => null; // Initial child will run when this state starts (null == leaf)

    protected virtual State GetTransition() => null; // Target state for transition (null == no transition)

    // lifecycle hooks
    protected virtual void OnEnter() { }
    protected virtual void OnExit() { }
    protected virtual void OnUpdate(float deltaTime) { }

    public void Enter()
    {
        if (Parent != null) Parent.ActiveChild = this;
        OnEnter();
        InitialState()?.Enter();
    }

    public void Exit()
    {
        ActiveChild?.Exit();
        ActiveChild = null;
        OnExit();
    }

    public void Update(float deltaTime)
    {
        State s = GetTransition();
        if (s != null)
        {
            Machine.Sequencer.RequestTransition(this, s);
            return;
        }

        ActiveChild?.Update(deltaTime);
        OnUpdate(deltaTime);
    }

    // returns the leaf-most active state
    public State Leaf()
    {
        State s = this;
        while (s.ActiveChild != null) s = s.ActiveChild;
        return s;
    }

    public IEnumerable<State> PathToRoot()
    {
        for (State s = this; s != null; s = s.Parent)
            yield return s;
    }
}
