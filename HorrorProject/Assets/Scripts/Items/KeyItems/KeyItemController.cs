using UnityEngine;

public class KeyItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private bool door = false;
    [SerializeField] private bool key = false;

    [SerializeField] private Inventory inventory = null;

    private InteractionController doorObject;

    private void Start()
    {
        if (door)
        {
            doorObject = GetComponent<InteractionController>();
        }
    }

    public void Interact()
    {
        if (door)
        {
            doorObject.PlayAnimation();
        }
        else if (key)
        {
            inventory.hasKey = true;
            gameObject.SetActive(false);
        }
    }
}
