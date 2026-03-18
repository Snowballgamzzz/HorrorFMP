using System.Collections;
using UnityEngine;

public class AmmoBox : MonoBehaviour, IInteractable
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
