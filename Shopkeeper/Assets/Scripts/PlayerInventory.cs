using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<EquipableItemSO> m_inventory;
    private EquipableItemSO m_hatSlot;
    private EquipableItemSO m_topSlot;
    private EquipableItemSO m_bottomSlot;
    private EquipableItemSO m_shoesSlot;

    [SerializeField] private SpriteRenderer img_TopSlot;
    [SerializeField] private SpriteRenderer img_HatSlot;
    [SerializeField] private SpriteRenderer img_BottomSlot;
    [SerializeField] private SpriteRenderer img_ShoesSlot;

    private void Start()
    {
        m_inventory = new List<EquipableItemSO>();
    }
    public void addToInventory(EquipableItemSO itemToAdd)
    {
        m_inventory.Add(itemToAdd);
    }
    public void removeFromInventory(EquipableItemSO itemToRemove)
    {
        UnequipItem(itemToRemove);
        m_inventory.Remove(itemToRemove);
    }
    public List<EquipableItemSO> getInventory()
    {
        return m_inventory;
    }
    public void EquipItem(EquipableItemSO item)
    {
        switch (item.itemType)
        {
            case EquipableItemSO.ItemType.TOP:
                m_topSlot = item;
                img_TopSlot.sprite = item.ingameSprite;
                break;
            case EquipableItemSO.ItemType.HAT:
                m_hatSlot = item;
                img_HatSlot.sprite = item.ingameSprite;
                break;
            case EquipableItemSO.ItemType.BOTTOM:
                m_bottomSlot = item;
                img_BottomSlot.sprite = item.ingameSprite;
                break;
            case EquipableItemSO.ItemType.SHOES:
                m_shoesSlot = item;
                img_ShoesSlot.sprite = item.ingameSprite;
                break;
        }
    }

    public EquipableItemSO GetEquip(EquipableItemSO.ItemType itemType)
    {
        switch (itemType)
        {
            case EquipableItemSO.ItemType.TOP:
                return m_topSlot;
            case EquipableItemSO.ItemType.HAT:
                return m_hatSlot;
            case EquipableItemSO.ItemType.BOTTOM:
                return m_bottomSlot;
            case EquipableItemSO.ItemType.SHOES:
                return m_shoesSlot;
                default: return null;
        }
    }
    public void UnequipItem(EquipableItemSO equip)
    {
        int countCopies = 0;
        foreach(var item in m_inventory)
        {
            if (equip.Equals(item))
            {
                countCopies++;
            }
        }
        //Used to be unequip items sold only if you have one of that item. If you don't, you don't need to unequip the item.
        if(countCopies == 1)
        {
            switch (equip.itemType)
            {
                case EquipableItemSO.ItemType.TOP:
                    m_topSlot = null;
                    img_TopSlot.sprite = null;
                    break;
                case EquipableItemSO.ItemType.HAT:
                    m_hatSlot = null;
                    img_HatSlot.sprite = null;
                    break;
                case EquipableItemSO.ItemType.BOTTOM:
                    m_bottomSlot = null;
                    img_BottomSlot.sprite = null;
                    break;
                case EquipableItemSO.ItemType.SHOES:
                    m_shoesSlot = null;
                    img_ShoesSlot.sprite = null;
                    break;
            }
        }
    }

    public void UnequipItemFromMenu(EquipableItemSO equip)
    {
        switch (equip.itemType)
        {
            case EquipableItemSO.ItemType.TOP:
                m_topSlot = null;
                img_TopSlot.sprite = null;
                break;
            case EquipableItemSO.ItemType.HAT:
                m_hatSlot = null;
                img_HatSlot.sprite = null;
                break;
            case EquipableItemSO.ItemType.BOTTOM:
                m_bottomSlot = null;
                img_BottomSlot.sprite = null;
                break;
            case EquipableItemSO.ItemType.SHOES:
                m_shoesSlot = null;
                img_ShoesSlot.sprite = null;
                break;
        }
    }
 }
