using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonControll
{
    GameData gameData;
    PlayerStatHandler playerStat;
    string path = Path.Combine(Application.dataPath, "Save.json");
    public JsonControll()
    {
        playerStat = CharacterManager.instance.playerStatHandler;
    }

    private void SaveData()
    {
        gameData.CurrentHealth = playerStat.hpSystem.currentHealth;
        gameData.MaxHealth = playerStat.hpSystem.maxHealth;
        gameData.CurrentMana = playerStat.mpSystem.currentMana;
        gameData.MaxMana = playerStat.mpSystem.maxMana;

        gameData.PlayerStat = playerStat.currentStats;

        gameData.Position = playerStat.transform.position;
    }

    private void LoadData()
    {
        playerStat.hpSystem.currentHealth = gameData.CurrentHealth;
        playerStat.hpSystem.maxHealth = gameData.MaxHealth;
        playerStat.mpSystem.currentMana = gameData.CurrentMana;
        playerStat.mpSystem.maxMana = gameData.MaxMana;



        playerStat.transform.position = gameData.Position;
    }

    public void SaveFile()
    {
        SaveData();
        var json = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(path, json);
    }
    public void LoadFile()
    {
        try
        {
            LoadData();
            var json = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(json);
        }
        catch
        {
            Debug.LogAssertion("파일 불러오기 오류");
        }
    }
}

[System.Serializable]
public class GameData
{
    public string playerName;
    public float CurrentHealth;
    public float MaxHealth;
    public float CurrentMana;
    public float MaxMana;

    public PlayerStatData PlayerStat;

    public Vector2 Position;

    public int completedQuests; // 완료된 퀘스트 수

    public int attack;
}