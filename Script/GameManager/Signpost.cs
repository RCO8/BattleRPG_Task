using System.Net.NetworkInformation;
using UnityEngine;

public class Signpost : MonoBehaviour
{
    public GameObject controlsUI; // Controls UI
    public GameObject SingUI; // 느낌표 UI

    private bool playerInRange = false;
    private RectTransform SingUIRectTransform;
    public float SingUIOffsetY = 50f;

    private void Start()
    {
        controlsUI.SetActive(false); // 초기에는 UI를 비활성화
        SingUIRectTransform = SingUI.GetComponent<RectTransform>();
        UpdateExclamationUIPosition();
    }

    private void Update()
    {
        // 플레이어가 범위 내에 있고, UI가 비활성화 되어 있을 때
        if (playerInRange && !controlsUI.activeSelf)
        {
            ShowControlsUI();

        }
        // 플레이어가 범위 밖에 있고, UI가 활성화 되어 있을 때
        else if (!playerInRange && controlsUI.activeSelf)
        {
            HideControlsUI();
        }
    }

    private void LateUpdate()
    {
        // 느낌표 UI의 위치를 업데이트
        UpdateExclamationUIPosition();
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
        }
    }

    private void ShowControlsUI()
    {
        controlsUI.SetActive(true); // Controls UI 활성화
        SingUI.SetActive(false);
    }

    private void HideControlsUI()
    {
        controlsUI.SetActive(false); // Controls UI 비활성화
        SingUI.SetActive(true);
    }

    private void UpdateExclamationUIPosition()
    {
        // 느낌표 UI를 표지판 위에 고정시키기
        Vector3 exclamationWorldPosition = transform.position + new Vector3(0, SingUIOffsetY / 100f, 0); // 오프셋 적용
        Vector3 exclamationScreenPosition = Camera.main.WorldToScreenPoint(exclamationWorldPosition);
        SingUIRectTransform.position = exclamationScreenPosition;
    }
}
