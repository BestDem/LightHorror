using UnityEngine;
using UnityEngine.UI;

public class CountBookBox : MonoBehaviour
{
    [SerializeField] private NextSceneTrigger openDoor;
    [SerializeField] private Text countText;
    [SerializeField] private int maxBook;
    private int currentBook = 0;

    private void Start()
    {
        countText.text = currentBook.ToString() + "/" + maxBook.ToString();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Box"))
        {
            currentBook += 1;
            Destroy(collider);
            if (currentBook == maxBook)
            {
                openDoor.OpenExitDoor();
            }
            countText.text = currentBook.ToString() + "/" + maxBook.ToString();
        }
    }
}
