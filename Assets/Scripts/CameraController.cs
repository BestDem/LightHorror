using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [Header("Params")]
    [SerializeField] private float MouseSens;

    [Header("Components")]
    [SerializeField] private InputController inputController;

    [Header("GameObjects")]
    [SerializeField] private GameObject headMove;
    [SerializeField] private GameObject head;
    private bool lockedCamera = true;
    private float _xRot = 0f;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(lockedCamera)
            Lookk();
    }

    private void Look()
    {
        transform.Rotate(0, inputController.mouse.x * MouseSens, 0);
        headMove.transform.Rotate(-inputController.mouse.y * MouseSens, 0, 0);
    }
    private void Lookk()
    {
        transform.Rotate(0, inputController.mouse.x * MouseSens, 0);
        _xRot = Mathf.Clamp(_xRot - inputController.mouse.y * MouseSens, -90, 90);
        headMove.transform.localRotation = Quaternion.Euler(_xRot, 0, 0);
    }


    public void UnlockCamera(bool islockedCamera)
    {
        lockedCamera = islockedCamera;
        if (lockedCamera)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.Confined;
    }
}
