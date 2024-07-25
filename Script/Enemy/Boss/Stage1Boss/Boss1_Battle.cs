using UnityEngine;
using System;

public class Boss1_Battle : Enemy
{
    public Boss1StateMachine boss1StateMachine;
    public Boss1AnimationData boss1AnimationData;
    public GameObject obstacle;
    public bool wallCollision = false;
    public bool isRageMode = false;

    protected override void Awake()
    {
        base.Awake();

        CharacterManager.instance.enemy = this;

        boss1StateMachine = new Boss1StateMachine(this);
        boss1AnimationData = new Boss1AnimationData();
        boss1AnimationData.Initialize();

        //OnChangeStat += ChangeRageMode;
        hpSystem.OnDamage += ChangeRageMode;
    }

    protected override void Start()
    {
        base.Start();

        boss1StateMachine.ChangeState(boss1StateMachine.readyState);
    }

    private void Update()
    {
        boss1StateMachine.Update();
    }

    private void FixedUpdate()
    {
        boss1StateMachine.PhysicsUpdate();
    }

    public override void EnemyDeath()
    {
        base.EnemyDeath();

        boss1StateMachine.ChangeState(boss1StateMachine.deadState);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == Define.TAG_PLAYER)
        {
            Player_Battle _player = CharacterManager.instance.basePlayer as Player_Battle;

            if (_player != null)
            {
                _player.TakeDamage_KnockBack(stat.attackDamage);
            }
        }

        if(collision.gameObject.tag == Define.TAG_WALL)
        {
            if(wallCollision) boss1StateMachine.ChangeState(boss1StateMachine.stunState);
        }
    }

    private void ChangeRageMode(float _none)
    {
        if(hpSystem.currentHealth < hpSystem.maxHealth * 0.5f)
        {
            hpSystem.OnDamage -= ChangeRageMode;
            stat.attackSpeed *= 1.5f;
            stat.attackDamage *= 1.5f;
            isRageMode = true;
            animator.speed = 1.5f;
        }
    }

    public void MakeObstacle(Vector2 _position)
    {
        Instantiate(obstacle, _position, Quaternion.identity).GetComponent<Boss1Obstacle>().damage = stat.attackDamage;
        Debug.Log("MakeObstacle");
    }
}
