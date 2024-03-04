using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : MonoBehaviour
{
    public GameObject itemObjectPrefab;
    public List<ItemObject> itemObjectsList;
    [SerializeField] private GameObject PanelObject;
    [HideInInspector]public ShopInventory myInventory;
    private void OnEnable()
    {
        foreach(var item in itemObjectsList)
        {
            Destroy(item.gameObject);
        }
        itemObjectsList = new List<ItemObject>();
        if(myInventory != null)
        {
            foreach(var item in myInventory.equipableItemSOs)
            {
                GameObject itemObject = Instantiate(itemObjectPrefab, PanelObject.transform);
                ItemObject io = itemObject.GetComponent<ItemObject>();
                io.SetupItemObject(item);
                itemObjectsList.Add(io);
            }
        }
    }
}
