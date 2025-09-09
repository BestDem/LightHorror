using UnityEngine;

public class UseController : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private Transform head;
    private InputController inputController;
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
            if (hit.collider.TryGetComponent<IUsable>(out IUsable useObject))
            {
                aim.SetActive(true);
                if (inputController.isFire)
                    useObject.Use(head);
            }
            else
            {
                aim.SetActive(false);
            }
        }    
    }
}
