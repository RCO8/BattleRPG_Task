using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance { get; set; }


    //���� �����ϰ� �ִ� �÷��̾�
    public BasePlayer basePlayer { get; set; }
    //��Ʋ�ϰ� �ִ� ��
    public Enemy enemy { get; set; }
    //�÷��̾� ����
    public PlayerStatHandler playerStatHandler { get; set; }
    //�÷��̾� ��� ��������Ʈ
    public SPUM_SpriteList spum_SpriteList {  get; set; }
    //��Ʋ �÷��̾�
    public GameObject battlePlayer;
    //�ʵ� �÷��̾�
    public GameObject fieldPlayer;
    //�ʵ忡 �ִ� NPC��
    public Dictionary<int, NPC> npcDic = new Dictionary<int, NPC>();
    //�÷��̾ ó�� ������ ������
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
        //spum_SpriteList �ʱ�ȭ ( ���� �ý��� ����� ���� )
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
