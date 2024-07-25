using UnityEngine;

public class Boss3ReadyState : Boss3BaseState
{
    float readyDelay = 0f;

    public Boss3ReadyState(Boss3StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit() 
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
        ReadyToFly();
    }

    //잠시 후에 flyState로 전환
    private void ReadyToFly()
    {
        readyDelay += Time.deltaTime;
        if (readyDelay > 1f)
            stateMachine.ChangeState(stateMachine.flyState);
    }
}
