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

    // PlayerStatData�� ������ ����
    public PlayerStatData playerStats;
    private PlayerHPSystem playerHPSystem;
    private PlayerMPSystem playerMPSystem;


    private void Start()
    {
        // PlayerStatData �ʱ�ȭ
        playerStats = CharacterManager.instance.playerStatHandler.currentStats;
        playerHPSystem = CharacterManager.instance.playerStatHandler.hpSystem;
        playerMPSystem = CharacterManager.instance.playerStatHandler.mpSystem;

        //������ �ٲ� ��, ��������Ʈ ����
        CharacterManager.instance.basePlayer.OnChangeStat += UpdateUI;
        // UI ������Ʈ
        UpdateUI();
    }

    private void UpdateUI()
    {
        // PlayerStatData�� �����͸� UI�� �ݿ�
        playerNameText.text = "Player"; // �÷��̾� �̸� ����
        healthText.text = $"ü��: {playerHPSystem.currentHealth} / {playerStats.maxHealth}";
        manaText.text = $"����: {playerMPSystem.currentMana} / {playerStats.maxMana}";
        attackDamageText.text = $"���ݷ�: {playerStats.attackDamage}";
        goldText.text = $"������: 0"; // ���⼭�� ���÷� 0���� ����
    }
}
