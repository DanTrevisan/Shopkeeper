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

    // Start is called before the first frame update
    void OnEnable()
    {
        m_playerInventory = FindObjectOfType<PlayerInventory>();
        ButtonEquip.gameObject.SetActive(false);
        SetInventoryItems();
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

    internal void SetItem(ItemObject itemSelected)
    {
        m_itemSelected = itemSelected;
        ButtonEquip.gameObject.SetActive(true);
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
