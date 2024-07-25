using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public GameObject skillSlotPrefab; // 스킬 슬롯 프리팹
    public Transform skillSlotContainer; // 스킬 슬롯 컨테이너
    public Transform equippedSkillsPanel; // 장착된 스킬 패널
    public TextMeshProUGUI descriptionNameText; // 설명 패널 스킬 이름 텍스트
    public TextMeshProUGUI descriptionText; // 설명 패널 스킬 설명 텍스트

    public BaseSkill[] allSkills; // 모든 스킬
    private List<GameObject> equippedSkillSlots = new List<GameObject>(); // 장착된 슬롯 리스트
    private BaseSkill selectedSkill; // 현재 선택된 스킬

    private void Start()
    {
        DisplaySkills(); // 스킬 표시
        CreateSkillSlots(3); // 최대 3개의 슬롯 생성
    }

    private void DisplaySkills()
    {
        // 스킬 표시: 예시로 모든 스킬 버튼을 추가합니다.
        foreach (BaseSkill skill in allSkills)
        {
            GameObject skillSlot = Instantiate(skillSlotPrefab, skillSlotContainer);
            Button skillButton = skillSlot.GetComponentInChildren<Button>();
            TextMeshProUGUI skillNameText = skillSlot.GetComponentInChildren<TextMeshProUGUI>();

            skillNameText.text = skill.GetType().Name; // 스킬 이름을 사용합니다.

            skillButton.onClick.AddListener(() => OnSkillButtonClick(skill));
        }
    }

    private void CreateSkillSlots(int count)
    {
        // 기존 슬롯 제거
        foreach (var slot in equippedSkillSlots)
        {
            Destroy(slot);
        }
        equippedSkillSlots.Clear();

        // 새로운 슬롯 생성
        for (int i = 0; i < count; i++)
        {
            GameObject slot = Instantiate(skillSlotPrefab, equippedSkillsPanel);
            slot.SetActive(true); // 슬롯을 항상 활성화 상태로
            equippedSkillSlots.Add(slot);
        }
    }

    private void OnSkillButtonClick(BaseSkill skill)
    {
        selectedSkill = skill;
        UpdateDescriptionPanel();
    }

    private void UpdateDescriptionPanel()
    {
        if (selectedSkill != null)
        {
            descriptionNameText.text = selectedSkill.GetType().Name;
            descriptionText.text = selectedSkill.GetType().Name; // 예시로 스킬의 이름을 설명으로 사용
        }
    }

    //public void EquipSkill()
    //{
    //    if (selectedSkill != null)
    //    {
    //        foreach (var slot in equippedSkillSlots)
    //        {
    //            Image equippedSkillImage = slot.GetComponentInChildren<Image>();
    //            if (!equippedSkillImage.gameObject.activeSelf) // 이미지가 비활성화 상태인 슬롯 찾기
    //            {
    //                // 스킬 아이콘 설정
    //                Sprite skillIcon = selectedSkill.sprite; // 스킬의 아이콘으로 변경
    //                equippedSkillImage.sprite = skillIcon;
    //                equippedSkillImage.gameObject.SetActive(true); // 스킬 이미지 활성화
    //                TextMeshProUGUI equippedSkillNameText = slot.GetComponentInChildren<TextMeshProUGUI>();
    //                equippedSkillNameText.text = selectedSkill.GetType().Name;
    //                return; // 장착 후 종료
    //            }
    //        }

    //        Debug.LogWarning("No available slots to equip the skill.");
    //    }
    //}
}
