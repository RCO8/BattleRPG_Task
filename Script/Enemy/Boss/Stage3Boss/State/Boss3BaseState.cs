public class Boss3BaseState : IState
{
    protected Boss3StateMachine stateMachine;
    protected bool isPlayerRight = false;

    public Boss3BaseState(Boss3StateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
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
}