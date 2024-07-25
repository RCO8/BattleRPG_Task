using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalEnemyBaseState : IState
{
    protected PhysicalEnemyStateMachine stateMachine;

    public PhysicalEnemyBaseState(PhysicalEnemyStateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {

    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.enemy.animator.SetBool(animationHash, true);
    }
    protected void StopAnimation(int animationHash)
    {
        stateMachine.enemy.animator.SetBool(animationHash, false);
    }
}
