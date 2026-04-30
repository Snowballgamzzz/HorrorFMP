using UnityEngine;

public class VentController : MonoBehaviour, IInteractable
{
    private Animator ventAnim;

    private void Start()
    {
        ventAnim = GetComponent<Animator>();
    }

    public void Interact()
    {
        ventAnim.Play("VentOpen");
    }
}
