using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    private bool isColliding = false;

    public void Awake()
    {
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);

        //ItemWorld.SpawnItemWorld(new Vector3(10, 4), new Item { itemType = Item.ItemType.ManaPotion, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(10, 2), new Item { itemType = Item.ItemType.Sword, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(10, 0), new Item { itemType = Item.ItemType.Shield, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(10, -2), new Item { itemType = Item.ItemType.Document, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(15, 1), new Item { itemType = Item.ItemType.Key, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3(10, -6), new Item { itemType = Item.ItemType.Coin, amount = 1 });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check to see if player is already colliding with item in the same frame.
        if (isColliding) { return; }
        isColliding = true;

        ItemWorld itemWorld = collision.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            Debug.Log(itemWorld.GetItem().itemType + " was picked up!");
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    private void Update()
    {   //reset boolean after every frame.
        isColliding = false;
    }
}
