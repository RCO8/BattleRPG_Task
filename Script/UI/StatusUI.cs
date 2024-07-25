using TMPro;
using UnityEngine;

public class StatusUI : MonoBehaviour
{
    private PlayerStatData playerStat;
    private PlayerHPSystem playerHPSystem;
    private PlayerMPSystem playerMPSystem;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI AtkDmgText;
    public TextMeshProUGUI AtkSpdText;
    public TextMeshProUGUI GoldText;

    private void Start()
    {

        if (CharacterManager.instance == null)
        {
            Debug.LogError("CharacterManager.instance is null!");
            return;
        }

        var playerStatHandler = CharacterManager.instance.playerStatHandler;

        if (playerStatHandler == null)
        {
            return;
        }

        playerStat = playerStatHandler.currentStats;
        playerHPSystem = playerStatHandler.hpSystem;
        playerMPSystem = playerStatHandler.mpSystem;


        if (playerStat != null && playerHPSystem != null && playerMPSystem != null)
        {
            RefreshUI();
        }
    }

    private void OnEnable()
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        if (playerStat == null || playerHPSystem == null || playerMPSystem == null)
        {
            return;
        }

        NameText.text = playerStat.playerName ?? "박춘배";
        HPText.text = $"{playerHPSystem.currentHealth}/{playerStat.maxHealth}";
        ManaText.text = $"{playerMPSystem.currentMana}/{playerStat.maxMana}";
        AtkDmgText.text = $"{playerStat.attackDamage}";
        AtkSpdText.text = $"{playerStat.attackSpeed}";
        GoldText.text = $"{playerStat.goldAmount}";
    }
}
