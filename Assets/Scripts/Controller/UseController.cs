using UnityEngine;

public class UseController : MonoBehaviour
{
    [SerializeField] private Screen_fader screen_Fader;
    [SerializeField] private Transform head;
    [SerializeField] private float distationUse = 4;
    private float direction;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15f))
        {
            direction = Vector3.Distance(head.position, hit.transform.position);
            if (direction < distationUse)
            {
                if (hit.collider.TryGetComponent(out InventoryItem inventory))  //складывание предметов в инвентарь пкм
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                        InvenoryController.singltonInventory.Interact(hit);
                }

                if (hit.collider.TryGetComponent(out InteractObject interact))  //открытие дверей лкм
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                        interact.UseObject();
                }
                
                if (hit.collider.TryGetComponent(out TeleportLift lift))  //меремещение между этажами
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (InvenoryController.singltonInventory.ObjectInHand() == "Card" && lift.CanTeleport == false)
                        {
                            lift.UseCard();
                            InvenoryController.singltonInventory.UseItem();
                        }
                    }
                }

                if (hit.collider.TryGetComponent(out OpenDoorTrigger openDoor))  //открытие двери с ключом лкм
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (InvenoryController.singltonInventory.ObjectInHand() == "Key" && openDoor.IsOpen == false)
                        {
                            openDoor.OpenDoorKey();
                            InvenoryController.singltonInventory.UseItem();
                        }
                    }
                }
                if (hit.collider.TryGetComponent(out FlathLight flathLight))  //обновление батарейки
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (InvenoryController.singltonInventory.ObjectInHand() == "Battery")
                        {
                            flathLight.UseObject();
                            InvenoryController.singltonInventory.UseItem();
                        }
                    }
                }

                if (hit.collider.TryGetComponent(out NextSceneTrigger exit))  //открытие двери на выход
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E) && exit.CanExit)
                    {
                        screen_Fader.ImageNoVisible();
                        exit.ExitHome();
                    }
                }
            }
                else
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(false);
                }
        }    
    }
}
