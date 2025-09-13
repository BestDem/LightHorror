using UnityEngine;

public class InvenoryController : MonoBehaviour
{
    [SerializeField] private int MaxInventoryItems;
    [SerializeField] private KeyCode[] InventoryKeys;
    [SerializeField] private float ItemDropForce;
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;
    private InventoryItem[] inventory;
    private Vector2 mouseWheel;
    private int currentInventoryItem;
    private RaycastHit interactHit;
    void Update()
    {
        HandlePlayerInput();
        HoldCurrentItem();
    }
    private void HoldCurrentItem()
    {
        foreach (InventoryItem inventoryItem in inventory)
        {
            if (inventoryItem)
            {
                GameObject item = inventoryItem.gameObject;
                item.gameObject.transform.position = Vector3.Lerp(item.transform.position, hand.transform.position, 0.5f);
                item.gameObject.transform.rotation = head.transform.rotation;
            }
        }
    }
    public void InitializeInventory()
    {
        inventory = new InventoryItem[MaxInventoryItems];
        for (int i = 0; i < MaxInventoryItems; i++)
        {
            inventory[i] = null;
        }
    }

    private void HandlePlayerInput()
    {
        mouseWheel = Input.mouseScrollDelta;

        if (mouseWheel.y > 0)
        {
            NextItem();
        }

        if (mouseWheel.y < 0)
        {
            PrevItem();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

        if (Input.GetMouseButtonDown(1))
        {
            DropItem();
        }

        if (Input.GetMouseButtonDown(0))
        {
            UseItem();
        }

        for (int i = 0; i < inventory.Length; i++)
        {
            if (Input.GetKeyDown(InventoryKeys[i]))
            {
                if (inventory[i] != null)
                {
                    HideAllItems();

                    currentInventoryItem = i;
                    inventory[currentInventoryItem].gameObject.SetActive(true);
                    //inventory[currentInventoryItem].PlayPickupSound();
                }
            }
        }
    }

    private void NextItem()
    {
        if (currentInventoryItem + 1 < inventory.Length)
        {
            currentInventoryItem += 1;
        }

        HideAllItems();

        if (inventory[currentInventoryItem])
        {
            inventory[currentInventoryItem].gameObject.SetActive(true);
            //inventory[currentInventoryItem].PlayPickupSound();
        }

        Debug.Log(currentInventoryItem);
    }

    private void PrevItem()
    {
        if (currentInventoryItem - 1 >= 0)
        {
            currentInventoryItem -= 1;
        }

        HideAllItems();

        if (inventory[currentInventoryItem])
        {
            inventory[currentInventoryItem].gameObject.SetActive(true);
            //inventory[currentInventoryItem].PlayPickupSound();
        }

        Debug.Log(currentInventoryItem);
    }

    public void TakeItem(InventoryItem target)
    {
        int index = GetAvailableIndex();
        if (index >= 0)
        {
            inventory[index] = target;

            GameObject item = target.gameObject;

            if (item.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.isKinematic = true;
            }

            if (item.TryGetComponent(out Collider collider))
            {
                collider.enabled = false;
            }

            HideAllItems();

            currentInventoryItem = index;
            inventory[currentInventoryItem].gameObject.SetActive(true);

            target.PlayPickupSound();

            Debug.Log(index);
        }
    }

    public void DropItem()
    {
        if (inventory[currentInventoryItem])
        {
            InventoryItem currentItem = inventory[currentInventoryItem];
            GameObject item = currentItem.gameObject;

            if (item.TryGetComponent(out Collider collider))
            {
                collider.enabled = true;
            }

            if (item.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.isKinematic = false;
                rigidbody.AddForce(head.transform.forward * ItemDropForce);
            }

            inventory[currentInventoryItem] = null;
        }
    }

    private void UseItem()
    {
        if (inventory[currentInventoryItem])
        {
            if (inventory[currentInventoryItem].gameObject.TryGetComponent(out InteractObject interactObject))
            {
                interactObject.UseObject();
            }
        }
    }
    private void HideAllItems()
    {
        foreach (InventoryItem item in inventory)
        {
            if (item)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    private int GetAvailableIndex()
    {
        int index = -1;
        for (int i = 0; i < MaxInventoryItems; i++)
        {
            InventoryItem item = inventory[i];
            if (item == null)
            {
                index = i;
                break;
            }
        }

        return index;
    }
    public void Interact()
    {
        if (interactHit.transform)
        {
            GameObject target = interactHit.transform.gameObject;
            if (target.TryGetComponent(out InventoryItem item))
            {
                TakeItem(item);
            }
            else if (target.TryGetComponent(out InteractObject interactObject))
            {
                interactObject.UseObject();
            }
        }
    }

}
