using UnityEngine;

public class FsmStateIdel : FsmState
{
    protected readonly InputController input;
    protected readonly MovementController movement;
    public FsmStateIdel(FSM fsm, InputController Input, MovementController Movement) : base(fsm)
    {
        input = Input;
        movement = Movement;
    }

    public override void Enter()
    {
        
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void StateUpdate()
    {
        movement.ApplyGravity();

        if (input.movement.sqrMagnitude != 0)
        {
            Fsm.SetState<FsmStateWalk>();
        }
    }
}
