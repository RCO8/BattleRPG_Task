using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static PlayerObj;

public class UserInfoUI : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    public TextMeshProUGUI attackDamageText;
    public TextMeshProUGUI goldText;

    // PlayerStatData를 참조할 변수
    public PlayerStatData playerStats;
    private PlayerHPSystem playerHPSystem;
    private PlayerMPSystem playerMPSystem;


    private void Start()
    {
        // PlayerStatData 초기화
        playerStats = CharacterManager.instance.playerStatHandler.currentStats;
        playerHPSystem = CharacterManager.instance.playerStatHandler.hpSystem;
        playerMPSystem = CharacterManager.instance.playerStatHandler.mpSystem;

        //스탯이 바뀔 때, 델리게이트 연결
        CharacterManager.instance.basePlayer.OnChangeStat += UpdateUI;
        // UI 업데이트
        UpdateUI();
    }

    private void UpdateUI()
    {
        // PlayerStatData의 데이터를 UI에 반영
        playerNameText.text = "Player"; // 플레이어 이름 설정
        healthText.text = $"체력: {playerHPSystem.currentHealth} / {playerStats.maxHealth}";
        manaText.text = $"마나: {playerMPSystem.currentMana} / {playerStats.maxMana}";
        attackDamageText.text = $"공격력: {playerStats.attackDamage}";
        goldText.text = $"소지금: 0"; // 여기서는 예시로 0으로 설정
    }
}
