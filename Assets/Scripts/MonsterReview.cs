using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MonsterReview : MonoBehaviour
{
    [Tooltip("Mechanics")]
    [SerializeField] private Transform[] routePoints;
    [SerializeField] private GameObject player;
    [SerializeField] private float viewingAngle;
    private NavMeshAgent monster;
    private bool isFollowing = false;
    private bool isWalkMonstor = false;
    private int randomPoint;

    void Start()
    {
        randomPoint = UnityEngine.Random.Range(0, routePoints.Length);
        monster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();

        if (isFollowing == false)
            RandomChoisePoint();

    }

    private void RandomChoisePoint()
    {
        float distance = Vector3.Distance(routePoints[randomPoint].position, transform.position);

        if (distance > 2 && isWalkMonstor)
            monster.SetDestination(routePoints[randomPoint].position);
        else if(distance < 2 || isWalkMonstor == false)
        {
            StartCoroutine(Waiting());
        }
    }

    private void FollowPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        if (Mathf.Abs(Vector3.Angle(transform.forward, dir)) < viewingAngle)
        {
            monster.SetDestination(player.transform.position);
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }
    }

    IEnumerator Waiting()
    {
        isWalkMonstor = false;
        float randomWaitingTime = UnityEngine.Random.Range(1, 5);
        yield return new WaitForSecondsRealtime(randomWaitingTime);
        randomPoint = UnityEngine.Random.Range(0, routePoints.Length);

        isWalkMonstor = true;
    }
}
