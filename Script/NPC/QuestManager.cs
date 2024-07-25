using UnityEngine;
using TMPro;
using System.IO;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;

    public GameObject questUI; // 전체 퀘스트 UI
    public TextMeshProUGUI questTitleText; // 퀘스트 제목 텍스트
    public TextMeshProUGUI questDescriptionText; // 퀘스트 설명 텍스트
    public GameObject questEntryPrefab; // 퀘스트 항목 프리팹
    public Transform questListContent; // 퀘스트 목록 콘텐츠 영역
    public BaseQuest[] quests; // 모든 퀘스트를 담은 배열

    private string saveFilePath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지되도록 설정
            saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        foreach (BaseQuest quest in quests)
        {
            AddQuestEntry(quest);
        }
    }

    public void UpdateQuestDescription(string description)
    {
        questDescriptionText.text = description;
    }

    public void UpdateQuestTitle(string title)
    {
        questTitleText.text = title;
    }

    public void ToggleQuestUI(bool show)
    {
        questUI.SetActive(show);
    }

    public void AddQuestEntry(BaseQuest quest)
    {
        // 퀘스트 항목 프리팹 인스턴스 생성
        GameObject questEntryObject = Instantiate(questEntryPrefab, questListContent);
        QuestEntry questEntry = questEntryObject.GetComponent<QuestEntry>();

        // 퀘스트 항목 데이터 설정
        questEntry.SetData(quest);
    }

    public void CompleteQuest(BaseQuest quest)
    {
        quest.CompleteQuest();
        // 업데이트된 퀘스트 상태를 UI에 반영
        foreach (Transform child in questListContent)
        {
            QuestEntry entry = child.GetComponent<QuestEntry>();
            if (entry.quest == quest)
            {
                entry.UpdateQuestUI();
            }
        }
    }
}
