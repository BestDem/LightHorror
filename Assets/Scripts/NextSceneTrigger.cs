using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ПЕреход");
        if (other.gameObject.tag == "player")
            SceneManager.LoadScene(1);
    }
}
