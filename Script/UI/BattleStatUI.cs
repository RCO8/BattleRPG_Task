using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStatUI : MonoBehaviour
{
    public static BattleStatUI instance;

    private PlayerStatHandler _playerStatHandler;
    private EnemyHPSystem _enemyHPSystem;

    public Slider playerHpBar;
    public Slider playerManaBar;
    public Slider enemyHPBar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _playerStatHandler = CharacterManager.instance.playerStatHandler;
        _enemyHPSystem = CharacterManager.instance.enemy.hpSystem;

        //Ω∫≈»¿Ã πŸ≤ ∂ß, µ®∏Æ∞‘¿Ã∆Æ ø¨∞·
        //CharacterManager.instance.basePlayer.OnChangeStat += UpdateUI;
        //UpdateUI();
    }

    public void UpdateUI()//private
    {
        playerHpBar.value = _playerStatHandler.hpSystem.currentHealth / _playerStatHandler.hpSystem.maxHealth;
        playerManaBar.value = _playerStatHandler.mpSystem.currentMana / _playerStatHandler.mpSystem.maxMana;
        enemyHPBar.value = _enemyHPSystem.currentHealth / _enemyHPSystem.maxHealth;
    }
}
