using System.Collections;
using UnityEngine;

public class Boss3Bomb : MonoBehaviour
{
    private Rigidbody2D rgdby;
    private float playerDistance;
    private float randomDistance;

    private void Awake()
    {
        rgdby = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 dir)
    {
        //플레이어 방향으로 전환
        playerDistance = Vector2.Distance(transform.position ,CharacterManager.instance.basePlayer.transform.position);

        randomDistance = Random.Range(playerDistance / 2, playerDistance);   //현재 플레이어 위치반에서 플레이어의 정위치까지

        rgdby.AddForce(dir * randomDistance, ForceMode2D.Impulse);   //떨어질때 나가는 거리
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
