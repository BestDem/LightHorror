using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float speed;

    [Header("Settings")]
    [SerializeField] private CharacterController characterController;
    private InputController inputController;
    private bool canMove = true;
    private Vector3 gravity;
    public bool CanMove => canMove;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gravity = Vector3.zero;
        inputController = new InputController();
    }

    private void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Vector2 forwardMovement = transform.forward * inputController.movement.y * speed * Time.deltaTime;
        Vector2 rightMovement = transform.right * inputController.movement.x * speed * Time.deltaTime;

        if (characterController.isGrounded && gravity.y < 0)
        {
            gravity.y = 0;
        }
        Debug.Log(forwardMovement);

        gravity.y += Physics.gravity.y * Time.deltaTime * Time.deltaTime;

        characterController.Move(forwardMovement);
        characterController.Move(rightMovement);
        characterController.Move(gravity);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

}
