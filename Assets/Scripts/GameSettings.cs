using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixerSound;
    [SerializeField] private Slider volumeAudioSound;
    [SerializeField] private Slider mouseSpeed;
    public static event Action<float> ChangeSens;
    
    private string MUSIC_VOLUME_KEY = "MasterVolume";
    private string MOUSE_SPEED_KEY = "MouseVolume";
    
    private float masterVolume;
    private float mouseVolume;

    private void Start()
    {
        masterVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        mouseVolume = PlayerPrefs.GetFloat(MOUSE_SPEED_KEY, 0.7f);

        mouseSpeed.value = mouseVolume;
        volumeAudioSound.value = masterVolume;

        ApplySoundVolume(masterVolume);
        ChangeSens?.Invoke(mouseVolume);
    }

    public void SetVolumeMouse(float newVolume)
    {
        mouseVolume = Mathf.Clamp01(newVolume);
        
        ChangeSens?.Invoke(mouseVolume);
        
        PlayerPrefs.SetFloat(MOUSE_SPEED_KEY, mouseVolume);
        PlayerPrefs.Save();
    }
    
    public void SetVolumeSound(float newVolume)
    {
        masterVolume = Mathf.Clamp01(newVolume);
        ApplySoundVolume(masterVolume);
        
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, masterVolume);
        PlayerPrefs.Save();
    }
    
    private void ApplySoundVolume(float volume)
    {
        if (volume <= 0)
        {
            audioMixerSound.SetFloat("MasterVolume", -80f);
        }
        else
        {
            audioMixerSound.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }
    }    
}
