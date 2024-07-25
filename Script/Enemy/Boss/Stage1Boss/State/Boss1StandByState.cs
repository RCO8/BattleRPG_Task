using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1StandByState : Boss1BaseState
{
    //temp
    private float _time = 0.0f;

    public Boss1StandByState(Boss1StateMachine _stateMachine) : base(_stateMachine)
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

        //임시 ( 나중에 보스가 준비 애니메이션이 끝나면 다음 상태로 넘어가는 로직을 짤 것이다, 코루틴 매니저를 통해 작성할 것 )
        _time += Time.deltaTime;
        if (_time > 1.0f)
        {
            _time = 0.0f;
            RandomPattern();
        }
    }
}
