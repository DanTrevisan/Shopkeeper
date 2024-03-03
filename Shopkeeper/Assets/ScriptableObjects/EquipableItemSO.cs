using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItemSO : ScriptableObject
{
    public enum ItemType
    {
        HAT,
        TOP,
        BOTTOM,
        SHOES
    }
    public string itemName;
    public Sprite shopSprite;
    public Sprite ingameSprite;
    public string itemDescription;
    public ItemType itemType;
}
