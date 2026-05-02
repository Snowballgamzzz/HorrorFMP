using UnityEngine;

public class ValveController : MonoBehaviour, IInteractable
{
    public GameObject gas;
    private Animator animator;

    public bool isGasOn;

    private void Start()
    {
        isGasOn = false;
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (isGasOn)
        {
            gas.SetActive(false);
            isGasOn = false;
            animator.Play("ValveTurn");
        }
    }
}
