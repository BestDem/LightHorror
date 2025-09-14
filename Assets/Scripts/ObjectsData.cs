using System;
using UnityEngine;

public class ObjectsData : MonoBehaviour
{
    public static event Action SaveObject;
    public static ObjectsData Seinglinventory { get; private set; }
    private void Awake()
    {
        if (Seinglinventory == null)
            Seinglinventory = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();  
    }

    public void SaveReceivedObjects(string key)
    {
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key) + 1);
    }

    public void SaveDeleteObjects(string key)
    {
        PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key) - 1);
    }
}