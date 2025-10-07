using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private InputController inputController;
    [SerializeField] private MusicManager musicManager;
    private Animator animator;
    private bool canMove = true;
    private Vector3 gravity;
    public bool CanMove => canMove;
    private Coroutine stepCoroutine;
    private bool moving = false;
    private bool hasVelocities => (Mathf.RoundToInt(inputController.movement.y) >=1f || Mathf.RoundToInt(inputController.movement.x) >= 1f);

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gravity = Vector3.zero;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimationWalk();
    }


    public void Movement(float speed)
    {
        if (canMove)
        {
            //Invoke("PlayStep", 0.4f);
            Vector3 forwardMovement = transform.forward * inputController.movement.y * speed * Time.deltaTime;
            Vector3 rightMovement = transform.right * inputController.movement.x * speed * Time.deltaTime;
            if (!moving && hasVelocities)
            {
                moving = true;
                stepCoroutine = StartCoroutine(PlayStep());
            }
            if (moving && !hasVelocities)
            {
                moving = false;
                if (stepCoroutine != null)
                    StopCoroutine(stepCoroutine);
            }
            characterController.Move(forwardMovement);
            characterController.Move(rightMovement);
        }
    }
    private IEnumerator PlayStep()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            musicManager.PlaySongByIndex(12);
            yield return new WaitForSeconds(0.4f);
        }
    }

    public void ApplyGravity()
    {
        if (canMove)
        {
            if (characterController.isGrounded && gravity.y < 0)
            {
                gravity.y = 0;
            }

            gravity.y += Physics.gravity.y * Time.deltaTime * Time.deltaTime;

            characterController.Move(gravity);
        }
    }

    private void AnimationWalk()
    {
        if (Mathf.RoundToInt(inputController.movement.y) != 0f || Mathf.RoundToInt(inputController.movement.x) != 0f)
        {
            animator.SetInteger("Walk", 1);
        }
        else
            animator.SetInteger("Walk", 0);
    }

    public void HidePlayer(Transform transformHid, bool isHid)
    {
        canMove = !isHid;
        if (gameObject.TryGetComponent(out Collider collider))
        {
            collider.enabled = canMove;
        }
        transform.position = transformHid.position;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

}
