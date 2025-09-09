using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

    }
}
