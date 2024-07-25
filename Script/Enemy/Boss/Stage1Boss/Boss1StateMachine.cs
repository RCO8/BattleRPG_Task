using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1StateMachine : CharacterState
{
    public Boss1_Battle boss1;

    //상태들 필드에 선언
    public Boss1ReadyState readyState { get; }
    public Boss1RushState rushState { get; }
    public Boss1SmashState smashState { get; }
    public Boss1StunState stunState { get; }
    public Boss1StandByState standByState { get; }
    public Boss1DeadState deadState { get; }


    public Boss1StateMachine(Boss1_Battle _boss1)
    {
        boss1 = _boss1;

        readyState = new Boss1ReadyState(this);
        rushState = new Boss1RushState(this);
        smashState = new Boss1SmashState(this);
        stunState = new Boss1StunState(this);
        standByState = new Boss1StandByState(this);
        deadState = new Boss1DeadState(this);
    }
}
