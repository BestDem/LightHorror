using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneTrigger : MonoBehaviour
{
    [SerializeField] private GameObject spawnBox;
    [SerializeField] bool canExit;
    [SerializeField] private int numberScene;
    [SerializeField] private MusicManager musicManager;
    public bool CanExit => canExit;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("Spawn") == 1)
            spawnBox.SetActive(true);
    }

    public void ExitHome()
    {
        if (canExit)
        {
            Invoke("Exithome", 2f);
        }
        else
            musicManager.PlaySongByIndex(11);
    }

    private void Exithome()
    {
        PlayerPrefs.SetInt("Spawn", 1);
        SceneManager.LoadScene(numberScene);
    }

    public void OpenExitDoor()
    {
        musicManager.PlaySongByIndex(9);
        canExit = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene(int scene)
    {
        StartCoroutine(Load(scene));
    }

    IEnumerator Load(int scen)
    {
        yield return new WaitForSecondsRealtime(2);
        SceneManager.LoadScene(scen);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
