using UnityEngine;

public class FsmStateWalk : FsmState
{
    protected readonly float speed;
    protected readonly InputController input;
    protected readonly MovementController movement;

    public FsmStateWalk(FSM fsm) : base(fsm)
    {
    }

    public FsmStateWalk(FSM fsm, float Speed, InputController Input, MovementController Movement) : base(fsm)
    {
        speed = Speed;
        input = Input;
        movement = Movement;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void StateUpdate()
    {
        movement.Movement(speed);
        movement.ApplyGravity();

        if (input.movement.sqrMagnitude == 0)
        {
            Fsm.SetState<FsmStateIdel>();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Fsm.SetState<FsmStateRun>();
        }
    }
}
