using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAnimation : MonoBehaviour
{
    //애니메이션 효과로 판정이 보이고 숨겨지도록
    [SerializeField] private BoxCollider2D getAttackTrigger;

    public void NormalAttack()
    {
        //판정박스 보임
        getAttackTrigger.enabled = true;
    }

    public void EndNormalAttack()
    {
        //판정박스 숨김
        getAttackTrigger.enabled = false;
    }
}
