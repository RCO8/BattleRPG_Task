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

    // 사운드 UI 슬라이더들
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    // 오디오 소스들
    public AudioSource bgmAudioSource;
    public AudioSource[] sfxAudioSources;

    // 초기 볼륨 값들
    private float masterVolume = 0.5f;
    private float bgmVolume = 0.5f;
    private float sfxVolume = 0.5f;


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

        // UI 비활성화
        userInfoUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillUI.SetActive(false);
        questUI.SetActive(false);
        saveUI.SetActive(false);
        optionUI.SetActive(false);

        // 슬라이더 초기 값 설정
        masterVolumeSlider.value = masterVolume;
        bgmVolumeSlider.value = bgmVolume;
        sfxVolumeSlider.value = sfxVolume;

        // 슬라이더 이벤트 핸들러 설정
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        bgmVolumeSlider.onValueChanged.AddListener(SetBGMVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);

        // 배경음악 설정 및 재생
        if (bgmAudioSource != null)
        {
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }


        ApplyVolumes();
    }

    // UserInfoUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowUserInfoUI()
    {
        CloseAllUI(); // 모든 UI를 먼저 닫습니다.
        userInfoUI.SetActive(true);
    }

    // InventoryUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowInventoryUI()
    {
        CloseAllUI();
        inventoryUI.SetActive(true);
    }

    // SkillUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowSkillUI()
    {
        CloseAllUI();
        skillUI.SetActive(true);
    }

    // QuestUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowQuestUI()
    {
        CloseAllUI();
        questUI.SetActive(true);
    }

    // SaveUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowSaveUI()
    {
        CloseAllUI();
        saveUI.SetActive(true);
    }

    // OptionUI를 활성화하고 다른 UI를 비활성화하는 함수
    public void ShowOptionUI()
    {
        CloseAllUI();
        optionUI.SetActive(true);
    }

    // 모든 UI를 비활성화하는 함수
    public void CloseAllUI()
    {
        userInfoUI.SetActive(false);
        inventoryUI.SetActive(false);
        skillUI.SetActive(false);
        questUI.SetActive(false);
        saveUI.SetActive(false);
        optionUI.SetActive(false);
    }

    // 마스터 볼륨 설정
    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        ApplyVolumes();
    }

    // 배경음악 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        ApplyVolumes();
    }

    // 효과음 볼륨 설정
    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        ApplyVolumes();
    }

    // 볼륨 적용 함수
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
