using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    // Start is called before the first frame update
    public Image myImage;
    private EquipableItemSO myItem;
    public bool m_isSelected = false;
    public Button m_selectButton;
    public bool isShopPrefab = true;
    [SerializeField] private Image selector;
    private void OnEnable()
    {
        m_selectButton = this.GetComponent<Button>();
        m_selectButton.onClick.AddListener(SelectItem);
    }

    private void SelectItem()
    {
        selector.gameObject.SetActive(true);
        if(isShopPrefab)
            FindObjectOfType<ShopScreen>().SetItem(this);
        else
            FindObjectOfType<EquipScreen>().SetItem(this,false);

    }

    public void SetupItemObject(EquipableItemSO item)
    {
        myImage.sprite = item.shopSprite;
        myItem = item;
    }
    public void SetSelected(bool selected)
    {
        m_isSelected = selected;
        selector.gameObject.SetActive(selected);
    }
    public EquipableItemSO GetEquippable()
    {
        return myItem;
    }
    private void OnDisable()
    {
        m_selectButton.onClick.RemoveListener(SelectItem);

    }
    
}
