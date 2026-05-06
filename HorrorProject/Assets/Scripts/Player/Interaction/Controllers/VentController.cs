using UnityEngine;

public class VentController : MonoBehaviour, IInteractable
{
    private Animator ventAnim;
    private AudioSource source;

    private void Start()
    {
        ventAnim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        source.Play();
        ventAnim.Play("VentOpen");
    }
}
