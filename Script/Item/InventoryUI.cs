using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemButton[] Items;
    public GameObject InventoryWindow;
    public Transform ItemList;

    [Header("SelectedItem")]
    public GameObject ItemInfoPanel;
    public Image selectedItemImage;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;

    [Header("Button Manager")]
    public GameObject UseButton;
    public GameObject EquipButton;
    public GameObject UnequipButton;
    public GameObject RemoveButton;

    ItemSO selectedItem;
    int selectedItemIndex = -1;

    private void Start()
    {
        Items = new ItemButton[ItemList.childCount];

        for (int i = 0; i < ItemList.childCount; i++)
        {
            Items[i] = ItemList.GetChild(i).GetComponent<ItemButton>();
            Items[i].index = i;
            Items[i].inventoryUI = this;
        }

        AddInitialItems();

        UpdateUI();
        ClearSelectedText();
        ItemInfoPanel.SetActive(true);
        selectedItemImage.gameObject.SetActive(false);
        RemoveButton.SetActive(true);
    }

    public void AddInitialItems()
    {
        // 아이템 로드 및 캐싱
        ItemSO energyDrink = Resources.Load<ItemSO>("ResourcesItem/EnergyDrink");
        ItemSO gaugeProtein = Resources.Load<ItemSO>("ResourcesItem/GaugeProtein");

        if (energyDrink == null || gaugeProtein == null)
        {
            Debug.LogError("Initial items not found in Resources.");
            return;
        }

        // 처음에 물약 3개 들고 시작
        for (int i = 0; i < 3; i++)
        {
            AddItem(energyDrink);
        }

        for (int i = 0; i < 3; i++)
        {
            AddItem(gaugeProtein);
        }
    }

    public void UpdateUI()
    {
        for (int i = 0; i < ItemList.childCount; i++)
        {
            Items[i].gameObject.SetActive(true);

            if (Items[i].itemData != null && Items[i].itemCount > 0)
            {
                Items[i].icon.sprite = Items[i].itemData.icon;
                Items[i].icon.gameObject.SetActive(true);
                Items[i].ApplyCountUI();
            }
            else
            {
                Items[i].countText.gameObject.SetActive(false);
                Items[i].icon.gameObject.SetActive(false);
            }
        }

        // 선택된 아이템 이미지와 정보 업데이트
        if (selectedItemIndex >= 0 && selectedItemIndex < Items.Length)
        {
            var selectedItemButton = Items[selectedItemIndex];
            if (selectedItemButton.itemData != null)
            {
                selectedItemImage.sprite = selectedItemButton.itemData.icon;
                selectedItemImage.gameObject.SetActive(true); // 아이템을 선택하면 이미지 활성화
            }
        }
    }

    private void ClearSelectedText()
    {
        selectedItemImage.sprite = null;
        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        UseButton.SetActive(false);
        EquipButton.SetActive(false);
        UnequipButton.SetActive(false);
    }

    public void SelectedItem(int idx)
    {
        selectedItemIndex = idx;
        selectedItem = Items[selectedItemIndex].itemData;

        if (selectedItem != null)
        {
            selectedItemImage.sprite = selectedItem.icon;
            selectedItemImage.gameObject.SetActive(true);
            selectedItemName.text = selectedItem.itemName;
            selectedItemDescription.text = selectedItem.description;

            switch (selectedItem.itemType)
            {
                case ItemType.Recover:
                    UseButton.SetActive(true);
                    EquipButton.SetActive(false);
                    UnequipButton.SetActive(false);
                    break;
                case ItemType.Weapon:
                    UseButton.SetActive(false);
                    EquipButton.SetActive(true);
                    UnequipButton.SetActive(true);
                    break;
            }
            RemoveButton.SetActive(true);
        }
    }

    public void UseItem()
    {
        if (selectedItem == null)
        {
            return;
        }

        if (selectedItem is RecoverItem recoverItem)
        {
            // RecoverItem으로 캐스팅 성공
            CharacterManager.instance.playerStatHandler.hpSystem.TakeDamage(-recoverItem.HealthAmount);
            CharacterManager.instance.playerStatHandler.mpSystem.UseMana(-recoverItem.ManaAmount);
            RemoveItem();
        }
        selectedItemImage.gameObject.SetActive(false);
    }

    public void AddItem(ItemSO _item)
    {
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i].itemData == null)
            {
                Items[i].itemData = _item;
                Items[i].itemCount = 1;
                Items[i].ApplyCountUI();
                UpdateUI();
                return;
            }
            else if (Items[i].itemData.itemName == _item.itemName && Items[i].itemCount < _item.maxStack)
            {
                Items[i].itemCount++;
                Items[i].ApplyCountUI();
                UpdateUI();
                return;
            }
        }
    }

    public void RemoveItem()
    {
        if (Items[selectedItemIndex].itemCount > 1)
        {
            Items[selectedItemIndex].itemCount--;
            Items[selectedItemIndex].ApplyCountUI();
        }
        else
        {
            Items[selectedItemIndex].itemData = null;
            Items[selectedItemIndex].itemCount = 0;
            Items[selectedItemIndex].ApplyCountUI();
            Items[selectedItemIndex].gameObject.SetActive(false);
        }
        ClearSelectedText();
        UpdateUI();
        selectedItemImage.gameObject.SetActive(false);
    }
}
