using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestNPC : MonoBehaviour
{
    public GameObject questDialogueUI;  // 퀘스트 대화 UI
    public GameObject questCompleteUI;  // 퀘스트 완료 UI
    public GameObject questRewardUI;    // 퀘스트 보상 UI
    public TextMeshProUGUI questDialogueText;  // 퀘스트 대화 텍스트
    public TextMeshProUGUI questCompleteText;  // 퀘스트 완료 텍스트
    public TextMeshProUGUI questRewardText;    // 퀘스트 보상 텍스트
    public Button acceptButton;         // 퀘스트 수락 버튼
    public Button closeButton;          // 닫기 버튼
    public BaseQuest quest;             // 이 NPC가 주는 퀘스트

    private bool playerInRange = false;
    private bool questAccepted = false;

    private void Start()
    {
        // UI 초기 상태 설정
        questDialogueUI.SetActive(false);
        questCompleteUI.SetActive(false);
        questRewardUI.SetActive(false);

        // 버튼 클릭 이벤트 등록
        acceptButton.onClick.AddListener(AcceptQuest);
        closeButton.onClick.AddListener(CloseQuestUI);
    }

    private void Update()
    {
        // 플레이어가 범위 내에 있고, Z 키를 눌렀을 때 상호작용 처리
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            if (!questAccepted)
            {
                ShowQuestDialogue();
            }
            else if (questAccepted && !quest.isCompleted)
            {
                ShowQuestDialogue(); // 퀘스트 수락 후에도 대화 UI가 계속 나오게 설정
            }
            else if (questAccepted && quest.isCompleted)
            {
                ShowQuestComplete(); // 퀘스트 완료 UI가 계속 나오게 설정
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            CloseQuestUI();
        }
    }

    private void ShowQuestDialogue()
    {
        questDialogueUI.SetActive(true); 
        questDialogueText.text = quest.questDescription; 
    }

    private void AcceptQuest()
    {
        questAccepted = true;
        quest.StartQuest();
        questDialogueUI.SetActive(false);
    }

    private void ShowQuestComplete()
    {
        questCompleteUI.SetActive(true); 
        questCompleteText.text = "퀘스트 완료!";
    }

    public void HideQuestReward()
    {
        questRewardUI.SetActive(false); 
    }

    public void CloseQuestUI()
    {
        questDialogueUI.SetActive(false); 
        questCompleteUI.SetActive(false); 
        questRewardUI.SetActive(false);
    }
}
