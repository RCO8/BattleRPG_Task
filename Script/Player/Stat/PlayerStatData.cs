using System;

//public enum EStat
//{
//    MaxHP,
//    MaxMana,
//    AttackDamage,
//    AttackSpeed,
//    MoveSpeed
//}

//public enum EStatType
//{
//    Add,
//    Mul,
//    Ovr
//}

[Serializable]
public class PlayerStatData
{
    public float maxHealth;
    public float maxMana;
    public float attackDamage;  
    public float attackSpeed;
    public float moveSpeed;
    // 추가된 필드
    public string playerName; // 플레이어 이름
    public int goldAmount;  // 플레이어 소지 금액
}
