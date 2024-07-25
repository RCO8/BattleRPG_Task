using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public interface INPCInteraction
{
    public void NPCInteraction() { }
    public void LookPlayer(GameObject _gameObject) { }
    public void GoToPlayer(GameObject _gameObject) { }
}

public class NPC : MonoBehaviour, INPCInteraction
{
    public BoxCollider2D npcDetectCollider;
    public NPCSO npcSO;


    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        if(!CharacterManager.instance.npcDic.ContainsKey(npcSO.id)) CharacterManager.instance.npcDic.Add(npcSO.id, this);
    }

    public virtual void NPCInteraction()
    {
        //NPC일 때, 상호작용하면 구현될 코드 작성
    }

    public void LookPlayer(GameObject _gameObject)
    {
        Vector2 nowScale = gameObject.transform.localScale;
        if (_gameObject.transform.position.x > gameObject.transform.position.x)
        {
            nowScale.x = Mathf.Abs(nowScale.x) * -1f;
        }
        else
        {
            nowScale.x = Mathf.Abs(nowScale.x) * 1f;
        }
        gameObject.transform.localScale = nowScale;
    }

    public void GoToPlayer(GameObject _gameObject)
    {
        //길찾기 알고리즘으로 구현 ( 일단 임시로 쳐다보는 코드만 구현 )
        Vector2 nowScale = gameObject.transform.localScale;
        if (_gameObject.transform.position.x > gameObject.transform.position.x)
        {
            nowScale.x = Mathf.Abs(nowScale.x) * -1f;
        }
        else
        {
            nowScale.x = Mathf.Abs(nowScale.x) * 1f;
        }
        gameObject.transform.localScale = nowScale;
    }
}
