using UnityEngine;

public class SwordEnemyStateMachine : CharacterState
{
    public SwordEnemy_Battle enemy;

    public SwordIdleState idleState;
    public SwordMoveState moveState;
    public SwordAttackState attackState;
    public SwordSkillState skillState;
    public SwordStunState stunState;
    public SwordDeadState deadState;

    public SwordEnemyStateMachine(SwordEnemy_Battle _enemy)
    {
        enemy = _enemy;

        idleState = new SwordIdleState(this);
        moveState = new SwordMoveState(this);
        attackState = new SwordAttackState(this);
        skillState = new SwordSkillState(this);
        stunState = new SwordStunState(this);
        deadState = new SwordDeadState(this);
    }
}
public class SwordStunState : SwordEnemyBaseState
{
    public SwordStunState(SwordEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }
}
