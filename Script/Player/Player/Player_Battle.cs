using System.Collections;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class Player_Battle : BasePlayer
{
    public BoxCollider2D boxCollider_Weapon;
    public BoxCollider2D boxCollider_Damaged;
    public PlayerAttack attack;
    public PlayerAnimationEvent animationEvent;
    public PlayerController_Battle controller;
    public PlayerMovement_Battle playerMovement;
    public SpriteRenderer weaponSpriteRenderer;

    private Coroutine _blinkCoroutine;

    protected override void Awake()
    {
        base.Awake();

        ResizeWeaponCollider();
    }

    protected override void Start()
    {
        base.Start();

        //temp
        OnChangeStat += BattleStatUI.instance.UpdateUI;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Define.TAG_ENEMY)
        {
            Enemy _damagedEnemy;
            if (collision.gameObject.TryGetComponent<Enemy>(out _damagedEnemy))
            {
                _damagedEnemy.hpSystem.TakeDamage(10.0f);
            }
        }
    }

    public void TakeDamage_KnockBack(float _damage)
    {
        //배틀 씬일 때는 넉백이 된다.
        KnockBack();
        //피해량 UI 구현예정
        CharacterManager.instance.playerStatHandler.hpSystem.TakeDamage(_damage);
    }

    private void KnockBack()
    {
        rb.AddForce(Vector2.up * 20.0f, ForceMode2D.Impulse);

        OnInvinciblePlayer();
    }

    private void OnInvinciblePlayer()
    {
        //무적판정 On
        boxCollider_Damaged.gameObject.SetActive(false);

        _blinkCoroutine = StartCoroutine(StartBlinkPlayer());
        Invoke("OffInvinciblePlayer", 1.0f);
    }

    private void OffInvinciblePlayer()
    {
        Color _color;

        for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
        {
            _color = spum_SpriteList._itemList[i].color;
            _color.a = 1.0f;
            spum_SpriteList._itemList[i].color = _color;
        }
        for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
        {
            _color = spum_SpriteList._bodyList[i].color;
            _color.a = 1.0f;
            spum_SpriteList._bodyList[i].color = _color;
        }

        if (_blinkCoroutine != null) StopCoroutine(_blinkCoroutine);

        //무적판정 Off
        boxCollider_Damaged.gameObject.SetActive(true);
    }

    IEnumerator StartBlinkPlayer()
    {
        Color _color;
        SPUM_SpriteList _sprite = CharacterManager.instance.spum_SpriteList;

        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
            {
                _color = spum_SpriteList._itemList[i].color;
                _color.a = 0.3f;
                spum_SpriteList._itemList[i].color = _color;
            }
            for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
            {
                _color = spum_SpriteList._bodyList[i].color;
                _color.a = 0.3f;
                spum_SpriteList._bodyList[i].color = _color;
            }

            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < spum_SpriteList._itemList.Count; i++)
            {
                _color = spum_SpriteList._itemList[i].color;
                _color.a = 1.0f;
                spum_SpriteList._itemList[i].color = _color;
            }
            for (int i = 0; i < spum_SpriteList._bodyList.Count; i++)
            {
                _color = spum_SpriteList._bodyList[i].color;
                _color.a = 1.0f;
                spum_SpriteList._bodyList[i].color = _color;
            }
        }
    }

    public void PlayerDeath()
    {
        stateMachine.ChangeState(stateMachine.deathState);
    }

    //무기 콜라이더의 사이즈를 무기 스프라이트에 맞추는 함수
    private void ResizeWeaponCollider()
    {
        // SpriteRenderer가 스프라이트를 가지고 있는지 확인합니다.
        if (weaponSpriteRenderer != null && weaponSpriteRenderer.sprite != null)
        {
            // 스프라이트의 bounds를 사용하여 BoxCollider2D의 size를 설정합니다.
            boxCollider_Weapon.size = weaponSpriteRenderer.sprite.bounds.size;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or Sprite is missing.");
        }
    }
}
