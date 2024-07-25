using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_Field : MonoBehaviour
{
    private Player_Field _player;
    private Vector2 movementDirection = Vector2.zero;

    private void Awake()
    {
        _player = GetComponent<Player_Field>();
    }

    private void Start()
    {
        _player.controller.OnFieldMoveEvent += FieldMove;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 _direction)
    {
        if (_direction.x > 0.0f) gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1.0f);
        else if (_direction.x < 0.0f) gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);

        _player.rb.velocity = _direction;

        if (_direction == Vector2.zero) _player.stateMachine.ChangeState(_player.stateMachine.idleState);
        else _player.stateMachine.ChangeState(_player.stateMachine.runState);
    }

    private void FieldMove(Vector2 _direction)
    {
        movementDirection = _direction * 10;
    }
}
