using UnityEngine;

[CreateAssetMenu(fileName = "ControllerSettings", menuName = "Music Settings")]
public class MusicController : ScriptableObject
{
    [SerializeField] private AudioClip[] audioClips;
    public AudioClip CurrentClip => audioClips[currentClipIndex];
    private int currentClipIndex = 0;

    public void SetSpecificClip(int index)
    {
        if (index >= 0 && index < audioClips.Length)
            currentClipIndex = index;
    }
    
    public AudioClip GetClipByIndex(int index)
    {
        if (index >= 0 && index < audioClips.Length)
            return audioClips[index];
        return null;
    }
}
