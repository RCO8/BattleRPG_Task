using UnityEngine;

public class PhysicalAttackState : PhysicalEnemyBaseState
{
    private Vector2 moving = Vector2.zero;

    public PhysicalAttackState(PhysicalEnemyStateMachine _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.AttackParameterHash);

        //공격 트리거 활성
        stateMachine.enemy.attackTrigger.enabled = true;
        stateMachine.enemy.UsePhysicalAttack();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.AttackParameterHash);
        moving = Vector2.zero;
        stateMachine.enemy.rb.velocity = moving;
        //공격 트리거 비활성
        stateMachine.enemy.attackTrigger.enabled = false;
    }

    public override void Update()
    {
        base.Update();

        //벽에 닿거나 플레이어 보는 방향이 다르다면
        stateMachine.enemy.TurnAround();
        moving = stateMachine.enemy.LookingPlayer();

        if (stateMachine.enemy.physicalEnemyAttack.IsHit)
            stateMachine.ChangeState(stateMachine.idleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        stateMachine.enemy.rb.velocity = moving * stateMachine.enemy.stat.moveSpeed;
    }
}
