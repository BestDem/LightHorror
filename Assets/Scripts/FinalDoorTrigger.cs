using UnityEngine;

public class FinalDoorTrigger : MonoBehaviour
{
    [SerializeField] private SpawnMonster spawnMonster;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            spawnMonster.CanSpawnMonster(true);
        }
    }
}
