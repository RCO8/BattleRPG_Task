using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyProduct : MonoBehaviour
{
    [SerializeField] private Button BuyButton;
    [SerializeField] private RectTransform BuyCount;
    [SerializeField] private TextMeshProUGUI CountText;

    private int buyCountNum = 1;

    private void OnEnable()
    {
        ApplyCount();
    }

    public void BuyItem()
    {
        //아이템 구매 버튼을 누르면 "몇개 사시겠습니까" 띄우기 (소비 아이템이면)
        BuyCount.gameObject.SetActive(true);
    }

    public void IncreaseCount()
    {
        if (buyCountNum < 100)
            buyCountNum++;
        ApplyCount();
    }

    public void DecreaseCount()
    {
        if (buyCountNum > 1)
            buyCountNum--;
        ApplyCount();
    }

    private void ApplyCount()
    {
        CountText.text = buyCountNum.ToString();
    }
}