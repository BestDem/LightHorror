using Microsoft.Unity.VisualStudio.Editor;
using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InvenoryController : MonoBehaviour
{
    public static InvenoryController singltonInventory { get; private set; }
    [SerializeField] private int MaxInventoryItems;
    [SerializeField] private KeyCode[] InventoryKeys;
    [SerializeField] private float ItemDropForce;
    [SerializeField] private Transform head;
    [SerializeField] private Transform hand;
    [SerializeField] private GameObject[] itemsImage;
    [SerializeField] private Text[] countObjects;
    [SerializeField] private Sprite nonSprite;
    private InventoryItem[] inventory;
    private Vector2 mouseWheel;
    private int currentInventoryItem;
    private void Start()
    {
        if (singltonInventory == null)
            singltonInventory = this;
        else if (singltonInventory == this)
            Destroy(gameObject);

        InitializeInventory();
    }
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

        if (mouseWheel.y < 0)
        {
            NextItem();
        }

        if (mouseWheel.y > 0)
        {
            PrevItem();
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

        ChoiseObject(itemsImage[currentInventoryItem], true);

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

        ChoiseObject(itemsImage[currentInventoryItem], true);

        if (inventory[currentInventoryItem])
        {
            inventory[currentInventoryItem].gameObject.SetActive(true);
            //inventory[currentInventoryItem].PlayPickupSound();
        }

        Debug.Log(currentInventoryItem);
    }

    public void TakeItem(InventoryItem target)
    {
        int index = GetAvailableIndex(target);
        if (index >= 0)
        {
            inventory[index] = target;

            GameObject item = target.gameObject;
            SaveCoutObject(index, target);    //индекс увеличивается даже если предмет этого типа есть в инвентаре


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
            DelCountObject(currentItem);
        }
    }

    private void UseItem()
    {
        if (inventory[currentInventoryItem])
        {
            if (inventory[currentInventoryItem].gameObject.TryGetComponent(out InteractObject interactObject))
            {
                interactObject.UseObject();
                inventory[currentInventoryItem].SaveDelObject();
                InventoryItem item = inventory[currentInventoryItem];
                countObjects[currentInventoryItem].text = item.CountObject().ToString();
            }
        }
    }
    private void HideAllItems()
    {
        foreach (GameObject image in itemsImage)
        {
            if (image)
                ChoiseObject(image, false);
        }
        foreach (InventoryItem item in inventory)
        {
            if (item)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
    private int GetAvailableIndex(InventoryItem itemAdd)
    {
        int index = 0;
        for (int i = 0; i < MaxInventoryItems; i++)
        {
            InventoryItem item = inventory[i];
            if (item == null)
            {
                index = i;
                break;
            }
            else if (inventory[i] == itemAdd)
            {
                Destroy(itemAdd);
                index = i;
                break;                
            }
        }
        Debug.Log(index + "индекс");
        return index;
    }
    public void Interact(RaycastHit hit)
    {
        if (hit.transform)
        {
            GameObject target = hit.transform.gameObject;
            if (target.TryGetComponent(out InventoryItem item))
            {
                TakeItem(item);
            }
        }
    }

    private void ChoiseObject(GameObject image, bool isActive)
    {
        Debug.Log(image);
        image.TryGetComponent(out UnityEngine.UI.Image sprite);
        Debug.Log(sprite + "картинка для затемнения");
        if (isActive)
            sprite.color = new Color32(255, 255, 255, 255);
        else
            sprite.color = new Color32(142, 142, 142, 255);
    }

    private void DelCountObject(InventoryItem currentItem)
    {
        itemsImage[currentInventoryItem].TryGetComponent(out UnityEngine.UI.Image itemImage);
        if (currentItem.CountObject() < 2)
        {
            itemImage.sprite = nonSprite;
            inventory[currentInventoryItem] = null;
        }
        else
            TakeItem(currentItem);   //надо сделать чтобы в руке появлялась копия предмета полсе его выкидывания

        currentItem.SaveDelObject();
        countObjects[currentInventoryItem].text = currentItem.CountObject().ToString();
    }

    private void SaveCoutObject(int index, InventoryItem target)
    {
        if (itemsImage[index].TryGetComponent(out UnityEngine.UI.Image spriteItem))
        {
            spriteItem.sprite = target.GetSprite();
            target.SaveObject();
            countObjects[index].text = target.CountObject().ToString();
        }
    }

}
