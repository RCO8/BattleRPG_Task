//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Rendering.VirtualTexturing;

//public class Boss1 : Enemy
//{
//    public Boss1StateMachine boss1StateMachine;
//    public Boss1AnimationData boss1AnimationData;
//    public EnemyEffect enemyEffect;

//    public bool isRageMode {  get; private set; }

//    protected override void Awake()
//    {
//        base.Awake();

//        enemyEffect = GetComponent<EnemyEffect>();

//        boss1StateMachine = new Boss1StateMachine(this);
//        boss1AnimationData = new Boss1AnimationData();
//        boss1AnimationData.Initialize();
//        InitializeStat();
//    }

//    private void Start()
//    {
//        Debug.Log(stat.maxHealth);

//        if (isField) ExitStateMachine();
//        else EnterStateMachine();
//    }

//    private void Update()
//    {
//        boss1StateMachine.Update();
//    }

//    private void FixedUpdate()
//    {
//        boss1StateMachine.PhysicsUpdate();
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.tag == Define.TAG_PLAYER)
//        {
//            //collision.gameObject.GetComponent<Player>().hpSystem.TakeDamage(stat.attackDamage);
//        }

//        if (collision.gameObject.tag == Define.TAG_WALL)
//        {
//            boss1StateMachine.ChangeState(boss1StateMachine.stunState);
//        }

//    }

//    public override void EnterStateMachine()
//    {
//        SetBattleMode(true);
//        boss1StateMachine.ChangeState(boss1StateMachine.readyState);
//    }
//    public override void ExitStateMachine()
//    {
//        SetBattleMode(false);
//        boss1StateMachine.ChangeState(null);
//    }

//    protected override void InitializeStat()
//    {
//        stat.maxHealth = 10.0f;
//        stat.attackDamage = 30.0f;
//        stat.moveSpeed = 1.0f;
//    }

//    private void RageMode(bool _on)
//    {
//        if (_on)
//        {
//            isRageMode = true;
//            stat.attackDamage = 45.0f;
//            stat.moveSpeed = 1.5f;
//        }
//        else
//        {
//            isRageMode = false;
//            stat.attackDamage = 30.0f;
//            stat.moveSpeed = 1.0f;
//        }
//    }

//    public override void EnemyDeath()
//    {
//        base.EnemyDeath();

//        boss1StateMachine.ChangeState(boss1StateMachine.deadState);
//    }
//}
