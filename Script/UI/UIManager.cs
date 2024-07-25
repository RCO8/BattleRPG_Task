using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject userInfoUI;
    public GameObject inventoryUI;
    public GameObject skillUI;
    public GameObject questUI;
    public GameObject saveUI;
    public GameObject optionUI;

    // ���� UI �����̴���
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    // ����� �ҽ���
    public AudioSource bgmAudioSource;
    public AudioSource[] sfxAudioSources;

    // �ʱ� ���� ����
    private float masterVolume = 0.5f;
    private float bgmVolume = 0.5f;
    private float sfxVolume = 0.5f;


    void Start()
    {
        // �̱��� �ν��Ͻ� ���� �� �ı� ����
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

        // UI ��Ȱ��ȭ
        userInfoUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillUI.SetActive(false);
        questUI.SetActive(false);
        saveUI.SetActive(false);
        optionUI.SetActive(false);

        // �����̴� �ʱ� �� ����
        masterVolumeSlider.value = masterVolume;
        bgmVolumeSlider.value = bgmVolume;
        sfxVolumeSlider.value = sfxVolume;

        // �����̴� �̺�Ʈ �ڵ鷯 ����
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // ������� ���� �� ���
        if (bgmAudioSource != null)
        {
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }


        ApplyVolumes();
    }

    // UserInfoUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowUserInfoUI()
    {
        CloseAllUI(); // ��� UI�� ���� �ݽ��ϴ�.
        userInfoUI.SetActive(true);
    }

    // InventoryUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowInventoryUI()
    {
        CloseAllUI();
        inventoryUI.SetActive(true);
    }

    // SkillUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowSkillUI()
    {
        CloseAllUI();
        skillUI.SetActive(true);
    }

    // QuestUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowQuestUI()
    {
        CloseAllUI();
        questUI.SetActive(true);
    }

    // SaveUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowSaveUI()
    {
        CloseAllUI();
        saveUI.SetActive(true);
    }

    // OptionUI�� Ȱ��ȭ�ϰ� �ٸ� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void ShowOptionUI()
    {
        CloseAllUI();
        optionUI.SetActive(true);
    }

    // ��� UI�� ��Ȱ��ȭ�ϴ� �Լ�
    public void CloseAllUI()
    {
        userInfoUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillUI.SetActive(false);
        questUI.SetActive(false);
        saveUI.SetActive(false);
        optionUI.SetActive(false);
    }

    // ������ ���� ����
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        ApplyVolumes();
    }

    // ������� ���� ����
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        ApplyVolumes();
    }

    // ȿ���� ���� ����
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        ApplyVolumes();
    }

    // ���� ���� �Լ�
    private void ApplyVolumes()
    {
        AudioListener.volume = masterVolume;

        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = bgmVolume * masterVolume;
        }

        foreach (AudioSource sfxAudioSource in sfxAudioSources)
        {
            if (sfxAudioSource != null)
            {
                sfxAudioSource.volume = sfxVolume * masterVolume;
            }
        }
    }
}
