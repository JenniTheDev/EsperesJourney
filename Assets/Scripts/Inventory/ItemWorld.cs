using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item item;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        Debug.Log("Spawning " + itemWorld.GetItem().itemType);

        return itemWorld;
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public static ItemWorld DropItem (Vector3 dropPosition, Item item)
    { // +randomDir * 5f
        Vector3 randomDir = GetRandomDir();
        Debug.Log("RigidBody current position " + dropPosition);
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + randomDir * 1.9f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(randomDir * 5f, ForceMode2D.Impulse);
        return itemWorld;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
