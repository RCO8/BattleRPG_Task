using UnityEngine;
using System;

public class BasePlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public Animator animator;
    public PlayerStateMachine stateMachine;
    public PlayerAnimationData animationData;
    public SPUM_SpriteList spum_SpriteList;
    public RectTransform rectTransform;

    public event Action OnChangeStat;       //스탯바뀔 때, UI변경용 델리게이트
    public event Action OnChangeEquip;      //장비가 바귈 때, 변경용 델리게이트

    protected virtual void Awake()
    {
        stateMachine = new PlayerStateMachine(this);
        animationData = new PlayerAnimationData();
        animationData.Initialize();
    }

    protected virtual void Start()
    {
        //이미 캐릭터가 존재하면 이 오브젝트를 파괴한다.
        if (CharacterManager.instance.basePlayer != null)
        {
            Debug.Log(CharacterManager.instance.basePlayer.gameObject);
            Destroy(CharacterManager.instance.basePlayer.gameObject);

        }
        else
        {
            Debug.Log("dont Destroy");
            //CharacterManager.instance.basePlayer = this;
            //CharacterManager.instance.spum_SpriteList = spum_SpriteList;    //temp
            //spum_SpriteList = CharacterManager.instance.spum_SpriteList;
        }
        CharacterManager.instance.basePlayer = this;
        CharacterManager.instance.spum_SpriteList = spum_SpriteList;    //temp
        spum_SpriteList = CharacterManager.instance.spum_SpriteList;
    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }

    public void UpdateStat()
    {
        OnChangeStat?.Invoke();
    }

    public void UpdateEquip()
    {
        OnChangeEquip?.Invoke();
    }
}
