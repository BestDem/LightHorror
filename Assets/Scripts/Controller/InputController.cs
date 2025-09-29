using UnityEngine;
using UnityEngine.Animations;

public class InputController : MonoBehaviour
{
    public Vector2 movement;
    public Vector2 mouse;
    public bool isFire;

    private void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mouse.x = Input.GetAxis("Mouse X");
        mouse.y = Input.GetAxis("Mouse Y");

        isFire = Input.GetButtonDown("Fire1");
    }
}
