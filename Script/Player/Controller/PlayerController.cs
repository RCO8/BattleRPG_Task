//using System;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.SceneManagement;
//using static UnityEditor.Experimental.GraphView.GraphView;

//public enum InputActionMode : byte
//{
//    Battle,
//    Field
//}

//public class PlayerController : MonoBehaviour
//{
//    public PlayerInput inputActions { get; private set; }
//    private InputActionAsset _inputActionAsset;
//    private InputActionMap _battleMap;
//    private InputActionMap _fieldMap;
//    public PlayerInput.BattleActions battleActions { get; private set; }
//    public PlayerInput.FieldActions fieldActions { get; private set; }

//    private Player _player;

//    public event Action<Vector2> OnBattleMoveEvent;
//    public event Action OnBattleJumpEvent;
//    public event Action OnBattleAttackEvent;

//    public event Action<Vector2> OnFieldMoveEvent;

//    public bool isField = false;
//    private PlatformEffector2D _effector;
//    private BoxCollider2D _boxCollider;

//    private void Awake()
//    {
//        inputActions = new PlayerInput();
//        battleActions = inputActions.Battle;
//        fieldActions = inputActions.Field;
//        _inputActionAsset = inputActions.asset;
//        _battleMap = _inputActionAsset.FindActionMap(Define.ACTIONASSET_BATTLE);
//        _fieldMap = _inputActionAsset.FindActionMap(Define.ACTIONASSET_FIELD);

//        SetBattleActions();
//        SetFieldActions();

//        _player = GetComponent<Player>();

//        _effector = GetComponent<PlatformEffector2D>();
//        _boxCollider = GetComponent<BoxCollider2D>();
//    }

//    private void OnEnable()
//    {
//        inputActions.Enable();
//        _battleMap.Enable();
//        _fieldMap.Enable();
//    }

//    private void OnDisable()
//    {
//        _battleMap.Disable();
//        _fieldMap.Disable();
//        inputActions.Disable();
//    }

//    private void Start()
//    {
//        ApplyPlayerMode(isField);
//    }

//    public void ApplyPlayerMode(bool mode)
//    {
//        if (mode) ChangeInputActionMode(InputActionMode.Field);
//        else ChangeInputActionMode(InputActionMode.Battle);
//    }

//    private void SetBattleActions()
//    {
//        battleActions.Move.performed += OnBattleMove;
//        battleActions.Move.canceled += OnStopBattleMove;
//        battleActions.Jump.started += OnBattleJump;
//        battleActions.Attack.started += OnBattleAttack;
//        battleActions.Menu.started += OnMenu;
//    }

//    private void SetFieldActions()
//    {
//        fieldActions.Move.performed += OnFieldMove;
//        fieldActions.Move.canceled += OnStopFieldMove;
//        fieldActions.Menu.started += OnMenu;
//        fieldActions.Interaction.started += OnInteraction;
//    }

//    private void OnBattleMove(InputAction.CallbackContext _value)
//    {
//        Vector2 moveInput = _value.ReadValue<Vector2>().normalized;
//        OnBattleMoveEvent?.Invoke(moveInput);
//    }

//    private void OnStopBattleMove(InputAction.CallbackContext _value)
//    {
//        Vector2 moveInput = Vector2.zero;
//        OnBattleMoveEvent?.Invoke(moveInput);
//    }

//    private void OnBattleJump(InputAction.CallbackContext _value)
//    {
//        if (_player.attack.isAttacking) return;

//        OnBattleJumpEvent?.Invoke();
//    }

//    private void OnBattleAttack(InputAction.CallbackContext _value)
//    {
//        OnBattleAttackEvent?.Invoke();
//    }

//    private void OnMenu(InputAction.CallbackContext _value)
//    {

//    }

//    private void OnFieldMove(InputAction.CallbackContext _value)
//    {
//        Vector2 moveInput = _value.ReadValue<Vector2>().normalized;

//        OnFieldMoveEvent?.Invoke(moveInput);
//    }

//    private void OnStopFieldMove(InputAction.CallbackContext _value)
//    {
//        Vector2 moveInput = Vector2.zero;

//        OnFieldMoveEvent?.Invoke(moveInput);
//    }

//    private void OnInteraction(InputAction.CallbackContext _value)
//    {
//        if (_player.npcTrigger)
//        {
//            //적인지 일반 npc인지에 따라 달라진다.
//            _player.npc.GetComponent<INPCInteraction>().NPCInteraction();
//        }
//    }

//    public void ChangeInputActionMode(InputActionMode _inputActionMode)
//    {
//        switch (_inputActionMode)
//        {
//            case InputActionMode.Battle:
//                isField = false;
//                _fieldMap.Disable();
//                _battleMap.Enable();
//                _player.rb.gravityScale = 10.0f;
//                _effector.enabled = true;
//                _boxCollider.usedByEffector = true;
//                break;

//            case InputActionMode.Field:
//                isField = true;
//                _battleMap.Disable();
//                _fieldMap.Enable();
//                _player.rb.gravityScale = 0.0f;
//                _effector.enabled = false;
//                _boxCollider.usedByEffector = false;
//                break;
//        }
//    }
//}
