using UnityEngine;

public class FlathLight : MonoBehaviour
{
    private FlashlightController flashlightController;
    private void Start()
    {
        flashlightController = FindAnyObjectByType<FlashlightController>();
    }
    public void UseObject()
    {
        flashlightController.ResetBattery();
    }
}
