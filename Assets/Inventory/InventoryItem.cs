using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GunItem gunItem;
    public string uniqueID;

    public InventoryItem(GunItem item)
    {
        gunItem = item;
        uniqueID = System.Guid.NewGuid().ToString();
    }
}
