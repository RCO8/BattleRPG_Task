using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : CharacterState
{
    public Enemy enemy { get; }

    //Àû ½ºÅÈ

    public EnemyStateMachine (Enemy _enemy)
    {
        enemy = _enemy;

        //Àû ½ºÅÈ
    }
}
