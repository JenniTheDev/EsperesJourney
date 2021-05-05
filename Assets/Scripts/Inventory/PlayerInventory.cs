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

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        uiInventory.SetPlayerRB(rb);
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
