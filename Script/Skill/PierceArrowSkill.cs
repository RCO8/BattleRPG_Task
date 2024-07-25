using UnityEngine;

public class PierceArrowSkill : BaseSkill
{
    [SerializeField] private ActiveSkill skillData;

    private Vector2 spawnPos;

    private void Start()
    {
        spawnPos = transform.position;
        particle.Play();
    }
    private void FixedUpdate()
    {
        rgdby.AddForce(Vector2.left * 2, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")) ||
            collision.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
            UseTrigger();
        //else if(collision.tag.Equals("Wall"))
        //    gameObject.SetActive(false);
    }

    public override void UseTrigger()
    {
        if (Tag.Equals("Player"))
        {
            //Enemy.TakeDamage(skillData.Damage);
        }
        else if(Tag.Equals("Enemy"))
        {
            //Player.TakeDamage(skillData.Damage);
        }
    }
    public override void ShowSkillInfo()
    {

    }
}