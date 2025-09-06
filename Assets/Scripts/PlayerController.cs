using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Params")]
    [SerializeField] private float WalkingSpeed;
    [SerializeField] private float MouseSens;

    [Header("Components")]
    [SerializeField] private CharacterController characterController;

    [Header("GameObjects")]
    [SerializeField] private GameObject Head;

    private Vector3 gravity;

    private PlayerInput playerInput;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        gravity = Vector3.zero;

        playerInput = new PlayerInput();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GetPlayerInput();
        Movement();
        Look();
    }

    private void GetPlayerInput()
    {
        playerInput.movement.x = Input.GetAxis("Horizontal");
        playerInput.movement.y = Input.GetAxis("Vertical");

        playerInput.mouse.x = Input.GetAxis("Mouse X");
        playerInput.mouse.y = Input.GetAxis("Mouse Y");
    }

    private void Movement()
    {
        Vector3 forwardMovement = transform.forward * playerInput.movement.y * WalkingSpeed * Time.deltaTime;
        Vector3 rightMovement = transform.right * playerInput.movement.x * WalkingSpeed * Time.deltaTime;

        if (characterController.isGrounded && gravity.y < 0)
        {
            gravity.y = 0;
        }

        gravity.y += Physics.gravity.y * Time.deltaTime * Time.deltaTime;

        characterController.Move(forwardMovement);
        characterController.Move(rightMovement);
        characterController.Move(gravity);
    }

    private void Look()
    {
        transform.Rotate(0, playerInput.mouse.x * MouseSens, 0);
        Head.transform.Rotate(-playerInput.mouse.y * MouseSens, 0, 0);
    }
}

[System.Serializable]
public class PlayerInput {
    public Vector2 movement;
    public Vector2 mouse;
}
