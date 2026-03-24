using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KeyDoorController : MonoBehaviour, IInteractable
{
    private Animator doorAnim;
    private bool isDoorOpen = false;

    [SerializeField] private int timeToShowUI = 1;
    [SerializeField] private GameObject showDoorLockedUI = null;

    [SerializeField] private Inventory inventory = null;
    [SerializeField] private InventoryManager inventoryManager = null;
    public ItemSlot[] itemSlot;

    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    [SerializeField] private string KeyName;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void Interact()
    {
        if (inventory.hasKey)
        {
            if (!isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorOpen", 0, 0.0f);
                isDoorOpen = true;
                InventoryUpdate();
                StartCoroutine(PauseDoorInteraction());
            }
            else if (isDoorOpen && !pauseInteraction)
            {
                doorAnim.Play("DoorClose", 0, 0.0f);
                isDoorOpen = false;
                StartCoroutine(PauseDoorInteraction());
            }
        }
        else
        {
            StartCoroutine(ShowDoorLocked());
        }
    }

    IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    IEnumerator ShowDoorLocked()
    {
        showDoorLockedUI.SetActive(true);
        yield return new WaitForSeconds(timeToShowUI);
        showDoorLockedUI.SetActive(false);
    }

    private void InventoryUpdate()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            ItemSlot itemSlotObject = itemSlot[i].GetComponent<ItemSlot>();

            if (itemSlotObject.itemName == KeyName)
            {
                Debug.Log("Key Found");
                itemSlotObject.quantity -= 1;
                itemSlotObject.quantityText.text = itemSlotObject.quantity.ToString();

                if (itemSlotObject.quantity <= 0)
                {
                    itemSlotObject.EmptySlot();
                }

            }
        }
    }

}
