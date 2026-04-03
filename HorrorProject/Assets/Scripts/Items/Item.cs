using TMPro;
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

    public TMP_Text collectionText;
    public GameObject collectionUI;
    Timer timer;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        timer = collectionUI.GetComponent<Timer>();
    }

    public void PickUpItem()
    {
        int leftOverItems = inventoryManager.AddItem(itemName, quantity, image, itemDescription);
        if (leftOverItems <= 0)
        {
            collectionUI.SetActive(true);
            collectionText.text = itemName + " added to inventory";
            timer.StartTimer();
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
    }
}
