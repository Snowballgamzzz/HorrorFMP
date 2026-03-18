using UnityEngine;

public class HealthBox : MonoBehaviour, IInteractable
{
    Item item;

    void Start()
    {
        item = GetComponent<Item>();
    }

    public void Interact()
    {
        item.PickUpItem();
        Destroy(this.gameObject);
    }
}
