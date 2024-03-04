using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EquipScreen : MonoBehaviour
{
    public GameObject itemObjectPrefab;
    public List<ItemObject> itemObjectsList;
    [SerializeField] private GameObject PanelObject;
    private ItemObject m_itemSelected;
    [HideInInspector] private PlayerInventory m_playerInventory;
    [SerializeField] private GameObject ButtonEquip;
    [SerializeField] private GameObject ButtonUnequip;

    [SerializeField] private Image img_TopSlot;
    [SerializeField] private Image img_HatSlot;
    [SerializeField] private Image img_BottomSlot;
    [SerializeField] private Image img_ShoesSlot;
    [SerializeField] private EquipButtonSlot btn_TopSlot;
    [SerializeField] private EquipButtonSlot btn_HatSlot;
    [SerializeField] private EquipButtonSlot btn_BottomSlot;
    [SerializeField] private EquipButtonSlot btn_ShoesSlot;
    [SerializeField] private Sprite emptySlotSprite;

    private EquipButtonSlot m_lastBtnSelected = null;
    void OnEnable()
    {
        m_playerInventory = FindObjectOfType<PlayerInventory>();
        ButtonEquip.gameObject.SetActive(false);
        ButtonUnequip.gameObject.SetActive(false);

        btn_BottomSlot.myButton.onClick.AddListener(BottomClicked);
        btn_HatSlot.myButton.onClick.AddListener(HatClicked);
        btn_TopSlot.myButton.onClick.AddListener(TopClicked);
        btn_ShoesSlot.myButton.onClick.AddListener(ShoesClicked);
        m_lastBtnSelected = null;
        ResetSlotButtons();
        SetInventoryItems();
        SetEquippedItems();
    }

    private void ResetSlotButtons()
    {
        btn_ShoesSlot.SetSelected(false);
        btn_HatSlot.SetSelected(false);
        btn_BottomSlot.SetSelected(false);
        btn_TopSlot.SetSelected(false);
    }

    private void ShoesClicked()
    {
        ResetSlotButtons();
        ButtonEquip.gameObject.SetActive(false);
        ButtonUnequip.gameObject.SetActive(true);
        btn_ShoesSlot.SetSelected(true);
        m_lastBtnSelected = btn_ShoesSlot;
        SetItem(null,true);
    }

    private void TopClicked()
    {
        ResetSlotButtons();
        ButtonEquip.gameObject.SetActive(false);
        ButtonUnequip.gameObject.SetActive(true);
        btn_TopSlot.SetSelected(true);
        m_lastBtnSelected = btn_TopSlot;
        SetItem(null, true);

    }

    private void HatClicked()
    {
        ResetSlotButtons();
        ButtonEquip.gameObject.SetActive(false);
        ButtonUnequip.gameObject.SetActive(true);
        btn_HatSlot.SetSelected(true);
        m_lastBtnSelected = btn_HatSlot;
        SetItem(null, true);

    }

    private void BottomClicked()
    {
        ResetSlotButtons();
        ButtonEquip.gameObject.SetActive(false);
        ButtonUnequip.gameObject.SetActive(true);
        btn_BottomSlot.SetSelected(true);
        m_lastBtnSelected = btn_BottomSlot;
        SetItem(null, true);

    }

    public void PressedUnequip()
    {
        if(m_lastBtnSelected == btn_BottomSlot)
        {
            m_playerInventory.UnequipItemFromMenu(m_playerInventory.GetEquip(EquipableItemSO.ItemType.BOTTOM));
        }
        else if(m_lastBtnSelected == btn_ShoesSlot)
        {
            m_playerInventory.UnequipItemFromMenu(m_playerInventory.GetEquip(EquipableItemSO.ItemType.SHOES));

        }
        else if (m_lastBtnSelected == btn_TopSlot)
        {
            m_playerInventory.UnequipItemFromMenu(m_playerInventory.GetEquip(EquipableItemSO.ItemType.TOP));

        }
        else if (m_lastBtnSelected == btn_HatSlot)
        {
            m_playerInventory.UnequipItemFromMenu(m_playerInventory.GetEquip(EquipableItemSO.ItemType.HAT));
        }
        SetEquippedItems();
    }

    private void SetEquippedItems()
    {
        EquipableItemSO hatEquip = m_playerInventory.GetEquip(EquipableItemSO.ItemType.HAT);
        if (hatEquip != null)
        {
            img_HatSlot.sprite = hatEquip.shopSprite;
        }
        else
        {
            img_HatSlot.sprite = emptySlotSprite;
        }

        EquipableItemSO topEquip = m_playerInventory.GetEquip(EquipableItemSO.ItemType.TOP);
        if (topEquip != null)
        {
            img_TopSlot.sprite = topEquip.shopSprite;
        }
        else
        {
            img_TopSlot.sprite = emptySlotSprite;
        }

        EquipableItemSO bottomEquip = m_playerInventory.GetEquip(EquipableItemSO.ItemType.BOTTOM);
        if (bottomEquip != null)
        {
            img_BottomSlot.sprite = bottomEquip.shopSprite;
        }
        else
        {
            img_BottomSlot.sprite = emptySlotSprite;
        }

        EquipableItemSO shoesEquip = m_playerInventory.GetEquip(EquipableItemSO.ItemType.SHOES);
        if (shoesEquip != null)
        {
            img_ShoesSlot.sprite = shoesEquip.shopSprite;
        }
        else
        {
            img_ShoesSlot.sprite = emptySlotSprite;
        }
    }

    private void SetInventoryItems()
    {
        if (m_playerInventory != null)
        {
            foreach (var item in m_playerInventory.getInventory())
            {
                GameObject itemObject = Instantiate(itemObjectPrefab, PanelObject.transform);
                ItemObject io = itemObject.GetComponent<ItemObject>();
                io.SetupItemObject(item);
                itemObjectsList.Add(io);
            }
        }
    }

    internal void SetItem(ItemObject itemSelected, bool isFromUnequip)
    {
        m_itemSelected = itemSelected;
        if (!isFromUnequip)
        {
            ButtonEquip.gameObject.SetActive(true);
            ButtonUnequip.gameObject.SetActive(false);
            m_lastBtnSelected = null;

        }


        foreach (var item in itemObjectsList)
        {
            if (itemSelected == item)
                continue;
            item.SetSelected(false);
        }
    }

    public void EquipItem()
    {
        m_playerInventory.EquipItem(m_itemSelected.GetEquippable());
        SetEquippedItems();
    }

    private void OnDisable()
    {
        CleanItemsOnView();
        CleanSelection();
    }

    private void CleanSelection()
    {
        foreach (var item in itemObjectsList)
        {
            item.SetSelected(false);
        }
    }
    private void CleanItemsOnView()
    {
        CleanSelection();
        foreach (var item in itemObjectsList)
        {
            Destroy(item.gameObject);
        }
        itemObjectsList = new List<ItemObject>();
    }
}
