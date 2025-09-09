using UnityEngine;

public class CounterBook : MonoBehaviour
{
    [SerializeField] private float books = 0;
    public void CountBooks()
    {
        books += 1;
        Debug.Log(books);
    }
    
}
