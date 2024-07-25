using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerInput;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerController_Battle : MonoBehaviour
{
    private PlayerInput_Battle _inputActions;
    private PlayerInput_Battle.BaseActions _battleActions;
    private Player_Battle _player;

    public event Action<Vector2> OnBattleMoveEvent;
    public event Action OnBattleJumpEvent;
    public event Action OnBattleAttackEvent;

    private void Awake()
    {
        _inputActions = new PlayerInput_Battle();
        _player = GetComponent<Player_Battle>();
        _battleActions = _inputActions.Base;

        SetBattleActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void SetBattleActions()
    {
        _battleActions.Move.performed += OnBattleMove;
        _battleActions.Move.canceled += OnStopBattleMove;
        _battleActions.Jump.started += OnBattleJump;
        _battleActions.Attack.started += OnBattleAttack;
        _battleActions.Menu.started += OnMenu;
    }

    private void OnBattleMove(InputAction.CallbackContext _value)
    {
        Vector2 moveInput = _value.ReadValue<Vector2>().normalized;
        OnBattleMoveEvent?.Invoke(moveInput);
    }

    private void OnStopBattleMove(InputAction.CallbackContext _value)
    {
        Vector2 moveInput = Vector2.zero;
        OnBattleMoveEvent?.Invoke(moveInput);
    }

    private void OnBattleJump(InputAction.CallbackContext _value)
    {
        if(_player.attack.isAttacking) return;

        OnBattleJumpEvent?.Invoke();
    }

    private void OnBattleAttack(InputAction.CallbackContext _value)
    {
        OnBattleAttackEvent?.Invoke();
    }

    private void OnMenu(InputAction.CallbackContext _value)
    {

    }
}
