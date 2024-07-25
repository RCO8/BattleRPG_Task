public class Boss3LaserState : Boss3BaseState
{
    public Boss3LaserState(Boss3StateMachine _stateMachine) : base(_stateMachine)
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

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void ShootingLaser()
    {
        //레이저를 아래에서 앞방향으로 발사
    }
}
