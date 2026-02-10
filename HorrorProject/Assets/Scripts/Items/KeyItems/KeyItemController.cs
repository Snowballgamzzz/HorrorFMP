using UnityEngine;

public class KeyItemController : MonoBehaviour
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

    public void ObjectInteraction()
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
