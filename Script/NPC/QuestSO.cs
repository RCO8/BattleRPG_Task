using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/Quest")]
public class Quest : ScriptableObject
{
    public string questTitle;
    public string questDescription;
    public int coinsRequired; // 목표 수량 (코인 또는 적)
    public bool isCompleted; // 퀘스트 완료 여부
    public string questStartDescription; // 퀘스트 시작 대화 내용
    public string questCompletionDescription; // 퀘스트 완료 대화 내용

    // 퀘스트를 완료로 설정
    public void CompleteQuest()
    {
        isCompleted = true;
    }

    // 퀘스트를 시작하거나 진행
    public void StartQuest()
    {
        isCompleted = false;
    }
}
