using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

public class SaveLoadUI : MonoBehaviour
{
    public GameObject saveStatusImage; // ���� ���¸� ǥ���� �̹��� ������Ʈ
    public TextMeshProUGUI saveStatusText; // ���� ���¸� ǥ���� �ؽ�Ʈ UI
    public TextMeshProUGUI loadStatusText; // �ε� ���¸� ǥ���� �ؽ�Ʈ UI
    public GameObject saveSlotPrefab; // ���� ���� ������
    public GameObject loadSlotPrefab; // �ε� ���� ������
    public Transform saveSlotContainer; // ���� ���Ե��� ���� �����̳�
    public Transform loadSlotContainer; // �ε� ���Ե��� ���� �����̳�

    private string[] saveFilePaths;
    private List<GameObject> saveSlots = new List<GameObject>();
    private List<GameObject> loadSlots = new List<GameObject>();
    private StatusUI statusUI; // StatusUI ��ũ��Ʈ�� ����

    private void Start()
    {
        saveFilePaths = new string[]
        {
            Path.Combine(Application.persistentDataPath, "save_1.json"),
            Path.Combine(Application.persistentDataPath, "save_2.json"),
            Path.Combine(Application.persistentDataPath, "save_3.json"),
            Path.Combine(Application.persistentDataPath, "save_4.json")
        };

       
        // ���� ���� ���� ����
        for (int i = 0; i < saveFilePaths.Length; i++)
        {
            int slotIndex = i; // Ŭ���� ���� �ذ��� ���� ���� ������ ����

            GameObject saveSlot = Instantiate(saveSlotPrefab, saveSlotContainer);
            saveSlot.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => SaveGame(slotIndex)); // Save ��ư
            saveSlots.Add(saveSlot);

            GameObject loadSlot = Instantiate(loadSlotPrefab, loadSlotContainer);
            loadSlot.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => LoadGame(slotIndex)); // Load ��ư
            loadSlots.Add(loadSlot);

            // ���� �ؽ�Ʈ ������Ʈ
            UpdateSlotText(slotIndex, saveSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>(), loadSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>());
        }

        // �ʱ� ���¸� �����
        saveStatusImage.SetActive(false);
    }

    public void SaveGame(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= saveFilePaths.Length) return;

        // ����Ʈ �Ϸ� ���� ���
        int completedQuests = QuestManager.instance.quests.Count(q => q.isCompleted);

        // �÷��̾� ������ ����
        PlayerData data = new PlayerData
        {
            playerName = statusUI.NameText.text, // StatusUI���� �÷��̾� �̸� ��������
            completedQuests = completedQuests
        };

        // JSON���� ����ȭ�Ͽ� ���Ϸ� ����
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePaths[slotIndex], json);

        // ���� �ؽ�Ʈ ������Ʈ
        saveStatusText.text = "���� ���� �Ϸ�!";
        saveStatusImage.SetActive(true); // �̹��� ������Ʈ Ȱ��ȭ

        // ���� ���� �ؽ�Ʈ ������Ʈ
        UpdateSlotText(slotIndex, saveSlots[slotIndex].transform.GetChild(1).GetComponent<TextMeshProUGUI>(), loadSlots[slotIndex].transform.GetChild(1).GetComponent<TextMeshProUGUI>());
    }

    public void LoadGame(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= saveFilePaths.Length) return;

        string filePath = saveFilePaths[slotIndex];
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            // ����� �����͸� �÷��̾ ����
            statusUI.NameText.text = data.playerName;
            int completedQuests = data.completedQuests;

            // ���� �ؽ�Ʈ ������Ʈ
            loadStatusText.text = $"�̸�: {data.playerName}\n�Ϸ�� ����Ʈ: {completedQuests}";
            // �ε� ���� �̹����� Ȱ��ȭ �ʿ� (���� ���, �ʿ信 ����)
        }
    }

    private void UpdateSlotText(int slotIndex, TextMeshProUGUI saveButtonText, TextMeshProUGUI loadButtonText)
    {
        string filePath = saveFilePaths[slotIndex];
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            string slotText = $"Name: {data.playerName}\nQuests: {data.completedQuests}";
            saveButtonText.text = slotText;
            loadButtonText.text = slotText;
        }
        else
        {
            saveButtonText.text = "Empty Slot";
            loadButtonText.text = "Empty Slot";
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public int completedQuests;
}
