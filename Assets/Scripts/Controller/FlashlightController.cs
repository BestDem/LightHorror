using UnityEngine;
using UnityEngine.UI;

public class FlashlightController : MonoBehaviour, InteractObject
{
    [SerializeField] private Light light;
    [SerializeField] private Image batteryImage;
    [SerializeField] private Text chargeBattery;
    [SerializeField] private float maxCharge;
    [SerializeField] private MusicManager musicManager;
    private float currentTimer;
    private bool isTurnOn = false;
    public bool isTurnOnLight => isTurnOn;

    private void Start()
    {
        chargeBattery.text = maxCharge.ToString();
        light.intensity = 0;
        currentTimer = maxCharge;
    }
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.F))
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
        musicManager.PlaySongByIndex(3);
        bool isLight = !isTurnOn;
        isTurnOn = isLight;

        if (isTurnOn)
        {
            light.intensity = Mathf.Lerp(0, 8, 0.03f);
        }
        else
        {
            light.intensity = Mathf.Lerp(8, 0, 0.03f);
        }
    }

    public void UseObject()
    {
        currentTimer = maxCharge;
        chargeBattery.text = Mathf.Round(currentTimer).ToString();
    }
}
