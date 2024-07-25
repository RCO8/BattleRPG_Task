using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EffectState : sbyte
{
    //추후에 추가 예정
    None,
    Stun
}

public class EnemyEffect : MonoBehaviour
{
    [SerializeField] private List<GameObject> effectList;
    private EffectState currentEffectState;

    public void ChangeEffectState(EffectState _effectState)
    {
        switch (_effectState)
        {
            case EffectState.None:
                OnOff(currentEffectState, false);
                currentEffectState = EffectState.None;
                break;
            case EffectState.Stun:
                currentEffectState = EffectState.Stun;
                OnOff(currentEffectState, true);
                break;
        }
    }

    private void OnOff(EffectState _effectState, bool _onOff)
    {
        effectList[(int)_effectState - 1].gameObject.SetActive(_onOff);
    }
}
