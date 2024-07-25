using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1ReadyState : Boss1BaseState
{
    private float _time = 0.0f;

    public Boss1ReadyState(Boss1StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.boss1.boss1AnimationData.IdleParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.boss1.boss1AnimationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();

        _time += Time.deltaTime;

        if (_time > 2.0f)
        {
            _time = 0.0f;
            RandomPattern();
        }
    }
}
