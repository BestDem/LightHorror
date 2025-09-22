using Unity.Cinemachine;
using UnityEngine;

public class HideContoller : MonoBehaviour, InteractObject
{
    [SerializeField] private GameObject hidPosition;
    [SerializeField] private GameObject openPosition;
    private MovementController movement;
    private CameraController cameraController;
    private bool isHid = false;
    private SpawnMonster spawnMonster;

    private void Start()
    {
        spawnMonster = FindAnyObjectByType<SpawnMonster>();
        movement = FindAnyObjectByType<MovementController>();
        cameraController = FindAnyObjectByType<CameraController>();
    }

    public void UseObject()
    {
        isHid = !isHid;
        HidePlayer();
    }

    public void HidePlayer()
    {
        spawnMonster.HidPlayer(isHid);

        movement.HidePlayer(isHid ? hidPosition.transform : openPosition.transform, isHid);
        cameraController.HidReview(isHid ? 40 : 60);
    }
}
