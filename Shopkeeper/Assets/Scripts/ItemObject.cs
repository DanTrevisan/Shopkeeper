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
     
    private void OnEnable()
    {
        m_selectButton = this.GetComponent<Button>();
        m_selectButton.onClick.AddListener(SelectItem);
    }

    private void SelectItem()
    {
        m_isSelected = true;
        FindObjectOfType<ShopDescription>().SetItem(myItem);
    }

    public void SetupItemObject(EquipableItemSO item)
    {
        myImage.sprite = item.shopSprite;
        myItem = item;
    }
    private void OnDisable()
    {
        m_selectButton.onClick.RemoveListener(SelectItem);

    }
}
