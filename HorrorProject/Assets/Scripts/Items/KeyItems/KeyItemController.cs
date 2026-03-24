using UnityEngine;

public class KeyItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private bool key = false;

    [SerializeField] private Inventory inventory = null;

    Item item;

    public void Start()
    {
        item = GetComponent<Item>();
    }

    public void Interact()
    {
        if (key)
        {
            inventory.hasKey = true;
            item.PickUpItem();
        }
    }
}
