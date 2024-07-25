using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMPSystem : MonoBehaviour
{
    private PlayerStatHandler statHandler;

    public event Action<float> OnUseMana;        //마나 사용할 때
    public event Action<float> OnFillMana;       //마나 찰 때

    public float currentMana { get; set; }
    //public float maxMana => statHandler.currentStats.maxHealth;
    public float maxMana { get; set; }

    private void Awake()
    {
        statHandler = GetComponent<PlayerStatHandler>();
    }

    private void Start()
    {
        maxMana = statHandler.currentStats.maxMana;
        currentMana = maxMana;
    }

    public void UseMana(float _mana)
    {
        if (_mana <= 0) OnFillMana?.Invoke(_mana);
        else
        {
            if (currentMana < _mana) return;
            else OnUseMana?.Invoke(_mana);
        }

        //마나 사용
        currentMana -= _mana;

        //0미만, 최대마나 초과로 넘어가지 않게 조정한다.
        currentMana = Mathf.Clamp(currentMana, 0.0f, maxMana);

        CharacterManager.instance.basePlayer.UpdateStat();
    }
}
