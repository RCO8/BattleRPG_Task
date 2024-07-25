public class BowSkillState : BowEnemyBaseState
{
    public BowSkillState(BowEnemyStateMachine _stateMachine) : base(_stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.enemy.animationData.SkillParameterHash);
        stateMachine.enemy.UseArrowSkill();
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
