using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject CanvasMain;
    [SerializeField] private GameObject CanvasEquip;
    [SerializeField] private ShopScreen CanvasShop;
    [SerializeField] private ShopEventChannelSO channelOpenShop;


    public void Awake()
    {
        channelOpenShop.OnEventRaised += OpenShopScreen;
    }
    public void OpenEquipScreen()
    {
        Debug.Log("open");
        CanvasMain.SetActive(false);
        CanvasEquip.SetActive(true);
        GameManager.CurrentState = GameManager.GameState.STATE_PAUSED;
    }

    public void CloseEquipScreen()
    {
        CanvasMain.SetActive(true);
        CanvasEquip.SetActive(false);
        GameManager.CurrentState = GameManager.GameState.STATE_PLAYING;

    }
    public void OpenShopScreen(ShopInventory inventory)
    {
        CanvasMain.SetActive(false);
        CanvasShop.myInventory = inventory;
        CanvasShop.gameObject.SetActive(true);
        GameManager.CurrentState = GameManager.GameState.STATE_PAUSED;

    }

    public void CloseShopScreen()
    {
        CanvasMain.SetActive(true);
        CanvasShop.gameObject.SetActive(false);
        GameManager.CurrentState = GameManager.GameState.STATE_PLAYING;

    }
}
