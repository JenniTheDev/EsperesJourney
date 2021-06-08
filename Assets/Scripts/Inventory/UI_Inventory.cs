//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private DialogueManager DManager;

    [SerializeField] private Transform itemSlotContainer;
    [SerializeField] private Transform itemSlotTemplate;
    private Rigidbody2D playerRB;

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
        DManager = FindObjectOfType<DialogueManager>();
    }

    public void SetPlayerRB (Rigidbody2D playerRB)
    {
        this.playerRB = playerRB;
    }
   
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        //this.gameObject.SetActive(false);
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
        X_MAX = inventory.GetMaxSize();
        RefreshInventoryItems();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            else { Destroy(child.gameObject); }
        }
        int x = 0;
        int y = 0;
        float itemSlotCellSize = 58.5f;

        foreach (Item item in inventory.GetItemList())
        {

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            //itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
            //{
            //    //drop item
            //    Item duplicateItem = new Item { itemType = item.itemType, amount = item.amount };
            //    inventory.RemoveItem(item);
            //    ItemWorld.DropItem(playerRB.position, item);
            //};

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize-4);
            
            ///////////////
            GameObject useButtonObj = DialogueManager.GetChildWithName(itemSlotRectTransform.gameObject, "Use_Button");
            GameObject dropButtonObj = DialogueManager.GetChildWithName(itemSlotRectTransform.gameObject, "Drop_Button");
            Button useButton = useButtonObj.GetComponent<Button>();
            Button dropButton = dropButtonObj.GetComponent<Button>();

            Image image = useButtonObj.transform.Find("Image").GetComponent<Image>();
            if (image == null) { Debug.Log("couldnt find image :/"); }
            Text uiText = useButtonObj.transform.Find("Text").GetComponent<Text>();
            if (uiText == null) { Debug.Log("couldnt find text :/"); }

            image.sprite = item.GetSprite();
            setItemOnClick(useButton, dropButton, item);
            ///////////////
            
            //update item amount txt
            if (item.amount > 1) { uiText.text = item.amount.ToString(); }
            else { uiText.text = ""; }

            x++;
            //reset x and move y down to start filling second row with items
            if(x > (X_MAX / 2) - 1)
            {
                x = 0;
                y--;
            }
        }
    }

    public void ToggleInventory()
    { 
        if (this.gameObject.activeSelf) { this.gameObject.SetActive(false); }
        else if (!this.gameObject.activeSelf) { this.gameObject.SetActive(true); }
    }

    //try to make separate script for this region. Need access to inventory, and player stats. Also might need dialogue manager for documents.
    #region UI_itemUsageMethods
    public void setItemOnClick(Button useButton, Button dropButton, Item item)
    {
        switch (item.itemType)
        { 
            case Item.ItemType.Document:
                useButton.onClick.AddListener(delegate { useDocument(item); });
                dropButton.onClick.AddListener(delegate {
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
            case Item.ItemType.Key:
                useButton.onClick.AddListener(delegate { useKey(item); });
                dropButton.onClick.AddListener(delegate { 
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
            case Item.ItemType.Coin:
                useButton.onClick.AddListener(delegate { useCoin(item); });
                dropButton.onClick.AddListener(delegate { 
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
            case Item.ItemType.ManaPotion:
                useButton.onClick.AddListener(delegate { useManaPotion(item); });
                dropButton.onClick.AddListener(delegate { 
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
            case Item.ItemType.Shield:
                useButton.onClick.AddListener(delegate { useShield(item); });
                dropButton.onClick.AddListener(delegate { 
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
            case Item.ItemType.Sword:
                useButton.onClick.AddListener(delegate { useSword(item); });
                dropButton.onClick.AddListener(delegate { 
                    ItemWorld.DropItem(playerRB.position, item);
                    inventory.RemoveItem(item);
                });
                return;
        }
    }

    private void useDocument(Item item)
    {
        //Gonna need playerinputmanager to call interactInputEvent()
        
        
        if (item.itemType == Item.ItemType.Document)
        {
            DManager.TriggerDialogue(item.documentDialogue);
        }

        return;
    }

    private void useKey(Item item)
    {
        inventory.RemoveItem(item);
        return;
    }

    private void useManaPotion(Item item)
    {
        inventory.RemoveItem(item);
        return;
    }

    private void useShield(Item item)
    {
        inventory.RemoveItem(item);
        return;
    }

    private void useSword(Item item)
    {
        inventory.RemoveItem(item);
        return;
    }

    private void useCoin(Item item)
    {
        inventory.RemoveItem(item);
        return;
    }
    #endregion
}
