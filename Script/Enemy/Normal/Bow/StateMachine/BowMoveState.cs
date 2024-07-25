using UnityEngine;

public class BowMoveState : BowEnemyBaseState
{
    private Vector2 moving = Vector2.zero;

    public BowMoveState(BowEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.MoveParameterHash);
        //플레이어 방향대로 전진
        if (stateMachine.enemy.transform.localScale.x > 0)   //왼쪽
            moving = Vector2.left;
        else if (stateMachine.enemy.transform.localScale.x < 0)    //오른쪽
            moving = Vector2.right;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.MoveParameterHash);
    }

    public override void Update()
    {
        base.Update();
        //플레이어와 근접해있으면
        if (GetDistance(CharacterManager.instance.basePlayer.transform) < aimDistance)
        {
            stateMachine.ChangeState(stateMachine.attackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        //이동
        stateMachine.enemy.rb.velocity = moving * stateMachine.enemy.stat.moveSpeed;
    }
}
