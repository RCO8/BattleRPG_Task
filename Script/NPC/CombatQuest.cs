using UnityEngine;

[CreateAssetMenu(fileName = "CombatQuest", menuName = "Quest/CombatQuest")]
public class CombatQuest : BaseQuest
{
    public int enemiesRequired; // 목표 적 수
    public int enemiesDefeated; // 현재 처치한 적 수

    public override void StartQuest()
    {
        isStarted = true;
        isCompleted = false;
        enemiesDefeated = 0; // 퀘스트 시작 시 적 처치 수 초기화
    }

    public override void CompleteQuest()
    {
        if (enemiesDefeated >= enemiesRequired)
        {
            isCompleted = true;
        }
    }
}
