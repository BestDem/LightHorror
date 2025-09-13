using UnityEngine;

public class FsmStateRun : FsmStateWalk
{
    protected readonly float speed;
    protected readonly InputController input;

    public FsmStateRun(FSM fsm, float Speed, InputController Input, MovementController Movement) : base(fsm, Speed, Input, Movement)
    {
        speed = Speed;
        input = Input;
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
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Fsm.SetState<FsmStateWalk>();
        }
    }
}
