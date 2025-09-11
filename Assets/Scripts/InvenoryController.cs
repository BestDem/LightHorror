using UnityEngine;

public class InvenoryController : MonoBehaviour
{
    [SerializeField] private GameObject inventoryImage;
    [SerializeField] private CameraController cameraController;
    private bool isActive = false;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bool active = !isActive;
            isActive = active;
            cameraController.UnlockCamera(!isActive);
            inventoryImage.SetActive(active);
        }
    }
}
