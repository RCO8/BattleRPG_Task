using UnityEngine;

[CreateAssetMenu(fileName = "CoinCollectQuest", menuName = "Quest/CoinCollectQuest")]
public class CoinCollectQuest : BaseQuest
{
    public int coinsRequired; // 목표 수량 (코인 수)
    public int coinsCollected; // 현재 수집한 코인 수

    public override void StartQuest()
    {
        isStarted = true;
        isCompleted = false;
        coinsCollected = 0; // 퀘스트 시작 시 코인 수집 수 초기화
    }

    public override void CompleteQuest()
    {
        if (coinsCollected >= coinsRequired)
        {
            isCompleted = true;
        }
    }
}


