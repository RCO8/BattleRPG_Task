using UnityEngine;

public class PlayerAnimationData
{
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string attackParameterName = "Attack";
    [SerializeField] private string deathParameterName = "Die";
    [SerializeField] private string attackSpeedParameterName = "AttackSpeed";
    [SerializeField] private string normalStateParameterName = "NormalState";
    [SerializeField] private string skillStateParameterName = "SkillState";
    [SerializeField] private string runStateParameterName = "RunState";
    [SerializeField] private string attackStateParameterName = "AttackState";
    [SerializeField] private string comboStateParameterName = "ComboState";

    public int RunParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int DeathParameterHash { get; private set; }
    public int AttackSpeedParameterHash { get; private set; }
    public int NormalStateParameterHash { get; private set; }
    public int SkillStateParameterHash { get; private set; }
    public int RunStateParameterHash { get; private set; }
    public int AttackStateParameterHash { get; private set; }
    public int ComboStateParameterHash { get; private set; }


    public virtual void Initialize()
    {
        RunParameterHash = Animator.StringToHash(runParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        DeathParameterHash = Animator.StringToHash(deathParameterName);
        AttackSpeedParameterHash = Animator.StringToHash(attackSpeedParameterName);
        NormalStateParameterHash = Animator.StringToHash(normalStateParameterName);
        SkillStateParameterHash = Animator.StringToHash(skillStateParameterName);
        RunStateParameterHash = Animator.StringToHash(runStateParameterName);
        AttackStateParameterHash = Animator.StringToHash(attackStateParameterName);
        ComboStateParameterHash = Animator.StringToHash(comboStateParameterName);
    }
}
