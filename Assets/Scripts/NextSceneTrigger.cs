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
            PlayerPrefs.SetInt("Spawn", 1);
            SceneManager.LoadScene(numberScene);
        }
        else
            musicManager.PlaySongByIndex(11);
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
        SceneManager.LoadScene(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
