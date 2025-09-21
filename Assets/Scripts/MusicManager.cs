using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private MusicController musicController;
    [SerializeField] private AudioSource audioSource;

    private void UpdateCurrentClip()
    {
        audioSource.clip = musicController.CurrentClip;

        audioSource.Play();
    }
    public void PlaySongByIndex(int index) // через индекс включать звук
    {
        musicController.SetSpecificClip(index);
        UpdateCurrentClip();
    }
}
