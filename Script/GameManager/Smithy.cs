using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Smithy : MonoBehaviour
{

    public Button enhanceButton; // 강화 버튼

    public GameObject enhancementUI; // 강화 UI
    public GameObject enhancementResultUI; // 강화 결과 UI
    public Slider enhancementProgressSlider; // 강화 진행 게이지
    public TextMeshProUGUI enhancementResultText; // 강화 결과 텍스트

    private int currentEnhancementLevel = 0; // 현재 강화 수준
    private int baseSuccessChance = 100; // 처음 강화 성공 확률
    private int[] successChances = { 70, 60, 50, 40, 30, 20, 10, 10, 5 }; // 강화 성공 확률 배열
    private int enhancementCost = 10; // 강화 비용
    private int enhancementValue = 10; // 강화 수치

    private void Start()
    {
        enhanceButton.onClick.AddListener(StartEnhancementProcess);
        enhancementProgressSlider.gameObject.SetActive(false); // 초기에는 게이지 숨김
        enhancementResultUI.SetActive(false); // 초기에는 강화 결과 UI 숨김
    }

    public void StartEnhancementProcess()
    {
        enhancementProgressSlider.value = 0; // 강화 진행 게이지 초기화
        enhancementUI.SetActive(true);
        enhancementProgressSlider.gameObject.SetActive(true);
        StartCoroutine(EnhancementProgress());
    }

    public IEnumerator EnhancementProgress()
    {
        float duration = 3.0f; // 게이지가 차는 시간
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            enhancementProgressSlider.value = elapsed / duration;
            yield return null;
        }

        enhancementProgressSlider.gameObject.SetActive(false);
        EnhanceItem();
    }

    private void EnhanceItem()
    {
        int roll = Random.Range(1, 101); // 1부터 100 사이의 난수 생성
        bool success = roll <= GetSuccessChance();

        if (success)
        {
            currentEnhancementLevel++;
            enhancementValue += currentEnhancementLevel == 10 ? 20 : 10; // 10강은 20% 증가
            // 강화 비용 설정
            if (currentEnhancementLevel == 10)
            {
                enhancementCost += 20; // 9강에서 10강 가는 경우 비용 20 증가
            }
            else
            {
                enhancementCost += 10; // 나머지는 비용 10 증가
            }
            enhancementResultText.text = "강화 성공!!";
        }
        else
        {
            enhancementResultText.text = "어이쿠 손이 미끄러졌네";
        }
        ShowEnhancementResult();
    }

    private void ShowEnhancementResult()
    {
        enhancementResultUI.SetActive(true);
        StartCoroutine(HideEnhancementResultAfterDelay());
    }

    private IEnumerator HideEnhancementResultAfterDelay()
    {
        yield return new WaitForSeconds(3.0f); // 3초 대기
        enhancementResultUI.SetActive(false); // 강화 결과 UI 숨기기
        enhancementUI.SetActive(true); // 강화 UI 보이기
    }

    public void CloseEnhancementResult()
    {
        enhancementResultUI.SetActive(false);
        enhancementUI.SetActive(false);
    }

    private int GetSuccessChance()
    {
        if (currentEnhancementLevel < successChances.Length)
        {
            return baseSuccessChance - successChances[currentEnhancementLevel];
        }
        else
        {
            return 5; // 10번째 강화 시도 후에는 최소 5% 성공 확률 유지
        }
    }
}
