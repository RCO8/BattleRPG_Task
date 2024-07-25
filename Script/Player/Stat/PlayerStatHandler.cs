using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStatType
{
    Add,
    Multiple,
    Override
}
public enum EStat
{
    MaxHP,
    MaxMana,
    AttackDamage,
    AttackSpeed,
    MoveSpeed
}

public class PlayerStatHandler : MonoBehaviour
{
    [SerializeField] private PlayerStatData _baseStats;
    public PlayerStatData currentStats { get; private set; }
    public PlayerHPSystem hpSystem { get; private set; }
    public PlayerMPSystem mpSystem { get; private set; }
    public PlayerStatData modifierStats_Add { get; private set; }//
    public PlayerStatData modifierStats_Multiple { get; private set; }//
    public PlayerStatData modifierStats_Override { get; private set; }//


    public List<PlayerStatData> modifierStats { get; private set; }


    private void Awake()
    {
        hpSystem = GetComponent<PlayerHPSystem>();
        mpSystem = GetComponent<PlayerMPSystem>();
        if (hpSystem == null) Debug.LogError("PlayerHPSystem is not attached!");
        if (mpSystem == null) Debug.LogError("PlayerMPSystem is not attached!");

        modifierStats_Add = new PlayerStatData();
        modifierStats_Multiple = new PlayerStatData();
        modifierStats_Override = new PlayerStatData();
       // modifierStats = new List<PlayerStatData>();//
        if (_baseStats == null)
        {
            _baseStats = new PlayerStatData
            {
                maxHealth = 100,
                maxMana = 50,
                attackDamage = 10,
                attackSpeed = 1,
                moveSpeed = 5,
                playerName = "PlayerName", // 이름 기본값 설정
                goldAmount = 500 // 소지금 기본값 설정
            };
        }
        UpdateCharacterStat();
    }

    private void UpdateCharacterStat()
    {
        currentStats = new PlayerStatData();

        currentStats.maxHealth = _baseStats.maxHealth;
        currentStats.maxMana = _baseStats.maxMana;
        currentStats.attackDamage = _baseStats.attackDamage;
        currentStats.attackSpeed = _baseStats.attackSpeed;
        currentStats.moveSpeed = _baseStats.moveSpeed;

        Add_fun(modifierStats_Add);
        Mult_fun(modifierStats_Multiple);
        Ovr_fun(modifierStats_Override);
    }

    public void ChangeStat(EStat _stat, EStatType _statType, float _value)
    {
        if (_statType != EStatType.Add) _value = Mathf.Max(_value, 0.1f);

        switch (_stat)
        {
            case EStat.MaxHP:
                if (_statType == EStatType.Add) modifierStats_Add.maxHealth =+ _value;
                else if (_statType == EStatType.Multiple) modifierStats_Multiple.maxHealth =+ _value;
                else if (_statType == EStatType.Override) modifierStats_Override.maxHealth =+ _value;
                break;
            case EStat.MaxMana:
                if (_statType == EStatType.Add) modifierStats_Add.maxMana =+ _value;
                else if (_statType == EStatType.Multiple) modifierStats_Multiple.maxMana =+ _value;
                else if (_statType == EStatType.Override) modifierStats_Override.maxMana =+ _value;
                break;
            case EStat.AttackDamage:
                if (_statType == EStatType.Add) modifierStats_Add.attackDamage =+ _value;
                else if (_statType == EStatType.Multiple) modifierStats_Multiple.attackDamage =+ _value;
                else if (_statType == EStatType.Override) modifierStats_Override.attackDamage =+ _value;
                break;
            case EStat.AttackSpeed:
                if (_statType == EStatType.Add) modifierStats_Add.attackSpeed =+ _value;
                else if (_statType == EStatType.Multiple) modifierStats_Multiple.attackSpeed =+ _value;
                else if (_statType == EStatType.Override) modifierStats_Override.attackSpeed =+ _value;
                break;
            case EStat.MoveSpeed:
                if (_statType == EStatType.Add) modifierStats_Add.moveSpeed =+ _value;
                else if (_statType == EStatType.Multiple) modifierStats_Multiple.moveSpeed =+ _value;
                else if (_statType == EStatType.Override) modifierStats_Override.moveSpeed =+ _value;
                break;
        }

        UpdateCharacterStat();
    }

    private void Add_fun(in PlayerStatData _playerStatData)
    {
        currentStats.maxHealth += _playerStatData.maxHealth;
        currentStats.maxMana += _playerStatData.maxMana;
        currentStats.attackDamage += _playerStatData.attackDamage;
        currentStats.attackSpeed += _playerStatData.attackSpeed;
        currentStats.moveSpeed += _playerStatData.moveSpeed;
    }
    private void Mult_fun(in PlayerStatData _playerStatData)
    {
        float[] _arrModify = { _playerStatData.maxHealth, _playerStatData.maxMana, _playerStatData.attackDamage, _playerStatData.attackSpeed, _playerStatData.moveSpeed};
        float[] _arrBase = { currentStats.maxHealth, currentStats.maxMana, currentStats.attackDamage, currentStats.attackSpeed, currentStats.moveSpeed };

        for (int i = 0; i < _arrModify.Length; i++)
        {
            if (_arrModify[i] <= 0.0f) _arrBase[i] *= 1.0f;
            else _arrBase[i] *= _arrModify[i];
        }
    }
    private void Ovr_fun(in PlayerStatData _playerStatData)
    {
        float[] _arrModify = { _playerStatData.maxHealth, _playerStatData.maxMana, _playerStatData.attackDamage, _playerStatData.attackSpeed, _playerStatData.moveSpeed };
        float[] _arrBase = { currentStats.maxHealth, currentStats.maxMana, currentStats.attackDamage, currentStats.attackSpeed, currentStats.moveSpeed };

        for (int i = 0; i < _arrModify.Length; i++) if (_arrModify[i] > 0.0f) _arrBase[i] = _arrModify[i];
    }
}