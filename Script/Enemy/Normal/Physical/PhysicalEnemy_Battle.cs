using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPhysicalType
{
    public void UsePhysicalAttack();
    public void UsePhysicalSkill();
}

public class PhysicalEnemy_Battle : NormalEnemy, IPhysicalType
{
    //그냥 돌진하듯 달려들고 벽에 닿으면 반대 방향으로

    [Header("상태 머신")]
    public PhysicalEnemyStateMachine stateMachine;
    public NormalEnemyAnimation animationData;

    [Header("공격 판정")]
    public BoxCollider2D attackTrigger;
    public AttackTrigger physicalEnemyAttack;

    protected override void Awake()
    {
        base.Awake();

        CharacterManager.instance.enemy = this;

        stateMachine = new PhysicalEnemyStateMachine(this);
        animationData = new NormalEnemyAnimation();
        animationData.Initialize();

        attackTrigger.enabled = false;
        //InitializeStat();
    }
    private void Start()
    {
        stateMachine.ChangeState(stateMachine.idleState);
    }
    private void Update()
    {
        stateMachine.Update();
    }
    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    //protected override void InitializeStat()
    //{
    //    stat.maxHealth = 30;
    //    stat.maxMana = 10f;
    //    stat.attackDamage = 10f;
    //    stat.attackSpeed = 10f;
    //    stat.moveSpeed = 5f;
    //}

    public override void EnemyDeath()
    {
        base.EnemyDeath();
        stateMachine.ChangeState(stateMachine.deadState);
    }

    //public override void EnterStateMachine()
    //{
    //    //SetBattleMode(true);      //FIX
    //    stateMachine.ChangeState(stateMachine.idleState);
    //}

    //public override void ExitStateMachine()
    //{
    //    //SetBattleMode(false);     //FIX
    //    stateMachine.ChangeState(null);
    //}

    public Vector2 LookingPlayer()
    {
        RectTransform targetPlayer = CharacterManager.instance.basePlayer.rectTransform;

        if (rectTransform.position.x > targetPlayer.position.x)
            return Vector2.left;
        else if(rectTransform.position.x < targetPlayer.position.x)
            return Vector2.right;
        else
            return Vector2.zero;
    }

    public void UsePhysicalAttack()
    {
        physicalEnemyAttack.Damage = stat.attackDamage;
    }

    public void UsePhysicalSkill()
    {

    }
}
