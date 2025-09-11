using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnBook : MonoBehaviour
{
    [SerializeField] private List<Transform> pointTransform;
    [SerializeField] private GameObject books;
    private List<Transform> spawnedList = new();
    private int startCountBooks = 4;    //можно сделать несколько массивов со спавном и уровни сложности(+подвал, чердак)

    private void Start()
    {
        SpawnBooks();
    }

    private void SpawnBooks()
    {
        for (int i = 0; i < startCountBooks; i++)
        {
            int random = Random.Range(0, pointTransform.Count);
            spawnedList.Add(pointTransform[random]);
            pointTransform.Remove(pointTransform[random]);
            
            books = Instantiate(books, spawnedList[i].transform.position, Quaternion.identity);
        }
    }
}
