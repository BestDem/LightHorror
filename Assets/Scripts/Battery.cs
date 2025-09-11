using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    [SerializeField] private float chargeBattery;
    [SerializeField] private FlashlightController flashlight;
    [SerializeField] private Text countBattery;

    private void OnEnable()
    {
        ObjectsData.SaveObject += BatteryUpdate;
    }
    private void OnDisable()
    {
        ObjectsData.SaveObject -= BatteryUpdate;
    }

    private void Start()
    {
        countBattery.text = PlayerPrefs.GetInt("Battery").ToString();
    }

    public void OnButtonCharge()
    {
        if (PlayerPrefs.GetInt("Battery") > 0)
        {
            flashlight.GetLight(chargeBattery);
            PlayerPrefs.SetInt("Battery", PlayerPrefs.GetInt("Battery") - 1);
            countBattery.text = PlayerPrefs.GetInt("Battery").ToString();
        }
    }

    private void BatteryUpdate()
    {
        countBattery.text = PlayerPrefs.GetInt("Battery").ToString();
    }
}
