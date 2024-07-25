using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Obstacle : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Define.TAG_PLAYER))
        {
            CharacterManager.instance.basePlayer.GetComponent<Player_Battle>().TakeDamage_KnockBack(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag(Define.TAG_GROUND) || collision.gameObject.CompareTag(Define.TAG_WALL))
        {
            Destroy(gameObject);
        }
    }
}
