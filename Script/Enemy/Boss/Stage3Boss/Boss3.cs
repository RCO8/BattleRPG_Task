using UnityEngine;


interface IFlyingEnemy
{
    public void Fly();
}

public class Boss3 : Enemy
{
    public Boss3StateMachine boss3StateMachine;
    //폭탄 오브젝트 풀
    public ObjectPool Bombs;

    public Transform targetPlayer { get; private set; } //플레이어 목표 지점

    public float CurrentGravity { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Bombs = GetComponent<ObjectPool>(); //임시로 폭탄이 떨어지는 걸 보려고

        //targetPlayer = CharacterManager.instance.player.transform;

        boss3StateMachine = new Boss3StateMachine(this);

        CurrentGravity = rb.gravityScale;
    }

    private void Start()
    {
        boss3StateMachine.ChangeState(boss3StateMachine.readyState);
    }

    private void FixedUpdate()
    {
        boss3StateMachine.PhysicsUpdate();

        targetPlayer = CharacterManager.instance.basePlayer.transform;  //이걸 어떻게 하면 좋을까?
    }

    private void Update()
    {
        boss3StateMachine.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (boss3StateMachine.currentState.Equals(boss3StateMachine.fallState))
            {
                boss3StateMachine.ChangeState(boss3StateMachine.readyState);
            }
        }
    }
}