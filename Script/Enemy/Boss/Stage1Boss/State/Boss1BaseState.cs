using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Boss1BaseState : IState
{
    protected Boss1StateMachine stateMachine;
    protected bool isPlayerRight = false;

    public Boss1BaseState(Boss1StateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
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
        FindPlayerPosition();
    }

    protected void StartAnimation(int animationHash)
    {
        stateMachine.boss1.animator.SetBool(animationHash, true);
    }

    protected void StopAnimation(int animationHash)
    {
        stateMachine.boss1.animator.SetBool(animationHash, false);
    }

    protected void FindPlayerPosition()
    {
        //null체크
        if (CharacterManager.instance.basePlayer != null)
        {
            if (stateMachine.boss1.gameObject.transform.position.x < 
                CharacterManager.instance.basePlayer.gameObject.transform.position.x)
            {
                isPlayerRight = true;
            }
            else
            {
                isPlayerRight = false;
            }
        }
    }

    protected void RandomPattern()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                stateMachine.ChangeState(stateMachine.rushState);
                break;

            case 1:
                stateMachine.ChangeState(stateMachine.smashState);
                break;

            default:
                break;
        }
    }
}
