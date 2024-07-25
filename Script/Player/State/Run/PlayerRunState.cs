
public class PlayerRunState : PlayerGroundState
{
    public PlayerRunState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartFloatAnimation(stateMachine.basePlayer.animationData.RunStateParameterHash, 0.5f);
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

    //protected override void OnMovementCanceled(InputAction.CallbackContext context)
    //{
    //    if (stateMachine.MovementInput == Vector2.zero)
    //    {
    //        return;
    //    }

    //    stateMachine.ChangeState(stateMachine.IdleState);

    //    base.OnMovementCanceled(context);
    //}

}
