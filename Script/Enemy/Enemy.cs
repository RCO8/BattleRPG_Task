using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SceneManagement;
using System;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyEffect enemyEffect;
    public Animator animator;
    public RectTransform rectTransform;
    public EnemyStatData stat { get; set; }
    public EnemyHPSystem hpSystem;
    public EnemyStatSO enemyStatSO;
    public BoxCollider2D boxCollider;
    public BoxCollider2D damageCollider;    //적 몸통에 맞으면 대미지 처리가 되는 공격이 있을 때만 할당한다.

    private Player_Battle _player;

    public event Action OnChangeStat;       //스탯바뀔 때, UI변경용 델리게이트

    protected virtual void Awake()
    {
        stat = new EnemyStatData();
        stat.maxHealth = enemyStatSO.maxHealth;
        stat.maxMana = enemyStatSO.maxMana;
        stat.attackDamage = enemyStatSO.attackDamage;
        stat.attackSpeed = enemyStatSO.attackSpeed;
        stat.moveSpeed = enemyStatSO.moveSpeed;

        //델리게이트
        hpSystem.OnDeath += EnemyDeath;     //적이 죽을 때
        hpSystem.OnDamage += TakeDamage;    //적이 피해를 입을 때
    }

    protected virtual void Start()
    {
        OnChangeStat += BattleStatUI.instance.UpdateUI;
    }

    public virtual void EnemyDeath()
    {
        //상속받는 클래스에서 이 함수 구현 (처치 시, 이유는 스테이트머신이 각각 보스 클래스에 존재하기 때문에 여기서 구현 못함)

        StartCoroutine(DestroyThisObject());
    }

    IEnumerator DestroyThisObject()
    {
        yield return new WaitForSeconds(3.0f);

        //다시 필드로 돌아가는 코드 작성
        SceneDataManager.instance.ReturnToFieldScene();
    }

    private void TakeDamage(float _damage)
    {
        //적 피격당했을 때 이펙트

    }

    public void UpdateStat()
    {
        OnChangeStat?.Invoke();
    }
}
