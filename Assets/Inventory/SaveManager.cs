using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.PlayerLoop;

[System.Serializable]
public class InventoryItemData
{
    public string itemId;
    public string itemName;
    public int damage;
    public string uniqueId;
}

public class SaveManager : MonoBehaviour
{
    private static SaveManager instanse;
    private const string Save_File_Name = "inventoryData.save";

    public static SaveManager Instance
    {
        get
        {
            if (instanse == null)
            {
                instanse = FindAnyObjectByType<SaveManager>();

                if (instanse == null)
                {
                    GameObject obj = new GameObject("SaveManager");
                    instanse = obj.AddComponent<SaveManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return instanse;
        }
    }

    private void Start()
    {
        Debug.Log(Path.Combine(Application.persistentDataPath, Save_File_Name));
    }

    private string SavePatch => Path.Combine(Application.persistentDataPath, Save_File_Name);

    public void SaveInventory(List<InventoryItem> items)
    {
        //InventorySaveData saveData = new InventorySaveData();

        foreach (var item in items)
        {
            //saveData.items.Add(new InventoryItemData)
        }

        //string json = JsonUtility.ToJson(saveData, true);

    }
    
    //public

}
