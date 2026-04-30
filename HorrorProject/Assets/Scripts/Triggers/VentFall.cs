using UnityEngine;

public class VentFall : MonoBehaviour, IInteractable
{
    public GameObject vent;
    private Animator ventAnim;

    private void Start()
    {
        ventAnim = vent.GetComponent<Animator>();
    }

    public void Interact()
    {
        ventAnim.Play("VentFall");
    }
}
