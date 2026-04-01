using UnityEngine;

public class KeyItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private bool key = false;

    [SerializeField] private Inventory inventory = null;

    Item item;

    public enum KeyTypes
    {
        Office,
        TestChamber,
        SurgicalRoom,
        Lab
    };

    public KeyTypes keytypes;

    public void Start()
    {
        item = GetComponent<Item>();
    }

    public void Interact()
    {
        if (key)
        {
            if (keytypes == KeyTypes.Office)
            {
                inventory.hasOfficeKey = true;
                item.PickUpItem();
            }
            else if (keytypes == KeyTypes.TestChamber)
            {
                inventory.hasTestChamberKey = true;
                item.PickUpItem();
            }
            else if (keytypes == KeyTypes.Lab)
            {
                inventory.hasLabKey = true;
                item.PickUpItem();
            }
            else if(keytypes == KeyTypes.SurgicalRoom)
            {
                inventory.hasSurgicalRoomAKey = true;
                item.PickUpItem();
            }
        }
    }
}
