//Luis
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;
    [SerializeField] private int MAX_SIZE = 16;

    public Inventory ()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if(item.IsStackable())
        {   // If stackable, update item amount if already in inventory
            bool itemAlreadyInInventory = false;
            foreach(Item inventoryItem in itemList)
            { 
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount += item.amount;
                    Debug.Log("Incrementing " + item.itemType + " amount from inventory to " + item.amount);
                    itemAlreadyInInventory = true;
                }
            }
            if(!itemAlreadyInInventory)
            { //If stackable, add item as a new item if NOT already in inventory (if possible)
                if (itemList.Count >= 0 && itemList.Count < MAX_SIZE - 1)
                {
                    itemList.Add(item);
                    Debug.Log("item list count is now " + itemList.Count);
                }
                else { Debug.Log("Inventory is full."); }
            }
        }
        else
        { //Add non-stackable item as new item if possible
            if (itemList.Count >= 0 && itemList.Count < MAX_SIZE - 1)
            {
                itemList.Add(item);
                Debug.Log("item list count is now " + itemList.Count);
            }
            else { Debug.Log("Inventory is full."); }
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {   // If stackable, update item amount if already in inventory
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    //inventoryItem.amount -= item.amount;
                    inventoryItem.amount--;
                    Debug.Log("Decrementing " + item.itemType + " amount from inventory to " + item.amount);
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            { //Remove item if amount was decremented to <= 0
                itemList.Remove(itemInInventory);
            }
        }
        else
        { //Remove non-stackable item if possible
            itemList.Remove(item);
            Debug.Log("Removing " + item.itemType + " from inventory.");
        }
        Debug.Log("item list count is now " + itemList.Count);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }

    public int GetMaxSize()
    {
        return MAX_SIZE;
    }
}