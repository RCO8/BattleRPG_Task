using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Player_Field : BasePlayer
{
    public PlayerController_Field controller;
    public PlayerMovement_Field playerMovement;

    public bool isTrigger { get; private set; }
    public GameObject npc { get; private set; }


    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Define.TAG_ENEMY))//적이 아닌 npc도 구분하게 수정 예정
        {
            isTrigger = true;
            npc = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(Define.TAG_ENEMY))//적이 아닌 npc도 구분하게 수정 예정
        {
            isTrigger = false;
            npc = null;
        }
    }

    //아이템 정보도 매개변수에 넣어줘야함
    public void ChangeEquip(int _equipNum)
    {
        //spum_SpriteList._itemList[_equipNum] = 

        //검일 시에는 
    }
}
