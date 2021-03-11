//Luis
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> itemList;
    [SerializeField] private int MAX_SIZE = 16;

    public Inventory ()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Sword, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Key, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Shield, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Document, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Document, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Coin, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.Document, amount = 1 });
        Debug.Log("item list count = " + itemList.Count);
    }

    public void AddItem(Item item)
    {
        if(itemList.Count >= 0 && itemList.Count < MAX_SIZE - 1) { itemList.Add(item); }
        else { Debug.Log("Inventory is full."); }
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