using UnityEngine;
using UnityEngine.AI;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject monsterPref;
    [SerializeField] private FlashlightController flashlight;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject player;
    private float currentTimer = 0;
    private bool isSpawnMonster = false;
    private bool isHid = false;

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        return hit.position;
    }

    private void Update()
    {
        currentTimer += flashlight.isTurnOnLight ? 0.04f : 0 + Time.deltaTime;

        if (currentTimer > timeToSpawn && isSpawnMonster == false)
        {
            SpawnedMonster();
            currentTimer = 0;
        }

    }

    public void CanSpawnMonster(bool spawn)
    {
        isSpawnMonster = spawn;
    }

    private void SpawnedMonster()
    {
        GameObject monsterPrefF = Instantiate(monsterPref, GetRandomPoint(player.transform.position, 15), Quaternion.identity);
        isSpawnMonster = true;

        monsterPrefF.TryGetComponent(out MonsterReview monsterReview);
        monsterReview.PlayerIsHid(isHid);
    }

    public void HidPlayer(bool isHidPl)
    {
        Debug.Log("Спрятался" + isHidPl);
        isHid = isHidPl;
    }

}
