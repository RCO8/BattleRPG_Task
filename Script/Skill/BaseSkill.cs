using UnityEngine;
public interface ISkill
{
    public void UseParticle();
    public void UseTrigger();
    public void ShowSkillInfo();
}

public class BaseSkill : MonoBehaviour, ISkill
{
    public float CoolTime = 1f; //쿨타임
    public float CurrentCoolTime = 0f;
    public string Tag { get; set; } //플레이어나 적이 사용할 때

    [SerializeField] protected ParticleSystem particle;
    [SerializeField] protected BoxCollider2D trigger;
    [SerializeField] protected Rigidbody2D rgdby;
    [SerializeField] protected SpriteRenderer sprite;

    public virtual void UseParticle() { }
    public virtual void UseTrigger() { }
    public virtual void ShowSkillInfo() { }
}
