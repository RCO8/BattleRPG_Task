using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyAnimation
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string moveParameterName = "Move";
    [SerializeField] private string attackParameterName = "Attack";
    [SerializeField] private string skillParameterName = "Skill";
    [SerializeField] private string stunParameterName = "Stun";
    [SerializeField] private string deadParameterName = "Dead";

    public int IdleParameterHash { get; private set; }
    public int MoveParameterHash { get; private set; }
    public int AttackParameterHash { get; private set; }
    public int SkillParameterHash { get; private set; }
    public int StunParameterHash { get; private set; }
    public int DeadParameterHash { get; private set; }

    public void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        MoveParameterHash = Animator.StringToHash(moveParameterName);
        AttackParameterHash = Animator.StringToHash(attackParameterName);
        SkillParameterHash = Animator.StringToHash(skillParameterName);
        StunParameterHash = Animator.StringToHash(stunParameterName);
        DeadParameterHash = Animator.StringToHash(deadParameterName);
    }
}
