using System.Collections.Generic;

public class StateMachine
{
    public readonly State Root;
    public readonly TransitionSequencer Sequencer;
    bool Started;

    public StateMachine(State root)
    {
        Root = root;
        Sequencer = new(this);
    }

    public void Start()
    {
        if (Started) return;
        Started = true;
        Root.Enter();
    }

    public void Tick(float deltaTime)
    {
        if(!Started) Start();
        Root.Update(deltaTime);
    }

    public void ChangeState(State stateA, State stateB)
    {
        if (stateA == stateB || stateB is null || stateA is null) return;
        var lca = TransitionSequencer.LowestCommonAncestor(stateA, stateB);

        // Exit current branch up to LCA (not including LCA)
        for (var s = stateA; s != lca; s = s.Parent) s.Exit();

        // Enter target branch down from LCA (not including LCA)
        var stack = new Stack<State>();
        for (var s = stateB; s != lca; s = s.Parent) stack.Push(s);
        while (stack.Count > 0) stack.Pop().Enter();
    }
}