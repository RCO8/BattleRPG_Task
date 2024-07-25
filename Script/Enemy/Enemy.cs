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
    public BoxCollider2D damageCollider;    //�� ���뿡 ������ ����� ó���� �Ǵ� ������ ���� ���� �Ҵ��Ѵ�.

    private Player_Battle _player;

    public event Action OnChangeStat;       //���ȹٲ� ��, UI����� ��������Ʈ

    protected virtual void Awake()
    {
        stat = new EnemyStatData();
        stat.maxHealth = enemyStatSO.maxHealth;
        stat.maxMana = enemyStatSO.maxMana;
        stat.attackDamage = enemyStatSO.attackDamage;
        stat.attackSpeed = enemyStatSO.attackSpeed;
        stat.moveSpeed = enemyStatSO.moveSpeed;

        //��������Ʈ
        hpSystem.OnDeath += EnemyDeath;     //���� ���� ��
        hpSystem.OnDamage += TakeDamage;    //���� ���ظ� ���� ��
    }

    protected virtual void Start()
    {
        OnChangeStat += BattleStatUI.instance.UpdateUI;
    }

    public virtual void EnemyDeath()
    {
        //��ӹ޴� Ŭ�������� �� �Լ� ���� (óġ ��, ������ ������Ʈ�ӽ��� ���� ���� Ŭ������ �����ϱ� ������ ���⼭ ���� ����)

        StartCoroutine(DestroyThisObject());
    }

    IEnumerator DestroyThisObject()
    {
        yield return new WaitForSeconds(3.0f);

        //�ٽ� �ʵ�� ���ư��� �ڵ� �ۼ�
        SceneDataManager.instance.ReturnToFieldScene();
    }

    private void TakeDamage(float _damage)
    {
        //�� �ǰݴ����� �� ����Ʈ

    }

    public void UpdateStat()
    {
        OnChangeStat?.Invoke();
    }
}
