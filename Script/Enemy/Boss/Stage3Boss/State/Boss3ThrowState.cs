using System.Collections;
using UnityEngine;

public class Boss3ThrowState : Boss3BaseState
{
    private float nowDelay = 0f; //현재 딜레이
    private float timeDelay = 1f; //목적 딜레이 (일정시간)

    public Boss3ThrowState(Boss3StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        nowDelay = 0f;
        ThrowStart();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //일정시간이 지나면 fallState로
        nowDelay += Time.deltaTime;
        if(nowDelay > timeDelay)
        {
            stateMachine.ChangeState(stateMachine.fallState);
            return;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void ThrowStart()
    {
        //위치를 보스있는데로
        //3개의 폭탄을 앞으로 투하
        ThrowBomb();
    }

    private void ThrowBomb()
    {
        int poolSize = stateMachine.boss3.Bombs.PoolDictionary["Bomb"].Count;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bomb = stateMachine.boss3.Bombs.SpawnFromPool("Bomb");
            bomb.transform.position = stateMachine.boss3.transform.position;

            Boss3Bomb aimBomb = bomb.GetComponent<Boss3Bomb>();

            if (stateMachine.boss3.transform.position.x > stateMachine.boss3.targetPlayer.position.x)
            {
                bomb.transform.Translate(Vector2.left);
                aimBomb.SetDirection(Vector2.left);
            }
            else
            {
                bomb.transform.Translate(Vector2.right);
                aimBomb.SetDirection(Vector2.right);
            }
        }
        
    }
}
