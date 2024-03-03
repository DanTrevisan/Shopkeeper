using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event Channel",
fileName = "VoidEventChannel")]
public class ShopEventChannelSO : ScriptableObject
{
    [Tooltip("The action to perform")]
    public UnityAction<ShopInventory> OnEventRaised;

    public void RaiseEvent(ShopInventory value)
    {
        if (OnEventRaised != null)
            OnEventRaised.Invoke(value);
    }
}
