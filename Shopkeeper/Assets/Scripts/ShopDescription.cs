using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopDescription : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemDesc;
    [SerializeField] private TextMeshProUGUI itemPrice;

    public void SetItem(EquipableItemSO equip)
    {
        itemImage.sprite = equip.shopSprite;
        itemName.text= equip.name;
        itemType.text = equip.itemType.ToString();
        itemDesc.text = equip.itemDescription;
        itemPrice.text = "Price: " + equip.price;
    }

}
