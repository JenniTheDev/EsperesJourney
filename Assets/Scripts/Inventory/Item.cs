using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Sword,
        Shield,
        ManaPotion,
        Key,
        Coin,
        Document,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Coin: return ItemAssets.Instance.CoinSprite;
            case ItemType.Key: return ItemAssets.Instance.KeySprite;
            case ItemType.Document: return ItemAssets.Instance.DocumentSprite;
            case ItemType.ManaPotion: return ItemAssets.Instance.ManaPotionSprite;
            case ItemType.Sword: return ItemAssets.Instance.SwordSprite;
            case ItemType.Shield: return ItemAssets.Instance.ShieldSprite;
        }
    }
}
