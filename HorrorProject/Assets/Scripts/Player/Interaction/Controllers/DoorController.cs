using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    public bool isDoorOpen = false;

    private void Start()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (!isDoorOpen)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f);
            isDoorOpen = true;
        }
        else if (isDoorOpen)
        {
            doorAnim.Play("DoorClose", 0, 0.0f);
            isDoorOpen = false;
        }
    }
}
