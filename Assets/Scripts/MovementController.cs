using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputController inputController;
    private Animator animator;
    private bool canMove = true;
    private Vector3 gravity;
    public bool CanMove => canMove;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gravity = Vector3.zero;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        AnimationWalk();
    }


    public void Movement()
    {
        Vector3 forwardMovement = transform.forward * inputController.movement.y * speed * Time.deltaTime;
        Vector3 rightMovement = transform.right * inputController.movement.x * speed * Time.deltaTime;

        if (characterController.isGrounded && gravity.y < 0)
        {
            gravity.y = 0;
        }

        gravity.y += Physics.gravity.y * Time.deltaTime * Time.deltaTime;

        characterController.Move(forwardMovement);
        characterController.Move(rightMovement);
        characterController.Move(gravity);
    }

    private void AnimationWalk()
    {
        if (Mathf.RoundToInt(inputController.movement.y) != 0f || Mathf.RoundToInt(inputController.movement.x) != 0f)
            animator.SetInteger("Walk", 1);
        else
            animator.SetInteger("Walk", 0);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

}
