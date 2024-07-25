using UnityEngine;

public class Boss3FallState : Boss3BaseState
{
    private Transform findPlayer;
    private float playerDistance;   //플레이어간의 거리

    public Boss3FallState(Boss3StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        SettingTarget();
        FallDown();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void SettingTarget()
    {
        findPlayer = CharacterManager.instance.basePlayer.transform;
        playerDistance = Vector2.Distance(findPlayer.position, stateMachine.boss3.transform.position);
    }

    private void FallDown()
    {
        stateMachine.boss3.rb.gravityScale = stateMachine.boss3.CurrentGravity;
        stateMachine.boss3.rb.AddForce(findPlayer.position, ForceMode2D.Impulse);
    }
}
