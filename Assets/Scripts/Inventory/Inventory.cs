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
    public List<Item> GetItemList()
    {
        return itemList;
    }

    public int GetMaxSize()
    {
        return MAX_SIZE;
    }
}