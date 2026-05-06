using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class KeyItemController : MonoBehaviour, IInteractable
{
    [SerializeField] private bool key = false;

    [SerializeField] private Inventory inventory = null;

    Item item;

    public GameObject vent;
    private Animator ventAnim;
    private AudioSource ventSource;

    private AudioSource gasSource;
    public GameObject audioObject;
    public GameObject gas;
    public GameObject valve;
    ValveController controller;

    public enum KeyTypes
    {
        Office,
        TestChamber,
        SurgicalRoom,
        Lab,
        SecurityOffice
    };

    public KeyTypes keytypes;

    public void Start()
    {
        item = GetComponent<Item>();
        ventAnim = vent.GetComponent<Animator>();
        ventSource = vent.GetComponent<AudioSource>();
        gasSource = audioObject.GetComponent<AudioSource>();
        controller = valve.GetComponent<ValveController>();
    }

    public void Interact()
    {
        if (key)
        {
            if (keytypes == KeyTypes.Office)
            {
                inventory.hasOfficeKey = true;
                item.PickUpItem();
                gasSource.Play();
                controller.isGasOn = true;
                gas.SetActive(true);
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
            else if (keytypes == KeyTypes.SecurityOffice)
            {
                inventory.hasSecurityRoomKey = true;
                item.PickUpItem();
                ventSource.Play();
                ventAnim.Play("VentFall");
            }
        }
    }
}
