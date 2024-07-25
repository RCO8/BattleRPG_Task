//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Rendering.VirtualTexturing;
//using static UnityEditor.Experimental.GraphView.GraphView;

//public class Player : MonoBehaviour
//{
//    public Rigidbody2D rb;
//    public BoxCollider2D boxCollider;
//    public BoxCollider2D boxCollider_Weapon;
//    public RectTransform rectTransform; //위치 변경을 위해 추가
//    public PlayerController controller;
//    public PlayerMovement playerMovement;
//    public Animator animator;
//    public PlayerStateMachine stateMachine;
//    public PlayerAnimationData animationData;
//    public PlayerAttack attack;
//    public PlayerAnimationEvent animationEvent;
//    public PlayerStatHandler statHandler;
//    public PlayerHPSystem hpSystem;
//    public PlayerMPSystem mpSystem;

//    public SPUM_SpriteList spum_SpriteList;

//    public bool npcTrigger = false;
//    public Enemy npc;

//    private Coroutine _blinkCoroutine;

//    public event Action OnChangeStat;                //스탯바뀔 때, UI변경용 델리게이트

//    private void Awake()
//    {
//        if (CharacterManager.instance.player != null) Destroy(gameObject);
//        else
//        {
//            CharacterManager.instance.player = this;
//            transform.SetParent(CharacterManager.instance.transform);  //씬 전환할때 같이 따라오게
//        }

//        rb = GetComponent<Rigidbody2D>();
//        boxCollider = GetComponent<BoxCollider2D>();
//        rectTransform = GetComponent<RectTransform>();
//        controller = GetComponent<PlayerController>();
//        playerMovement = GetComponent<PlayerMovement>();
//        animator = GetComponentInChildren<Animator>();
//        attack = GetComponentInChildren<PlayerAttack>();
//        animationEvent = GetComponentInChildren<PlayerAnimationEvent>();
//        statHandler = GetComponentInChildren<PlayerStatHandler>();
//        hpSystem = GetComponent<PlayerHPSystem>();
//        mpSystem = GetComponent<PlayerMPSystem>();

//        stateMachine = new PlayerStateMachine(this);
//        animationData = new PlayerAnimationData();
//        animationData.Initialize();

//        //델리게이트
//        hpSystem.OnDeath += PlayerDeath;            //플레이어가 죽을 때
//        hpSystem.OnDamage += TakeDamage_KnockBack;  //플레이어가 피해를 입을 때
//    }

//    private void Update()
//    {
//        stateMachine.Update();
//    }

//    private void FixedUpdate()
//    {
//        stateMachine.PhysicsUpdate();
//    }

//    //private void LateUpdate()
//    //{
//    //    if(controller.isField)
//    //    {
//    //        var pos = transform.position;
//    //        Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
//    //    }
//    //}

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (controller.isField)
//        {

//        }
//        else
//        {
//            if (collision.gameObject.tag == Define.TAG_ENEMY)
//            {
//                Enemy _damagedEnemy;
//                if (collision.gameObject.TryGetComponent<Enemy>(out _damagedEnemy))
//                {
//                    _damagedEnemy.hpSystem.TakeDamage(statHandler.currentStats.attackDamage);
//                }
//            }
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (controller.isField)
//        {

//        }
//        else
//        {

//        }
//    }

//    public void TakeDamage_KnockBack(float _damage)
//    {
//        //배틀 씬일 때는 넉백이 된다.
//        if (!controller.isField) KnockBack();
//        //피해량 UI 구현예정
//    }

//    private void KnockBack()
//    {
//        rb.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);

//        OnInvinciblePlayer();
//    }

//    private void OnInvinciblePlayer()
//    {
//        CharacterManager.instance.enemy.OnIgnoreCollisionPlayer(true);

//        _blinkCoroutine = StartCoroutine(StartBlinkPlayer());
//        Invoke("OffInvinciblePlayer", 1.0f);
//    }

//    private void OffInvinciblePlayer()
//    {
//        CharacterManager.instance.enemy.OnIgnoreCollisionPlayer(false);

//        Color _color;

//        for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
//        {
//            _color = spum_SpriteList._itemList[i].color;
//            _color.a = 1.0f;
//            spum_SpriteList._itemList[i].color = _color;
//        }
//        for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
//        {
//            _color = spum_SpriteList._bodyList[i].color;
//            _color.a = 1.0f;
//            spum_SpriteList._bodyList[i].color = _color;
//        }

//        if (_blinkCoroutine != null) StopCoroutine(_blinkCoroutine);
//    }

//    IEnumerator StartBlinkPlayer()
//    {
//        Color _color;

//        while (true)
//        {
//            yield return new WaitForSeconds(0.1f);
//            for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
//            {
//                _color = spum_SpriteList._itemList[i].color;
//                _color.a = 0.3f;
//                spum_SpriteList._itemList[i].color = _color;
//            }
//            for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
//            {
//                _color = spum_SpriteList._bodyList[i].color;
//                _color.a = 0.3f;
//                spum_SpriteList._bodyList[i].color = _color;
//            }

//            yield return new WaitForSeconds(0.1f);
//            for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
//            {
//                _color = spum_SpriteList._itemList[i].color;
//                _color.a = 1.0f;
//                spum_SpriteList._itemList[i].color = _color;
//            }
//            for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
//            {
//                _color = spum_SpriteList._bodyList[i].color;
//                _color.a = 1.0f;
//                spum_SpriteList._bodyList[i].color = _color;
//            }
//        }
//    }

//    public void UpdateStat()
//    {
//        OnChangeStat?.Invoke();
//    }

//    public void PlayerDeath()
//    {
//        Debug.Log("PlayerDeath");
//        stateMachine.ChangeState(stateMachine.deathState);
//        //gameObject.SetActive(false);
//    }
//}
