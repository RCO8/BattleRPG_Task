using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.U2D.Animation;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerAnimationEvent : MonoBehaviour
{
    float _value = 0.0f;

    public void NormalAttack()
    {
        var _player = CharacterManager.instance.basePlayer as Player_Battle;

        //normal공격 조건 걸기
        _player.boxCollider_Weapon.enabled = true;
    }

    public void EndNormalAttack()
    {
        var _player = CharacterManager.instance.basePlayer as Player_Battle;

        //normal공격 조건 걸기
        _player.boxCollider_Weapon.enabled = false;

        if (_player.attack.onNextCombo)
        {
            _player.attack.ComboAttack(_player.attack.combo);
        }
        else
        {
            _player.attack.EndCombo();
        }
        
    }

    public void BowAttack()
    {
        
    }

    public void MagicAttack()
    {
        
    }

    public void ActiveSkill()
    {
        
    }
}
