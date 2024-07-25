
using UnityEngine;

public class Boss1AnimationData : EnemyAnimationData
{
    [SerializeField] private string stunParameterName = "Stun";

    public int StunParameterHash { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
        StunParameterHash = Animator.StringToHash(stunParameterName);
    }
}
