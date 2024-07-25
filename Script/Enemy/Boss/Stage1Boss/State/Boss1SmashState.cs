using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss1SmashState : Boss1BaseState
{
    private Vector2 _position;
    private float _time = 0.0f;
    private Vector2 _obstaclePosition;

    public Boss1SmashState(Boss1StateMachine _stateMachine) : base(_stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        //위치 지정( 플레이어 머리 위로, 벽과 안닿게 조절해서 )
        _position = CharacterManager.instance.basePlayer.transform.position;
        _position.x = Mathf.Clamp(_position.x, Define.BATTLESCENE_LEFTWALL_X, Define.BATTLESCENE_RIGHTWALL_X);
        _position.y += 10.0f;

        if(stateMachine.boss1.isRageMode)
        {
            //떨어뜨릴 장애물 위치
            _obstaclePosition.x = Random.Range(Define.BATTLESCENE_LEFTWALL_X, Define.BATTLESCENE_RIGHTWALL_X);
            _obstaclePosition.y = _position.y;
        }

        StartAnimation(stateMachine.boss1.boss1AnimationData.StunParameterHash);
        stateMachine.boss1.damageCollider.gameObject.SetActive(true);
        MoveToPlayerPosition();
    }

    public override void Exit()
    {
        base.Exit();

        if(stateMachine.boss1.isRageMode)
        {
            stateMachine.boss1.MakeObstacle(_obstaclePosition);

            //다른 장애물 x좌표
            _obstaclePosition.x = Random.Range(Define.BATTLESCENE_LEFTWALL_X, Define.BATTLESCENE_RIGHTWALL_X);

            stateMachine.boss1.MakeObstacle(_obstaclePosition);
            Camera.main.GetComponent<CameraEffect>().ShakeCamera();
        }
        StopAnimation(stateMachine.boss1.boss1AnimationData.StunParameterHash);
        stateMachine.boss1.damageCollider.gameObject.SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        _time += Time.deltaTime;
        if (_time > (1.0f / stateMachine.boss1.stat.attackSpeed) )
        {
            _time = 0.0f;
            stateMachine.ChangeState(stateMachine.standByState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void MoveToPlayerPosition()
    {

        //보간법을 이용해 플레이어 머리 위로 이동하는 로직, 그 후 
        stateMachine.boss1.transform.DOMove(_position, 1.0f / stateMachine.boss1.stat.attackSpeed);
    }
}
