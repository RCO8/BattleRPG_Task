using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerStateMachine : CharacterState
{
    public BasePlayer basePlayer { get; }

    //States
    public PlayerIdleState idleState { get; }
    public PlayerRunState runState { get; }
    public PlayerStunState stunState { get; }
    public PlayerDeathState deathState { get; }

    public PlayerStateMachine(BasePlayer _player)
    {
        this.basePlayer = _player; 

        idleState = new PlayerIdleState(this);
        runState = new PlayerRunState(this);
        stunState = new PlayerStunState(this);
        deathState = new PlayerDeathState(this);
    }
}
