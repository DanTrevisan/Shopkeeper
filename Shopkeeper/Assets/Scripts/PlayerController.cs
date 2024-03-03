using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _Speed;
    Vector2 _Movement;
    Rigidbody2D _Rigidbody;

    private Input InputMap;
    private InputAction InteractAction;
    [SerializeField] private InteractionCollider InteractionCollider;

    [SerializeField] private ShopEventChannelSO channelOpenShop;
    private void OnMovement(InputValue value )
    {
        _Movement = value.Get<Vector2>();
    }

    private void Awake()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        InputMap = new Input();
        InteractAction = InputMap.Gameplay.Interact;
        InteractAction.Enable();
        InteractAction.performed += Interact;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (GameManager.CurrentState == GameManager.GameState.STATE_PLAYING)
            if(InteractionCollider.lastInventoryCollider != null)
            {
                channelOpenShop.RaiseEvent(InteractionCollider.lastInventoryCollider);
                GameManager.CurrentState = GameManager.GameState.STATE_PAUSED;
            }
    }

    private void FixedUpdate()
    {
        if(GameManager.CurrentState == GameManager.GameState.STATE_PLAYING)
        _Rigidbody.velocity = _Movement * _Speed;
    }

    private void OnDisable()
    {
        InteractAction.Disable();
        InteractAction.performed -= Interact;
    }
}
