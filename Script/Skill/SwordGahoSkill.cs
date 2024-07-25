using UnityEngine;

public class SwordGahoSkill : BaseSkill
{
    [SerializeField] private PassiveSkill skillData;

    private float particleTime = 0f;

    private void Start()
    {
        CoolTime = 10f;

        //플레이어의 스탯을 skillData에 추가
    }

    public override void UseParticle()
    {
        //플레이어에서 빛이 생기는 효과
        particle.Play();
    }
    public override void ShowSkillInfo()
    {

    }
}
