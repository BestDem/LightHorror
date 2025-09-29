using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private GameObject canvasPause;
    private bool isPause = false;
    private CameraController cameraController;

    private void Start()
    {
        cameraController = FindAnyObjectByType<CameraController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GetInput();
    }

    public void GetInput()
    {
        isPause = !isPause;

        if (isPause == true)
        {
            cameraController.UnlockCamera(false);
            canvasPause.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            cameraController.UnlockCamera(true);
            canvasPause.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
