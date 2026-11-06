using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public enum MonsterState
    {
        None,
        Chase,
        Attack,
        Die
    }

    [Header("몬스터 상태")]
    [SerializeField] private MonsterState currentState;

    public MonsterState CurrentState => currentState;

    [Header("추적 설정")]
    public Transform player;
    public float moveSpeed = 3.0f;
    public float rotationSpeed = 5.0f;

    [Header("공격 설정")]
    public float attackDistance = 2.0f;
    public float resumeDistance = 2.5f;

    [Header("컴포넌트")]
    public Animator ani;

    public BoxCollider bx;

    private void Start()
    {
        // 게임 시작 시 추적 상태로 변경
        ChangeState(MonsterState.Chase);
        bx.enabled = false; 
    }

    private void Update()
    {
        // 사망 상태라면 다른 행동을 하지 않음
        if (currentState == MonsterState.Die) return;

        if (player == null) return;

        // 플레이어 방향 계산
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;

        float distance = direction.magnitude;

        // 상태에 따른 행동 전환
        switch (currentState)
        {
            case MonsterState.Chase:

                if (distance <= attackDistance)
                {
                    ChangeState(MonsterState.Attack);
                }

                break;

            case MonsterState.Attack:

                if (distance > resumeDistance)
                {
                    ChangeState(MonsterState.Chase);
                }

                break;
        }

        // 방향이 존재할 때 플레이어를 바라보도록 회전
        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(direction.normalized);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        // 추적 상태일 때만 이동
        if (currentState == MonsterState.Chase)
        {
            transform.position +=
                direction.normalized * moveSpeed * Time.deltaTime;
        }
    }

    // 상태 변경 및 애니메이션 재생
    private void ChangeState(MonsterState newState)
    {
        if (currentState == newState) return;

        currentState = newState;

        switch (currentState)
        {
            case MonsterState.Chase:

                ani.CrossFade("RunFWD", 0.15f);
                bx.enabled = false;
                break;

            case MonsterState.Attack:

                ani.CrossFade("Attack01", 0.15f);
                bx.enabled = true;
                break;

            case MonsterState.Die:

                ani.CrossFade("Die", 0.15f);
                break;
        }
    }

    // 사망 처리
    public void Die()
    {
        if (currentState == MonsterState.Die) return;

        ChangeState(MonsterState.Die);
    }
}
