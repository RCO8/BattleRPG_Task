using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1RushState : Boss1BaseState
{
    private float _time = 0.0f;

    public Boss1RushState(Boss1StateMachine _stateMachine) : base(_stateMachine)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.boss1.boss1AnimationData.RunParameterHash);
        stateMachine.boss1.damageCollider.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.boss1.boss1AnimationData.RunParameterHash);
        stateMachine.boss1.damageCollider.gameObject.SetActive(false);
        _time = 0.0f;
        stateMachine.boss1.wallCollision = false;
    }

    public override void Update()
    {
        base.Update();

        if (_time >= 0.5f) stateMachine.boss1.wallCollision = true;
        else _time += Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (isPlayerRight) Rush_Right();
        else Rush_Left();
    }

    private void Rush_Right()
    {
        stateMachine.boss1.rb.AddForce(Vector2.right * 50.0f * stateMachine.boss1.stat.attackSpeed, ForceMode2D.Force);
        stateMachine.boss1.transform.localScale = new Vector2(-2.5f, 2.5f);
    }

    private void Rush_Left()
    {
        stateMachine.boss1.rb.AddForce(Vector2.right * -50.0f * stateMachine.boss1.stat.attackSpeed, ForceMode2D.Force);
        stateMachine.boss1.transform.localScale = new Vector2(2.5f, 2.5f);
    }
}
