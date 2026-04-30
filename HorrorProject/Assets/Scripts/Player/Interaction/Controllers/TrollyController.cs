using UnityEngine;

public class TrollyController : MonoBehaviour, IInteractable
{
    BlockedDoorController blockedDoor;
    public GameObject doorObject;

    private Animator trollyAnim;

    private void Start()
    {
        trollyAnim = GetComponent<Animator>();
        blockedDoor = doorObject.GetComponent<BlockedDoorController>(); 
    }

    public void Interact()
    {
        trollyAnim.Play("CartMovement");
        blockedDoor.isDoorBlocked = false;
    }
}
