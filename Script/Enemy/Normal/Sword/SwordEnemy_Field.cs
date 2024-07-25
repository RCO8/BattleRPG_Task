using UnityEngine;

public class SwordEnemy_Field : NPC
{
    public Animator animator;
    public RectTransform rectTransform;
    public NormalEnemyAnimation swordAnimation;
    public SpriteRenderer exclamationMarkSprite;

    private Player_Field _player;

    protected override void Awake()
    {
        base.Awake();

        swordAnimation = new NormalEnemyAnimation();
        swordAnimation.Initialize();
    }

    protected override void Start()
    {
        base.Start();

        _player = CharacterManager.instance.basePlayer as Player_Field;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적의 감지범위에 들어온 오브젝트가 Player
        if (collision.gameObject.CompareTag(Define.TAG_PLAYER))
        {
            if (!NPCDataManager.instance.npcDataDictionary[npcSO.id].isClear)
            {
                exclamationMarkSprite.gameObject.SetActive(true);
                NPCInteraction();
            }
            else
            {
                exclamationMarkSprite.gameObject.SetActive(false);
            }
        }
    }

    public override void NPCInteraction()
    {
        exclamationMarkSprite.gameObject.SetActive(true);   //느낌표를 띄운다.
        //LookPlayer(_player.gameObject);

        //씬 데이터 매니저에 정보들 저장
        SceneDataManager.instance.EnterToBattleScene(npcSO.id);

        //GoToPlayer(_player.gameObject);                     //플레이어에게 다가간다.

        //배틀 씬으로 이동
        //SceneManager.LoadScene(Define.SCENE_BATTLE);
    }
}
