using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawnBook : MonoBehaviour
{
    [SerializeField] private Transform[] pointTransform;
    [SerializeField] private GameObject books;
    private List<int> spawnedList = new();
    private int sizeList;
    private int startCountBooks = 4;    //можно сделать несколько массивов со спавном и уровни сложности(+подвал, чердак)
    private int currentSpawnBook = 0;
    void Start()
    {
        sizeList = pointTransform.Length;
        int randomSpawn = Random.Range(0, sizeList);
        spawnedList.Add(randomSpawn);
        books = Instantiate(books, pointTransform[randomSpawn].transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (sizeList >= startCountBooks && currentSpawnBook < startCountBooks)
        {
            int randomSpawn = Random.Range(0, sizeList);
            if (SpawnBooks(randomSpawn) == true)
                currentSpawnBook += 1;
        }
    }

    private bool SpawnBooks(int randomSpawn)
    {
        for (int i = 0; i <= spawnedList.Count; i++)
        {
            if (i != randomSpawn && i == spawnedList.Count)
                books = Instantiate(books, pointTransform[randomSpawn].transform.position, Quaternion.identity);
            else if (i == randomSpawn)
                return false;
        }
        Debug.Log(randomSpawn);
        return true;
    }
}
