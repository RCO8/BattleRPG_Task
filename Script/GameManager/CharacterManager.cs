using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance { get; set; }


    //지금 조종하고 있는 플레이어
    public BasePlayer basePlayer { get; set; }
    //배틀하고 있는 적
    public Enemy enemy { get; set; }
    //플레이어 스탯
    public PlayerStatHandler playerStatHandler { get; set; }
    //플레이어 장비 스프라이트
    public SPUM_SpriteList spum_SpriteList {  get; set; }
    //배틀 플레이어
    public GameObject battlePlayer;
    //필드 플레이어
    public GameObject fieldPlayer;
    //필드에 있는 NPC들
    public Dictionary<int, NPC> npcDic = new Dictionary<int, NPC>();
    //플레이어가 처음 시작할 포지션
    public Vector2 startPlayerPosition;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        playerStatHandler = FindObjectOfType<PlayerStatHandler>();
        //spum_SpriteList 초기화 ( 저장 시스템 생기면 수정 )
        //spum_SpriteList = battlePlayer.GetComponent<Player_Field>().spum_SpriteList;
    }

    private void LateUpdate()
    {
        if (basePlayer is Player_Field)
        {
            var pos = basePlayer.transform.position;
            Camera.main.transform.position = new Vector3(pos.x, pos.y, Camera.main.transform.position.z);
        }
    }
}
