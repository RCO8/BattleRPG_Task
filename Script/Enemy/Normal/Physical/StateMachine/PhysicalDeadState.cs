using UnityEngine;

public class PhysicalDeadState : PhysicalEnemyBaseState
{
    public PhysicalDeadState(PhysicalEnemyStateMachine _stateMachine) : base(_stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.DeadParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.DeadParameterHash);
    }
}