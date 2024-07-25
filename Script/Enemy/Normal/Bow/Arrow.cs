using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float ArrowDamage { get; set; }
    public float ArrowSpeed { get; set; }
    private Rigidbody2D rgdBody;
    private SpriteRenderer renderer;
    private Vector2 direction = Vector2.zero;

    private void Awake()
    {
        rgdBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        renderer.flipY = transform.localScale.x < 0;
        direction = renderer.flipY ? Vector2.right : Vector2.left;

    }

    private void FixedUpdate()
    {
        rgdBody.AddForce(direction * 3, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Define.TAG_PLAYER))
        {
            Debug.Log("플레이어 피격");
            Player_Battle _player = CharacterManager.instance.basePlayer as Player_Battle;

            if (_player != null)
            {
                _player.TakeDamage_KnockBack(ArrowDamage);
                //데미지 피격
            }
        }
        gameObject.SetActive(false);
    }
}
