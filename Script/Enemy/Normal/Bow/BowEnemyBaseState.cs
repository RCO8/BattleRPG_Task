using UnityEngine;

public class BowEnemyBaseState : IState
{
    protected BowEnemyStateMachine stateMachine;
    protected float aimDistance = 5f; //플레이어 근접 거리

    public BowEnemyBaseState(BowEnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void PhysicsUpdate() { }
    public virtual void Update() { }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.enemy.animator.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.enemy.animator.SetBool(animationHash, false);
    }

    protected float GetDistance(Transform targetPos)
    {
        return Vector2.Distance(stateMachine.enemy.transform.position, targetPos.position);
    }
    protected void ChoiceAttackOrSkill()
    {
        stateMachine.ChangeState(stateMachine.attackState);
        //float choiceAttack = Random.Range(0f, 1f);
        //if (choiceAttack > 0.25f) //30%확률로 스킬
        //    stateMachine.ChangeState(stateMachine.attackState);
        //else
        //    stateMachine.ChangeState(stateMachine.skillState);
    }
}
