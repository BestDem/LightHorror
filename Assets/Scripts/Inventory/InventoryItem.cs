using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private string ItemName = "ITEM";

    [Header("Audio")]
    [SerializeField] private MusicManager musicManager;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public void PlayPickupSound(int index)
    {
        musicManager.PlaySongByIndex(index);
    }

    public string GetItemName()
    {
        return ItemName;
    }
}
