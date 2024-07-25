using UnityEngine;

public class RushOfRunSkill : BaseSkill
{
    [SerializeField] private ActiveSkill skillData;

    private void Start()    //활성시
    {
        CoolTime = 5f;
        trigger.enabled = true;
        UseParticle();
    }
    private void LateUpdate()
    {
        //transform.position = CharacterManager.instance.player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")) ||
            collision.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
            UseTrigger();
        else if(collision.gameObject.layer.Equals(LayerMask.NameToLayer("Wall")))
            gameObject.SetActive(false);    //벽에 닿으면 무효화
    }

    public override void UseParticle()
    {
        particle.Play();
    }
    public override void UseTrigger()
    {
        if (Tag.Equals("Player"))
        {
        }
        else if (Tag.Equals("Enemy"))
        {
        }
    }
    public override void ShowSkillInfo()
    {

    }
}