using UnityEngine;

public class OpenDoorMonster : MonoBehaviour
{
    private bool isOpen = false;
    private float currentTime = 0;
    private void OnTriggerStay(Collider other)
    {
        if (isOpen == false)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 4)
            {
                if (other.gameObject.TryGetComponent(out OpenDoorTrigger openDoor))
                {
                    openDoor.UseObject();
                    isOpen = true;
                    currentTime = 0;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out OpenDoorTrigger openDoor))
        {
            openDoor.UseObject();
            isOpen = false;
        }
    }
}
