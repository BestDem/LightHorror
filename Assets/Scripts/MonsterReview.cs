using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterReview : MonoBehaviour
{
    [Tooltip("Mechanics")]
    private Vector3 randomPoint;
    private MusicManager musicManager;
    private NavMeshAgent monster;
    private GameObject player;
    private SpawnMonster spawnMonsterFind;
    private Animator animator;
    private bool isFollowing = true;
    private bool isWalkMonstor = false;
    private bool isPlayerHid = false;

    private void Awake()
    {
        musicManager = GetComponent<MusicManager>();
        GameObject playerFind = GameObject.FindGameObjectWithTag("Player");
        spawnMonsterFind = FindAnyObjectByType<SpawnMonster>();
        player = playerFind;
    }
    void Start()
    {
        musicManager.PlaySongByIndex(4);

        monster = GetComponent<NavMeshAgent>();
        randomPoint = SpawnMonster.GetRandomPoint(player.transform.position, 20);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isPlayerHid == false)
            FollowPlayer();

        if (isFollowing == false)
            RandomChoisePoint();
    }

    private void RandomChoisePoint()
    {
        animator.SetBool("isWalk", true);
        float distance = Vector3.Distance(randomPoint, transform.position);

        if (distance > 2 && isWalkMonstor)
            monster.SetDestination(randomPoint);
        else if (distance < 2)
        {
            DestroyMonster();
        }
    }

    private void FollowPlayer()
    {
        animator.SetBool("isWalk", true);
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (2 < distance)
        {
            isFollowing = true;
            monster.SetDestination(player.transform.position);
        }
        else if(distance < 2 || distance > 18)
        {
            Debug.Log("убит или ушел на другой этаж");
            DestroyMonster();
            TimeLineDeath.singeltonDeath.Death();
        }
    }

    IEnumerator Waiting()
    {
        Debug.Log("Ждем монстра");
        animator.SetBool("isWalk", false);
        isWalkMonstor = false;
        float randomWaitingTime = UnityEngine.Random.Range(1, 3);
        musicManager.PlaySongByIndex(6);
        yield return new WaitForSecondsRealtime(randomWaitingTime);

        RandomChoisePoint();

        isWalkMonstor = true;
    }

    public void PlayerIsHid(bool isHid)
    {
        isPlayerHid = isHid;
        isFollowing = !isFollowing;

        StartCoroutine(Waiting());
    }

    private void DestroyMonster()
    {
        musicManager.PlaySongByIndex(5);
        spawnMonsterFind.CanSpawnMonster();
        Destroy(gameObject);
    }
}
