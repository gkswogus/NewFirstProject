using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("이동 설정")]
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float rotationSpeed = 10.0f;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference runAction;
    public InputActionReference attackAction;

    [Header("컴포넌트")]
    public Rigidbody rb;
    public Animator ani;
    public Transform cameraTransform;

    private Vector3 moveDirection;
    private float currentSpeed;
    private float animSpeed;

    private void OnEnable()
    {
        moveAction.action.Enable();
        runAction.action.Enable();
        attackAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        runAction.action.Disable();
        attackAction.action.Disable();
    }

    void Update()
    {
        if (cameraTransform == null) return;

        // 이동 입력 받기
        Vector2 inputVector = moveAction.action.ReadValue<Vector2>();

        float horizontal = inputVector.x;
        float vertical = inputVector.y;

        // 카메라의 수평 방향 계산
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 cameraRight = cameraTransform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        // 카메라 기준 이동 방향
        moveDirection =
            (cameraForward * vertical + cameraRight * horizontal).normalized;

        // 달리기 입력
        bool isRunning = runAction.action.IsPressed();

        currentSpeed = isRunning ? runSpeed : walkSpeed;

        // 애니메이션 속도 설정
        animSpeed = moveDirection.magnitude > 0.01f
            ? (isRunning ? 1f : 0.5f)
            : 0f;

        ani.SetFloat("Speed", animSpeed, 0.1f, Time.deltaTime);

        // 공격 입력
        if (attackAction.action.WasPressedThisFrame())
        {
            ani.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        // 이동
        Vector3 velocity = moveDirection * currentSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );

        // 이동 방향으로 플레이어 회전
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation =
                Quaternion.LookRotation(moveDirection);

            Quaternion newRotation = Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(newRotation);
        }
    }

}