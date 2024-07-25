using UnityEngine;

public class SmithyNPC : MonoBehaviour
{
    public GameObject smithyUI; // 대장간 UI

    private bool playerInRange = false;

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
            HideSmithyUI(); // 범위에서 나가면 UI 숨기기
        }
    }

    private void Update()
    {
        // 플레이어가 범위 내에 있고, Z 키를 눌렀을 때 상호작용 처리
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            InteractWithNPC();
        }
    }

    public void ShowSmithyUI()
    {
        smithyUI.SetActive(true); // 대장간 UI 활성화
    }

    public void HideSmithyUI()
    {
        smithyUI.SetActive(false); // 대장간 UI 비활성화
    }

    private void InteractWithNPC()
    {
        // 상호작용 처리 로직 추가
        Debug.Log("Interacting with NPC");

        // UI 활성화
        ShowSmithyUI();
    }
}
