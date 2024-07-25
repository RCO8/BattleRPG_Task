using UnityEngine;

public class PlayerBaseState : IState
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
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
        
    }

    protected void StartBoolAnimation(int animationHash)
    {
        stateMachine.basePlayer.animator.SetBool(animationHash, true);
    }

    protected void StopBoolAnimation(int animationHash)
    {
        stateMachine.basePlayer.animator.SetBool(animationHash, true);
    }

    protected void StartTriggerAnimation(int animationHash)
    {
        stateMachine.basePlayer.animator.SetTrigger(animationHash);
    }

    protected void StartFloatAnimation(int animationHash, float value)
    {
        stateMachine.basePlayer.animator.SetFloat(animationHash, value);
    }
}
