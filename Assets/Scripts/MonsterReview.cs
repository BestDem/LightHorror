using System;
using UnityEngine;
using UnityEngine.AI;

public class MonsterReview : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float viewingAngle;
    private NavMeshAgent monster;

    void Start()
    {
        monster = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        if (Mathf.Abs(Vector3.Angle(transform.forward, dir)) < viewingAngle)
        {
            monster.SetDestination(player.transform.position);
        }
        
    }
}
