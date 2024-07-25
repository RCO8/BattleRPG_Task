using UnityEngine;

public interface ISwordType
{
    public void UseSwordAttack();
    public void UseSwordSkill();
}

public class SwordEnemy_Battle : NormalEnemy, ISwordType
{
    [Header("상태 머신")]
    public SwordEnemyStateMachine stateMachine;
    public NormalEnemyAnimation animationData;
    
    [Header("공격 판정")]
    public AttackTrigger swordEnemyAttack;

    protected override void Awake()
    {
        base.Awake();

        CharacterManager.instance.enemy = this;

        stateMachine = new SwordEnemyStateMachine(this);
        animationData = new NormalEnemyAnimation();
        animationData.Initialize();
        //InitializeStat();

        //트리거 버그 방지 코드
        swordEnemyAttack.enabled = false;
    }
    private void Start()
    {
        //스킬 설정
        if (hasSkill != null)
        {
            Instantiate(hasSkill);
            hasSkill.gameObject.SetActive(false);
        }
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Define.TAG_WALL)
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }

    //protected override void InitializeStat()
    //{
    //    stat.maxHealth = 20f;
    //    stat.maxMana = 10f;
    //    stat.attackDamage = 5f;
    //    stat.attackSpeed = 3f;
    //    stat.moveSpeed = 3f;
    //}

    public override void EnemyDeath()
    {
        base.EnemyDeath();
        stateMachine.ChangeState(stateMachine.deadState);
    }

    //FSM
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

    //인터페이스 메서드
    public void UseSwordAttack()
    {
        //공격상태
        swordEnemyAttack.Damage = enemyStatSO.attackDamage;
    }
    public void UseSwordSkill()
    {
        //스킬상태
        if(hasSkill != null)
        {
            //스킬 사용
            hasSkill.transform.position = transform.position;
            hasSkill.gameObject.SetActive(true);
        }
    }
}
