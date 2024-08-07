using UnityEngine;

public class BowIdleState : BowEnemyBaseState
{
    private float flagTime = 2.3f;
    private float readyTime;

    public BowIdleState(BowEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.IdleParameterHash);
        flagTime = Random.Range(1.6f, 1.9f);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.IdleParameterHash);
    }

    public override void Update()
    {
        base.Update();
        readyTime += Time.deltaTime;
        if(readyTime > flagTime)
        {
            readyTime = 0f;
            LookingPlayer();
        }
    }

    private void LookingPlayer()
    {
        //적이 플레이어를 바라보게
        stateMachine.enemy.TurnAround();
        if (GetDistance(CharacterManager.instance.basePlayer.transform) > aimDistance)
            stateMachine.ChangeState(stateMachine.moveState);
        else
            ChoiceAttackOrSkill();
    }
}
