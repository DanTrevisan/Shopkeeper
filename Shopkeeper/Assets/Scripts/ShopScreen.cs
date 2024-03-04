using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ShopScreen : MonoBehaviour
{
    public GameObject itemObjectPrefab;
    public List<ItemObject> itemObjectsList;
    [SerializeField] private GameObject PanelObject;
    private ItemObject m_itemSelected;
    [HideInInspector] public bool isBuying = true;
    [HideInInspector] public ShopInventory m_myInventory;
    [HideInInspector] private PlayerInventory m_playerInventory;
    [SerializeField] private TextMeshProUGUI sellButtontxt;
    [SerializeField] private ShopDescription PanelPreview;
    [SerializeField] private Button ButtonBuy;


    private void OnEnable()
    {
        ChanteToBuyView();
        PanelPreview.gameObject.SetActive(false);
        ButtonBuy.gameObject.SetActive(false);
        m_playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void SellBuyItem()
    {
        if(m_itemSelected != null)
        {
            EquipableItemSO itemCheck = m_itemSelected.GetEquippable();
            if (itemCheck != null && m_playerInventory!= null)
            {
                if(isBuying && GameManager.CurrentGold >= itemCheck.price)
                {
                    m_playerInventory.addToInventory(itemCheck);
                    GameManager.CurrentGold -= itemCheck.price;
                }
                else if (!isBuying)
                {
                    m_playerInventory.removeFromInventory(itemCheck);
                    GameManager.CurrentGold += itemCheck.price;
                    CleanItemsOnView();
                    PanelPreview.gameObject.SetActive(false);
                    ButtonBuy.gameObject.SetActive(false);
                    SetInventoryItems();
                }
            }
        }
    }

    private void CleanSelection()
    {
        foreach (var item in itemObjectsList)
        {
            item.SetSelected(false);
        }
    }

    internal void SetItem(ItemObject itemSelected)
    {
        m_itemSelected = itemSelected;
        PanelPreview.gameObject.SetActive(true);
        PanelPreview.SetItem(itemSelected.GetEquippable());
        ButtonBuy.gameObject.SetActive(true);
        foreach (var item in itemObjectsList)
        {
            if (itemSelected == item)
                continue;
            item.SetSelected(false);
        }
    }

    public void ChanteToBuyView()
    {
        PanelPreview.gameObject.SetActive(false);
        ButtonBuy.gameObject.SetActive(false);
        CleanItemsOnView();
        SetShopItems();
        isBuying = true;
    }

    public void ChangeToSellView()
    {
        PanelPreview.gameObject.SetActive(false);
        ButtonBuy.gameObject.SetActive(false);
        CleanItemsOnView();
        SetInventoryItems();
        isBuying = false;
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

    private void SetShopItems()
    {
        if (m_myInventory != null)
        {
            foreach (var item in m_myInventory.equipableItemSOs)
            {
                GameObject itemObject = Instantiate(itemObjectPrefab, PanelObject.transform);
                ItemObject io = itemObject.GetComponent<ItemObject>();
                io.SetupItemObject(item);
                itemObjectsList.Add(io);
            }
        }
    }

    private void SetInventoryItems()
    {
        if(m_playerInventory != null)
        {
            foreach(var item in m_playerInventory.getInventory())
            {
                GameObject itemObject = Instantiate(itemObjectPrefab, PanelObject.transform);
                ItemObject io = itemObject.GetComponent<ItemObject>();
                io.SetupItemObject(item);
                itemObjectsList.Add(io);
            }
        }
    }

    public void ChangeButtonTxt(bool isBuying)
    {
        if (isBuying)
            sellButtontxt.text = "Buy";
        else
            sellButtontxt.text = "Sell";

    }
}
