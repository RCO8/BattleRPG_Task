using UnityEngine;

public class EnemyAnimationData
{
    [SerializeField] private string idleParameterName = "Idle";
    [SerializeField] private string runParameterName = "Run";
    [SerializeField] private string deathParameterName = "Death";

    public int IdleParameterHash { get; private set; }
    public int RunParameterHash { get; private set; }
    public int DeathParameterHash { get; private set; }

    public virtual void Initialize()
    {
        IdleParameterHash = Animator.StringToHash(idleParameterName);
        RunParameterHash = Animator.StringToHash(runParameterName);
        DeathParameterHash = Animator.StringToHash(deathParameterName);
    }
}
