using UnityEngine;

public class FsmExample : MonoBehaviour
{
    private FSM fsm;
    [SerializeField] private InputController input;
    [SerializeField] private MovementController moveContr;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    private void Start()
    {
        fsm = new FSM();
        fsm.AddState(new FsmStateIdel(fsm, input, moveContr));
        fsm.AddState(new FsmStateWalk(fsm, walkSpeed, input, moveContr));
        fsm.AddState(new FsmStateRun(fsm, runSpeed, input, moveContr));

        fsm.SetState<FsmStateIdel>();
    }

    private void Update()
    {
        fsm.Update();
    }
}
