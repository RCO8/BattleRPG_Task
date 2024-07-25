using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerStatHandler playerStatHandler;
    // 오브젝트 풀
    public ArrowPool ArrowPool;
    void Start()
    {
        // 싱글톤 인스턴스 설정 및 파괴 방지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // CharacterManager의 playerStatHandler를 설정하거나 확인하는 코드
        CharacterManager characterManager = CharacterManager.instance;
    }
}
