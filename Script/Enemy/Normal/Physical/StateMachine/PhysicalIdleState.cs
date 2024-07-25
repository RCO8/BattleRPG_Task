using UnityEngine;

public class PhysicalIdleState : PhysicalEnemyBaseState
{
    private float flagTime = 1f;
    private float readyTime;

    public PhysicalIdleState(PhysicalEnemyStateMachine _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.IdleParameterHash);
        flagTime = Random.Range(0.4f, 0.9f);
        readyTime = 0f;
        Debug.Log("idle");
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        readyTime += Time.deltaTime;
        if (flagTime < readyTime)
        {
            readyTime = 0f;
            //바로 공격동작으로
            stateMachine.enemy.TurnAround();
            stateMachine.ChangeState(stateMachine.attackState);
        }
    }
}
