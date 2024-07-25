using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1StunState : Boss1BaseState
{
    //temp
    private float _time = 0.0f;

    public Boss1StunState(Boss1StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.boss1.boss1AnimationData.StunParameterHash);
        stateMachine.boss1.enemyEffect.ChangeEffectState(EffectState.Stun);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.boss1.boss1AnimationData.StunParameterHash);
        stateMachine.boss1.enemyEffect.ChangeEffectState(EffectState.None);
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
