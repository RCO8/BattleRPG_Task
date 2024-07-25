using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public float Damage { get; set; }
    public bool IsHit { get; private set; } = false; //Physical Enemy에서 충돌했는지
    private float coolTime = 0f;
    private float maxCooltime = 0.1f;

    private void Update()
    {
        if (IsHit)  //hit했으면 쿨타임 지속
        {
            coolTime += Time.deltaTime;
            if (coolTime > maxCooltime)
            {
                IsHit = false;
                coolTime = 0f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            //Debug.Log("플레이어 피격");
            Player_Battle _player = CharacterManager.instance.basePlayer as Player_Battle;

            if (_player != null)
            {
                _player.TakeDamage_KnockBack(Damage);
                IsHit = true;
            }
        }
    }
}
