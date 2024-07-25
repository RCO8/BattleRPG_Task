using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1DeadState : Boss1BaseState
{
    private float _time = 0.0f;

    public Boss1DeadState(Boss1StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.boss1.boss1AnimationData.DeathParameterHash);

        _time = Time.time;
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.boss1.boss1AnimationData.DeathParameterHash);
    }

    public override void Update()
    {
        base.Update();

    }
}
