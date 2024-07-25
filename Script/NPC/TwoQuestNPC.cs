using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class TwoQuestNPC : MonoBehaviour
{
    public BaseQuest quest;
    public GameObject obstacle;
    public GameObject questUI;
    public GameObject completeUI;
    public GameObject coinUI;
    public TextMeshProUGUI questUIText;
    public TextMeshProUGUI coinUIText;
    public Button confirmButton;
    public Button closeButton;

    private bool playerInRange = false;

    private void Start()
    {
        confirmButton.onClick.AddListener(StartQuest);
        closeButton.onClick.AddListener(CloseQuestUI);

        questUI.SetActive(false);
        completeUI.SetActive(false);
        coinUI.SetActive(false);
        coinUIText.gameObject.SetActive(false);

        if (quest is CoinCollectQuest coinQuest)
        {
            coinQuest.coinsCollected = 0; // 코인 수집 초기화
            coinQuest.isStarted = false; // 퀘스트 시작 상태 초기화
            coinQuest.isCompleted = false; // 퀘스트 완료 상태 초기화

            // 기존의 UI와 장애물 상태 복원
            completeUI.SetActive(false);
            coinUI.SetActive(false);
            coinUIText.gameObject.SetActive(false);


        }
    }

    private void Update()
    {   
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            if (quest is CoinCollectQuest coinQuest)
            {
                if (!coinQuest.isStarted && !coinQuest.isCompleted)
                {
                    ShowQuestStartDialogue();
                }
                else if (coinQuest.isStarted && coinQuest.isCompleted)
                {
                    ShowQuestComplete();
                }
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Coin") && quest is CoinCollectQuest coinQuest && coinQuest.isStarted && !coinQuest.isCompleted)
        {
            CollectCoin(other.gameObject);
        }
    }

    private void ShowQuestStartDialogue()
    {
        if (quest is CoinCollectQuest coinQuest)
        {
            questUIText.text = coinQuest.questStartDescription;  // 퀘스트 시작 대화 내용 설정
            questUI.SetActive(true);          
        }
    }

    private void ShowQuestComplete()
    {
        if (quest is CoinCollectQuest coinQuest)
        {
            questUIText.text = coinQuest.questCompletionDescription; // ����Ʈ �Ϸ� ��ȭ ����
            completeUI.SetActive(true);
            coinUI.SetActive(false);
            coinUIText.gameObject.SetActive(false);
            QuestManager.instance.CompleteQuest(coinQuest); // ����Ʈ �Ŵ����� �Ϸ� ��û
            Destroy(obstacle); // ��ֹ� ����
        }    
    }

    public void CloseQuestUI()
    {
        questUI.SetActive(false);
        completeUI.SetActive(false);
    }

    public void StartQuest()
    {
        if (quest is CoinCollectQuest coinQuest)
        {
            coinQuest.StartQuest();
            questUI.SetActive(false);
            coinUIText.text = $"0/{coinQuest.coinsRequired}";
            coinUI.SetActive(true);
            coinUIText.gameObject.SetActive(true);
        }
    }

    public void CollectCoin(GameObject coin)
    {
        if (quest is CoinCollectQuest coinQuest && coinQuest.isStarted && !coinQuest.isCompleted)
        {
            coinQuest.coinsCollected++;
            coinUIText.text = $"{coinQuest.coinsCollected}/{coinQuest.coinsRequired}";
            Destroy(coin); 
            if (coinQuest.coinsCollected >= coinQuest.coinsRequired)
            {
                coinQuest.CompleteQuest();
                ShowQuestComplete();
            }
        }
    }
}
