using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private Sprite sprite;
    [SerializeField] private string ItemName = "ITEM";

    [Header("Audio")]
    [SerializeField] private AudioSource AudioPickup;

    public Sprite GetSprite()
    {
        return sprite;
    }

    public void PlayPickupSound()
    {
        AudioPickup.Play();
    }

    public string GetItemName()
    {
        return ItemName;
    }

    public int CountObject()
    {
        return PlayerPrefs.GetInt(ItemName);
    }

    public void SaveObject()
    {
        ObjectsData.Seinglinventory.SaveReceivedObjects(ItemName);
    }
    
    public void SaveDelObject()
    {
        ObjectsData.Seinglinventory.SaveDeleteObjects(ItemName);
    }
}
