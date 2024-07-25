using UnityEngine;

public interface IBowType
{
    public void UseArrowAttack();
    public void UseArrowSkill();
}

public class BowEnemy_Battle : NormalEnemy, IBowType
{
    [Header("상태 머신")]
    public BowEnemyStateMachine stateMachine;
    public NormalEnemyAnimation animationData;

    ArrowPool arrowPool;

    protected override void Awake()
    {
        base.Awake();
        
        CharacterManager.instance.enemy = this;

        stateMachine = new BowEnemyStateMachine(this);
        animationData = new NormalEnemyAnimation();
        animationData.Initialize();

        arrowPool = GameManager.instance.ArrowPool; //화살을 사용할수 있게
        //boxCollider.enabled = false;    //방어코드 (시작시 활성화됨) //FIX
        
        //스킬 설정
        if (hasSkill != null)
        {
            Instantiate(hasSkill, transform);
            hasSkill.gameObject.SetActive(false);
        }
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

    private void InitStat()
    {
        stat.maxHealth = 15f;
        stat.maxMana = 15f;
        stat.attackDamage = 2f;
        stat.attackSpeed = 2f;
        stat.moveSpeed = 2f;
    }

    public override void EnemyDeath()
    {
        base.EnemyDeath();
        stateMachine.ChangeState(stateMachine.deadState);
    }

    //FSM
    //public override void EnterStateMachine()
    //{
    //    //SetBattleMode(true);  //FIX
    //    stateMachine.ChangeState(stateMachine.idleState);
    //}
    //public override void ExitStateMachine()
    //{
    //    //SetBattleMode(false); //FIX
    //    stateMachine.ChangeState(null);
    //}

    //인터페이스
    public void UseArrowAttack()
    {
        float mirrorXScale = transform.localScale.x > 0 ? 2f : -2f;
        Vector3 spawnControll = new Vector2(0, 0.5f);
        Vector3 mirror = new Vector3(mirrorXScale, 2);

        GameObject obj = arrowPool.SpawnFromPool("Arrow");
        obj.transform.position = transform.position + spawnControll;
        obj.transform.localScale = mirror;
        obj.GetComponent<Arrow>().ArrowDamage = stat.attackDamage;
        obj.GetComponent<Arrow>().ArrowSpeed = stat.attackSpeed;
    }
    public void UseArrowSkill()
    {
        //화살을 여러개(?)로 발사
        //또는 강한 화살 발사
    }
}
