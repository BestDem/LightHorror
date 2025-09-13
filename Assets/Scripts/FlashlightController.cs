using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private Image batteryImage;
    [SerializeField] private Text chargeBattery;
    [SerializeField] private float maxCharge;
    private float currentTimer;
    private bool isTurnOn = false;
    public bool isTurnOnLight => isTurnOn;

    private void Start()
    {
        light.intensity = 0;
        currentTimer = maxCharge;
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnOrOffLight();
        }

        if (isTurnOn)
        {
            TimeTurnOn();
        }

    }

    private void TimeTurnOn()
    {
        currentTimer -= Time.deltaTime;
        batteryImage.fillAmount = currentTimer / maxCharge;
        chargeBattery.text = Mathf.Round(currentTimer).ToString();

        if (currentTimer < 0)
        {
            OnOrOffLight();
        }
    }

    private void OnOrOffLight()
    {
        bool isLight = !isTurnOn;
        isTurnOn = isLight;

        if (isTurnOn)
        {
            light.intensity = Mathf.Lerp(0, 190, 2);
        }
        else
        {
            light.intensity = Mathf.Lerp(190, 0, 2);
        }
    }

    public void UseObject()
    {
        currentTimer = maxCharge;
    }
}
