using UnityEngine;

public class HideContoller : MonoBehaviour, InteractObject
{
    private bool isHid = false;
    private SpawnMonster spawnMonster;

    private void Start()
    {
        spawnMonster = FindAnyObjectByType<SpawnMonster>();
    }

    public void UseObject()
    {
        isHid = !isHid;
        HidePlayer();
    }

    public void HidePlayer()
    {
        spawnMonster.HidPlayer(isHid);
    }
}
