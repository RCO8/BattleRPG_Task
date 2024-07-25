using UnityEngine;

public class AirStompSkill : BaseSkill
{
    [SerializeField] private ActiveSkill skillData;

    private void Start()
    {
        particle.Stop();
        sprite.enabled = false;

        UseParticle();
    }
    private void FixedUpdate()
    {
        //해당 오브젝트가 땅에 있으면 점프 효과후 낙하
        //떨어져 있으면 바로 낙하
    }
    private void LateUpdate()
    {
        //transform = character.transform
        //transform.position = CharacterManager.instance.player.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")) ||
            collision.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
            UseTrigger();

        //땅에 닿으면 비활성
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Ground")))
            gameObject.SetActive(false);
    }

    public override void UseParticle()
    {
        //공중에서 내려가는 효과
        particle.Play();
        sprite.enabled = true;
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