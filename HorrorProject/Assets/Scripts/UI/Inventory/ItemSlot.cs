using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [Header("Item Data")]
    public string itemName;
    public int quantity;
    public Image itemImage;
    public bool isFull;
    public string itemDescription;
    public Image emptyImageSlot;

    [SerializeField] private int maxNumberOfItems;

    [Header("Item Slot")]
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image visualImage;

    public GameObject selectedShader;
    public bool thisItemSelected;

    [Header("Item Description")]
    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Image itemImage, string itemDescription)
    {
        //Check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }

        //Update Name
        this.itemName = itemName;

        //Update Image
        this.itemImage.sprite = itemImage.sprite;
        visualImage.sprite = itemImage.sprite;

        //Update Description
        this.itemDescription = itemDescription;

        //Update quantity
        this.quantity += quantity;

        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;

            //Return the leftovers
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        //Update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
    }

    public void OnLeftClick()
    {
        if (thisItemSelected)
        {
            bool usable = inventoryManager.UseItem(itemName);

            if (usable)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();

                if (this.quantity <= 0)
                {
                    EmptySlot();
                }
            }
        }
        else
        {
            inventoryManager.DeselectAllSlots();
            selectedShader.SetActive(true);
            thisItemSelected = true;
            itemDescriptionNameText.text = itemName;
            itemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = visualImage.sprite;

            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptyImageSlot.sprite;
            }
        }
    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptyImageSlot.sprite;

        itemDescriptionNameText.text = "";
        itemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptyImageSlot.sprite;
        itemDescription = "";

        itemName = "";
        quantity = 0;
        isFull = false;
    }
}
