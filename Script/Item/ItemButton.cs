using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public int index;
    public InventoryUI inventoryUI;
    public ItemSO itemData;
    public int itemCount;

    public Image icon;
    public TextMeshProUGUI countText;
    public Button itemButton;

    private void Awake()
    {
        // 아이콘을 자신에서 찾기
        Transform iconTransform = transform.Find("Icon");

        // 자식 오브젝트인 QuantityTxt에서 TextMeshProUGUI 컴포넌트를 찾기
        Transform quantityTransform = transform.Find("QuantityTxt");
        if (quantityTransform != null)
        {
            countText = quantityTransform.GetComponent<TextMeshProUGUI>();
        }
        icon.gameObject.SetActive(false);
        itemButton.interactable = true;
    }

    public void ApplyCountUI()
    {
        if (itemCount > 1)
        {
            countText.text = itemCount.ToString();
            countText.gameObject.SetActive(true);
        }
        else
        {
            countText.gameObject.SetActive(false);
        }
        icon.gameObject.SetActive(true);
    }

    // 아이템을 제거할 때 호출될 메서드
    public void RemoveItem()
    {
        // 아이템 데이터와 개수 초기화
        itemData = null;
        itemCount = 0;

        // UI 업데이트
        icon.gameObject.SetActive(false); // 아이콘 비활성화
        countText.gameObject.SetActive(false); // 수량 텍스트 비활성화
        itemButton.interactable = false; // 버튼 비활성화
    
    }

    public void OnClick()
    {
        inventoryUI.SelectedItem(index);
    }
}
