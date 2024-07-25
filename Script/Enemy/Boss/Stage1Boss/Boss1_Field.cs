using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss1_Field : NPC
{
    public Animator animator;
    public RectTransform rectTransform;
    public Boss1AnimationData boss1AnimationData;
    public SpriteRenderer exclamationMarkSprite;

    //private Player_Field _player;

    protected override void Awake()
    {
        base.Awake();

        boss1AnimationData = new Boss1AnimationData();
        boss1AnimationData.Initialize();
    }

    protected override void Start()
    {
        base.Start();

        //_player = CharacterManager.instance.basePlayer as Player_Field;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //적의 감지범위에 들어온 오브젝트가 Player
    //    if (collision.gameObject.tag == Define.TAG_PLAYER)
    //    {
    //        if (!NPCDataManager.instance.npcDataDictionary[npcSO.id].isClear)
    //        {
    //            exclamationMarkSprite.gameObject.SetActive(true);
    //            NPCInteraction();
    //        }
    //    }
    //}

    public override void NPCInteraction()
    {
        exclamationMarkSprite.gameObject.SetActive(true);               //느낌표를 띄운다.
        LookPlayer(CharacterManager.instance.basePlayer.gameObject);    //플레이어를 쳐다본다.

        //배틀 씬으로 진입
        SceneDataManager.instance.EnterToBattleScene(npcSO.id);
    }
}
