using JetBrains.Annotations;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour, InteractObject
{
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private bool needKey = false;
    private Transform door;
    private bool isOpen = false;
    public bool IsOpen => isOpen;

    private void Start()
    {
        door = GetComponent<Transform>();
    }

    public void UseObject()
    {
        if (needKey == false)
        {
            if (isOpen)
            {
                door.rotation = Quaternion.Euler(0, 0, 0);
                isOpen = false;
                musicManager.PlaySongByIndex(2);
            }
            else
            {
                door.rotation = Quaternion.Euler(0, 90, 0);
                isOpen = true;
                musicManager.PlaySongByIndex(2);
            }
        }
        else
        {
            musicManager.PlaySongByIndex(8);
        }
    }

    public void OpenDoorKey()
    {
        musicManager.PlaySongByIndex(7);
        needKey = false;
    }
}
