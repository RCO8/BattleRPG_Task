public class BowEnemyStateMachine : CharacterState
{
    public BowEnemy_Battle enemy;

    public BowIdleState idleState;
    public BowMoveState moveState;
    public BowAttackState attackState;
    public BowSkillState skillState;
    public BowStunState stunState;
    public BowDeadState deadState;

    public BowEnemyStateMachine(BowEnemy_Battle _enemy)
    {
        enemy = _enemy;
        idleState = new BowIdleState(this);
        moveState = new BowMoveState(this);
        attackState = new BowAttackState(this);
        skillState = new BowSkillState(this);
        stunState = new BowStunState(this);
        deadState = new BowDeadState(this);
    }
}

public class BowStunState : BowEnemyBaseState
{
    public BowStunState(BowEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }
}
