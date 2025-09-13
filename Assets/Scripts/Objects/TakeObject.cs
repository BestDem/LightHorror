using UnityEngine;

public class TakeObject : MonoBehaviour, IUsable
{
    [SerializeField] private string keyObject;
    private Transform headTransform;
    private bool give = false;
    public void Use(Transform head)
    {
        headTransform = head;
        give = true;
    }

    void Update()
    {
        if (give)
        {
            transform.position = Vector3.Lerp(transform.position, headTransform.transform.position, 4 * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, headTransform.transform.position);
            if (distance < 1.5)
            {
                give = false;
                SaveObject();
                Destroy(gameObject);
            }

        }
    }

    public void SaveObject()
    {
        ObjectsData.Seinglinventory.SaveReceivedObjects(keyObject);
    }
}

