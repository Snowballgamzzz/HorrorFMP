using UnityEngine;

public class VentFall : MonoBehaviour, IInteractable
{
    public GameObject vent;
    private Animator ventAnim;
    private AudioSource source;

    private void Start()
    {
        ventAnim = vent.GetComponent<Animator>();
        source = vent.GetComponent<AudioSource>();
    }

    public void Interact()
    {
        source.Play();
        ventAnim.Play("VentFall");
    }
}
