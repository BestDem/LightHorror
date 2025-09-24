using UnityEngine;

public class TeleportLift : MonoBehaviour , InteractObject
{
    [SerializeField] private int numberFlat;
    [SerializeField] private LiftController liftController;
    [SerializeField] private MusicManager musicManager;
    [SerializeField] private bool canTeleport = false;
    public bool CanTeleport => canTeleport;

    public void UseCard()
    {
        musicManager.PlaySongByIndex(11);
        canTeleport = true;
    }

    public void UseObject()
    {
        if (canTeleport)
        {
            musicManager.PlaySongByIndex(9);
            liftController.TeleportPlayer(numberFlat);
        }
        else
            musicManager.PlaySongByIndex(10);
    }
}
