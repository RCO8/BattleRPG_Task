using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
//using static PlayerInput;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController_Field : MonoBehaviour
{
    private PlayerInput_Field _inputActions;
    private PlayerInput_Field.BaseActions _fieldActions;
    private Player_Field _player;

    public event Action<Vector2> OnFieldMoveEvent;

    private void Awake()
    {
        _inputActions = new PlayerInput_Field();
        _player = GetComponent<Player_Field>();
        _fieldActions = _inputActions.Base;

        SetFieldActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void SetFieldActions()
    {
        _fieldActions.Move.performed += OnFieldMove;
        _fieldActions.Move.canceled += OnStopFieldMove;
        _fieldActions.Menu.started += OnMenu;
        _fieldActions.Interaction.started += OnInteraction;
    }

    private void OnMenu(InputAction.CallbackContext _value)
    {

    }

    private void OnFieldMove(InputAction.CallbackContext _value)
    {
        Vector2 moveInput = _value.ReadValue<Vector2>().normalized;
        
        OnFieldMoveEvent?.Invoke(moveInput);
    }

    private void OnStopFieldMove(InputAction.CallbackContext _value)
    {
        Vector2 moveInput = Vector2.zero;
        
        OnFieldMoveEvent?.Invoke(moveInput);
    }

    private void OnInteraction(InputAction.CallbackContext _value)
    {
        if(_player.isTrigger)
        {
            _player.npc.GetComponent<INPCInteraction>().NPCInteraction();
        }
    }
}
