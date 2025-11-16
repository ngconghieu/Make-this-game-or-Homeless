using System.Collections.Generic;

public class TransitionSequencer
{
    public readonly StateMachine Machine;

    public TransitionSequencer(StateMachine machine)
    {
        Machine = machine;
    }

    public void RequestTransition(State from, State to)
    {
        Machine.ChangeState(from, to);
    }

    public static State LowestCommonAncestor(State stateA, State stateB)
    {
        var ancestorsA = new HashSet<State>();

        // Collect all ancestors of stateA
        for (var s = stateA; s!= null; s = s.Parent) 
            ancestorsA.Add(s);

        // Find the first ancestor of stateB that is also an ancestor of stateA
        for (var s = stateB; s != null; s = s.Parent)
            if (ancestorsA.Contains(s)) return s;

        return null; // No common ancestor found
    }
}