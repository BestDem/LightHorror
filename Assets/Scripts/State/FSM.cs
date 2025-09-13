using System;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private FsmState stateCurrent { get; set; }
    private Dictionary<Type, FsmState> _states = new Dictionary<Type, FsmState>();

    public void AddState(FsmState state)
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (stateCurrent != null && stateCurrent.GetType() == type)
            return;
        if (_states.TryGetValue(type, out var newState))
        {
            stateCurrent?.Enter();
            stateCurrent = newState;
            stateCurrent.Exit();
        }
    }

    public void Update()
    {
        stateCurrent?.StateUpdate();
    }
}
