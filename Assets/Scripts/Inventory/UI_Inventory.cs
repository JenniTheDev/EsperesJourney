//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    private int X_MAX;
    private int Y_MAX = 2;

    private void Awake()
    {
        //itemSlotContainer = transform.Find("itemSlotContainer");
        //if (itemSlotContainer == null) { Debug.LogError("itemSlotContainer was not found."); }
        //itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
        //if (itemSlotTemplate == null) { Debug.LogError("itemSlotTemplate was not found."); }
        //Debug.Log("hello " + itemSlotTemplate);
        this.gameObject.SetActive(false);
    }
   
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        //this.gameObject.SetActive(false);
        X_MAX = inventory.GetMaxSize();
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 58.5f;

        foreach (Item item in inventory.GetItemList())
        {

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize-4);
            Image image = itemSlotRectTransform.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            x++;
            if(x > (X_MAX / 2) - 1)
            {
                x = 0;
                y--;
            }
        }
    }

    public void ToggleInventory()
    {
        Debug.Log(this.gameObject.activeSelf);
        if (this.gameObject.activeSelf) { this.gameObject.SetActive(false); }
        else if (!this.gameObject.activeSelf) { this.gameObject.SetActive(true); }
        Debug.Log(this.gameObject.activeSelf);
    }
}
