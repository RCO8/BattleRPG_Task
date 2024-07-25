using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class NPCData
{
    //임시로 만듬 (딕셔너리를 활용하는게 최적화면에서 더 좋음)
    //public int iD;
    public GameObject prefab;
    public bool isClear = false;
}

public class NPCDataManager : MonoBehaviour
{
    public static NPCDataManager instance { get; set; }

    [SerializedDictionary("ID", "Data")]
    public SerializedDictionary<int, NPCData> npcDataDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    //private void Start()
    //{
    //    //게임 로드하면 딕셔너리 저장 데이터에 맞게 초기화하는 작업
    //}
}
