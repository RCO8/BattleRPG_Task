using System;
using UnityEngine;

public class ChamGyukSkill : BaseSkill
{
    //스킬을 종류별로 나눌까?
    [SerializeField] private ActiveSkill skillData;

    private Vector2 spawnPos;   //시작 위치
    private float maxDistance = 3f; //최장 거리
    private float particleTime = 0f;    //파티클 지속시간

    private void Start()
    {
        //쿨타임 설정
        CoolTime = 2f;

        //초기 설정
        spawnPos = transform.position;
        trigger.enabled = true;
        particle.Stop();
        particleTime = 0f;
    }
    private void Update()
    {
        //한정거리보다 넘어가면
        if (Vector2.Distance(spawnPos, transform.position) > maxDistance)
            UseParticle();
    }
    private void FixedUpdate()
    {
        //rgdby를 제어하기 위해
        rgdby.AddForce(Vector2.left, ForceMode2D.Force);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Player")) ||
            collision.gameObject.layer.Equals(LayerMask.NameToLayer("Enemy")))
        {
            UseTrigger();
            UseParticle();
        }
        //상대에게 닿으면 상대.hp -= skillData.Damage;
    }

    //인터페이스 함수
    public override void UseParticle()   //참격이 끝나면 파티클로 부서지는 효과
    {
        rgdby.velocity = Vector2.zero;
        if (!particle.isPlaying)
        {
            particle.Play();
            sprite.enabled = false;
        }
        else
        {
            particleTime += Time.deltaTime;
            if (particleTime > 0.5f)
                gameObject.SetActive(false);
        }
    }
    public override void UseTrigger()    //참격의 피격을 유효화
    {
        if (Tag.Equals("Player"))
        {
        }
        else if (Tag.Equals("Enemy"))
        {
        }
    }
    public override void ShowSkillInfo() //파라미터는 해당 UI로 받게 (정보 표시용)
    {
        //이름
        //설명
        //아래 속성들이 1 이상일 때 표시
        //예) 공격(+5)
    }
}
