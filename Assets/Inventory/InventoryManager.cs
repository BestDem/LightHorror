using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instanse;

    [SerializeField] private List<GunItem> allGunItems;
    private List<InventoryItem> collectionItems = new List<InventoryItem>();

    private void LoadInventory()
    {
        //InventorySaveData saveData = SaveManager.Instance.Load

        //col
    }
}
