using UnityEngine;

public class UseController : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private float distationUse = 4;
    private InputController inputController;
    private float direction;
    private void Start()
    {
        inputController = GetComponent<InputController>();
    }

    // Update is called once per frame
    private void FixedUpdate()
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
                    if (inputController.isFire)
                        InvenoryController.singltonInventory.Interact(hit);
                }

                if (hit.collider.TryGetComponent(out InteractObject interact))  //открытие дверей лкм
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetMouseButtonDown(1))
                        interact.UseObject();
                }

                if (hit.collider.TryGetComponent(out OpenDoorTrigger openDoor))  //открытие двери с ключом лкм
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        if (InvenoryController.singltonInventory.ObjectInHand() == "Key" && openDoor.IsOpen == false)
                        {
                            openDoor.OpenDoorKey();
                            InvenoryController.singltonInventory.UseItem();
                        }
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
