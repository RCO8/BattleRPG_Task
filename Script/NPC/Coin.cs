using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // TwoQuestNPC를 찾아서
            TwoQuestNPC questNPC = FindObjectOfType<TwoQuestNPC>();

            // TwoQuestNPC가 존재하고, 퀘스트가 시작되었으며 완료되지 않은 상태인지 확인
            if (questNPC != null && questNPC.quest is BaseQuest baseQuest && baseQuest.isStarted && !baseQuest.isCompleted)
            {
                gameObject.SetActive(true);
                // 코인을 수집 처리
                questNPC.CollectCoin(gameObject);
                // 코인 오브젝트 삭제
                Destroy(gameObject);
            }
        }
    }
}
