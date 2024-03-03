using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject CanvasMain;
    [SerializeField] public GameObject CanvasEquip;
    [SerializeField] public GameObject CanvasShop;
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
        CanvasShop.SetActive(true);
        GameManager.CurrentState = GameManager.GameState.STATE_PAUSED;

    }

    public void CloseShopScreen()
    {
        CanvasMain.SetActive(true);
        CanvasShop.SetActive(false);
        GameManager.CurrentState = GameManager.GameState.STATE_PLAYING;

    }
}
