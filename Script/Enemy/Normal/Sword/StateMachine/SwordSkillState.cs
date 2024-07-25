public class SwordSkillState : SwordEnemyBaseState
{
    public SwordSkillState(SwordEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //동작 이후에 idle로
        StartAnimation(stateMachine.enemy.animationData.SkillParameterHash);
        stateMachine.enemy.UseSwordSkill();
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.enemy.animationData.SkillParameterHash);
    }

    public override void Update()
    {
        base.Update();

        float normalizeTime = stateMachine.enemy.NormalizeTime(stateMachine.enemy.animator, "Skill");
        if (normalizeTime < 1f) //한 루프가 끝나면
        {
            stateMachine.ChangeState(stateMachine.idleState);
        }
    }
}
