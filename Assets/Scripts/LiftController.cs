using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private List<GameObject> checkPoints;
    [SerializeField] private GameObject player;
    
    public void TeleportPlayer(int numberFlat)
    {
        player.transform.position = checkPoints[numberFlat].transform.position;
    }
}
