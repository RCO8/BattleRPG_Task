using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestEntry : MonoBehaviour
{
    public TextMeshProUGUI questTitleText;
    public Image circleImage;
    public Image checkmarkImage;
    public Button button;
    public BaseQuest quest; // Quest를 BaseQuest로 변경

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void SetData(BaseQuest quest) // Quest를 BaseQuest로 변경
    {
        this.quest = quest;
        questTitleText.text = quest.questTitle;
        UpdateQuestUI();
    }

    public void OnClick()
    {
        QuestManager.instance.UpdateQuestTitle(quest.questTitle);
        QuestManager.instance.UpdateQuestDescription(quest.questDescription);
    }

    public void UpdateQuestUI()
    {
        // Update circle image visibility
        circleImage.gameObject.SetActive(true);
        // Update checkmark image visibility based on quest completion
        checkmarkImage.gameObject.SetActive(quest.isCompleted);
    }
}
