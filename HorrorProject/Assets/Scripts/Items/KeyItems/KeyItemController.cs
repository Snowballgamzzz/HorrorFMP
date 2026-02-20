using UnityEngine;

public class KeyItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private bool key = false;

    [SerializeField] private Inventory inventory = null;

    public void Interact()
    {
        if (key)
        {
            inventory.hasKey = true;
            gameObject.SetActive(false);
        }
    }
}
