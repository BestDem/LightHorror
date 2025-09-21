using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour, InteractObject
{
    [SerializeField] private Transform door;
    [SerializeField] private MusicManager musicManager;
    private bool isOpen = false;

    public void UseObject()
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
}
