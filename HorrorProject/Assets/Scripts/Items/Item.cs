using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Image image;

    [TextArea]
    [SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
    }

    public void PickUpItem()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, image, itemDescription);
        if (leftOverItems <= 0)
        {
            //Destroy(gameObject);
            this.gameObject.SetActive(false);
        }
        else
        {
            quantity = leftOverItems;
        }
    }
}
