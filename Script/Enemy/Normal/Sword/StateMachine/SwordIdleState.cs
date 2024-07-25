using UnityEngine;

public class SwordIdleState : SwordEnemyBaseState
{
    private float flagTime = 2f;
    private float readyTime;

    public SwordIdleState(SwordEnemyStateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.IdleParameterHash);
        flagTime = Random.Range(1.8f, 2.5f);    //랜덤한 시간으로 상태 변경
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
        if(readyTime > flagTime)    //일정시간 이상을 초과하면
        {
            readyTime = 0f;

            //플레이어랑 붙어있다면 공격 또는 스킬
            CheckingPlayer();
        }
    }

    private void CheckingPlayer()
    {
        stateMachine.enemy.TurnAround();

        //일정 거리보다 떨어져 있으면
        if (GetDistance(CharacterManager.instance.basePlayer.transform) > aimDistance)
            stateMachine.ChangeState(stateMachine.moveState);
        else
            ChoiceAttackOrSkill();
    }
}
