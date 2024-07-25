using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : Enemy
{
    //Battle Class
    [Header("스킬")]
    [SerializeField] protected GameObject hasSkill;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        CharacterManager.instance.enemy = this;

        //if (isField) ExitStateMachine();  //FIX
        //else EnterStateMachine();         //FIX
    }


    //public override void EnterStateMachine()
    //{
    //    //SetBattleMode(true);              //FIX
    //}

    //public override void ExitStateMachine()
    //{
    //    //SetBattleMode(false);             //FIX
    //}

    public void TurnAround()    //좌우 전환
    {
        Vector2 turn = Vector2.one;
        turn.x = -1;
        Transform targetPlayer = CharacterManager.instance.basePlayer.transform;

        if(rectTransform.localScale.x > 0)  //좌향
        {
            if(targetPlayer.position.x > transform.position.x)
                rectTransform.localScale *= turn;
        }
        else if(rectTransform.localScale.x < 0) //우향
        {
            if (targetPlayer.position.x < transform.position.x)
                rectTransform.localScale *= turn;
        }
    }

    public float NormalizeTime(Animator animator, string tag)    //애니메이션 프레임이 끝나면
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);

        if(animator.IsInTransition(0) && nextInfo.IsTag(tag))
            return nextInfo.normalizedTime;
        else if(!animator.IsInTransition(0) && currentInfo.IsTag(tag))
            return currentInfo.normalizedTime;
        else
            return 0;
    }


}
