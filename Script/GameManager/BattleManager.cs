using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BattleManager : MonoBehaviour
{
    private Player_Battle _player;
    private Enemy _enemy;

    public void Start()
    {
        _enemy = CharacterManager.instance.enemy;   //����� ������ Ȯ��
        _player = CharacterManager.instance.basePlayer as Player_Battle;
    }
}
