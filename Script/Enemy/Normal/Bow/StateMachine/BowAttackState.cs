using UnityEngine;

public class BowAttackState : BowEnemyBaseState
{
    public BowAttackState(BowEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.AttackParameterHash);
        stateMachine.enemy.UseArrowAttack();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.AttackParameterHash);
    }

    public override void Update()
    {
        base.Update();

        float normalizeTime = stateMachine.enemy.NormalizeTime(stateMachine.enemy.animator, "Attack");
        if (normalizeTime < 1f) //한 루프가 끝나면
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }
}
