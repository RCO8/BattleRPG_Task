using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3StateMachine : CharacterState
{
    public Boss3 boss3;

    //상태머신
    public Boss3ReadyState readyState { get; }
    public Boss3FlyState flyState { get; }
    public Boss3ThrowState throwState { get; }
    public Boss3LaserState laserState { get; }
    public Boss3FallState fallState { get; }
    public Boss3DeadState deadState { get; }

    public Boss3StateMachine(Boss3 _boss3)
    {
        boss3 = _boss3;

        readyState = new Boss3ReadyState(this);
        flyState = new Boss3FlyState(this);
        throwState = new Boss3ThrowState(this);
        laserState = new Boss3LaserState(this);
        fallState = new Boss3FallState(this);
        deadState = new Boss3DeadState(this);
    }
}
