using System.Diagnostics;

public interface IState
{
    //이 상태로 진입할 때
    public void Enter();
    //이 상태에서 나갈 때
    public void Exit();
    //Update
    public void Update();
    //물리 관련 된 Update
    public void PhysicsUpdate();
}

public abstract class CharacterState
{
    public IState currentState;

    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState?.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
