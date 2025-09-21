using UnityEngine;

public class UseController : MonoBehaviour
{
    [SerializeField] private GameObject aim;
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
                if (hit.collider.TryGetComponent(out InventoryItem inventory))
                {
                    aim.SetActive(true);
                    if (inputController.isFire)
                        InvenoryController.singltonInventory.Interact(hit);
                }

                if (hit.collider.TryGetComponent(out InteractObject interact))
                {
                    ObjectsData.Seinglinventory.canOpenDoor.SetActive(true);
                    if (Input.GetMouseButtonDown(1))
                        interact.UseObject();
                }
            }
            else
            {
                ObjectsData.Seinglinventory.canOpenDoor.SetActive(false);
                aim.SetActive(false);
            }
        }    
    }
}
