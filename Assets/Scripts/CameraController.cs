using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Params")]
    [SerializeField] private float MouseSens;

    [Header("Components")]
    [SerializeField] private InputController inputController;

    [Header("GameObjects")]
    [SerializeField] private GameObject head;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        inputController.mouse.x = Mathf.Clamp(inputController.mouse.x, -40, 40);
        inputController.mouse.y = Mathf.Clamp(inputController.mouse.y, -40, 40);
        Vector3 dir = head.transform.position - transform.position;

        //if (Mathf.Abs(Vector3.Angle(head.transform.forward, dir)) < 35f)
        //{
            transform.Rotate(0, inputController.mouse.x * MouseSens, 0);
            head.transform.Rotate(-inputController.mouse.y * MouseSens, 0, 0);
        //}
    }
}
