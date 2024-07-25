using UnityEngine;

public class Boss3FlyState : Boss3BaseState
{
    //FlyState 필드
    private float maxHeight;
    private float flySpeed;

    public Boss3FlyState(Boss3StateMachine _stateMachine) : base(_stateMachine)
    {
        //날으는 속성 설정
        maxHeight = 3.75f;
        flySpeed = 2.5f;
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
        FlyUp();
    }

    private void FlyUp()
    {
        stateMachine.boss3.rb.gravityScale = 0f;
        if (stateMachine.boss3.transform.position.y < maxHeight)
            stateMachine.boss3.rb.AddForce(Vector2.up * flySpeed, ForceMode2D.Force);
        else
        {
            //올라갔으면 폭탄 투하
            stateMachine.boss3.rb.velocity = Vector2.zero;
            stateMachine.ChangeState(stateMachine.throwState);
        }
    }
}
