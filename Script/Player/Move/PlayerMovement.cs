//using System.Collections;
//using Unity.VisualScripting;
//using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

//public class PlayerMovement : MonoBehaviour
//{
//    private Player _player;
//    private Vector2 movementDirection = Vector2.zero;

//    [SerializeField] LayerMask groundLayerMask;

//    //public bool isAttacking = false;

//    private void Awake()
//    {
//        _player = GetComponent<Player>();
//    }

//    private void Start()
//    {
//        _player.controller.OnBattleMoveEvent += BattleMove;
//        _player.controller.OnBattleJumpEvent += BattleMJump;

//        _player.controller.OnFieldMoveEvent += FieldMove;
//    }

//    private void FixedUpdate()
//    {
//        ApplyMovement(movementDirection);
//    }

//    private void ApplyMovement(Vector2 _direction)
//    {
//        if (_player.attack.isAttacking) _direction = Vector2.zero;

//        if (_direction.x > 0.0f) gameObject.transform.localScale = new Vector3(-1.5f, 1.5f, 1.0f);
//        else if (_direction.x < 0.0f) gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.0f);

//        if (_player.controller.isField) _player.rb.velocity = _direction;
//        else _player.rb.velocity = new Vector2(_direction.x, _player.rb.velocity.y);

//        if (_direction == Vector2.zero) _player.stateMachine.ChangeState(_player.stateMachine.idleState);
//        else _player.stateMachine.ChangeState(_player.stateMachine.runState);
//    }

//    private void BattleMove(Vector2 _direction)
//    {
//        movementDirection = _direction * 10;
//    }

//    private void BattleMJump()
//    {
//        if(IsGrounded()) _player.rb.AddForce(Vector2.up * 30.0f, ForceMode2D.Impulse);
//    }

//    private void FieldMove(Vector2 _direction)
//    {
//        movementDirection = _direction * 10;
//    }

//    private bool IsGrounded()
//    {
//        Ray[] rays = new Ray[3]
//        {
//            new Ray(transform.position + (transform.right * 0.4f), Vector2.down),
//            new Ray(transform.position, Vector2.down),
//            new Ray(transform.position + (-transform.right * 0.4f), Vector2.down)
//        };

//        //for (int i = 0; i < rays.Length; i++)
//        //{
//        //    if (Physics2D.Raycast(rays[i].origin, rays[i].direction, 0.1f, groundLayerMask))
//        //        Debug.DrawRay(rays[i].origin, rays[i].direction, Color.green, 3.0f);
//        //    else Debug.DrawRay(rays[i].origin, rays[i].direction, Color.red, 3.0f);
//        //}

//        for (int i = 0; i < rays.Length; i++)
//        {
//            if(Physics2D.Raycast(rays[i].origin, rays[i].direction, 0.1f, groundLayerMask)) return true;
//        }

//        return false;
//    }
//}
