using System.Collections;
using System.Collections.Generic;

public class PhysicalEnemyStateMachine : CharacterState
{
    public PhysicalEnemy_Battle enemy;

    public PhysicalIdleState idleState;
    public PhysicalAttackState attackState;
    public PhysicalSkillState skillState;
    public PhysicalStunState stunState;
    public PhysicalDeadState deadState;

    public PhysicalEnemyStateMachine(PhysicalEnemy_Battle _enemy)
    {
        enemy = _enemy;

        idleState = new PhysicalIdleState(this);
        attackState = new PhysicalAttackState(this);
        skillState = new PhysicalSkillState(this);
        stunState = new PhysicalStunState(this);
        deadState = new PhysicalDeadState(this);
    }
}
public class PhysicalStunState : PhysicalEnemyBaseState
{
    public PhysicalStunState(PhysicalEnemyStateMachine _stateMachine) : base(_stateMachine) { }
}
