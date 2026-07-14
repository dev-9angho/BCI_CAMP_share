using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("이동 속도")]
    public float forwardSpeed = 10f; // 앞으로 달리는 속도
    public float sideSpeed = 12f;    // 좌우 이동 속도
    public float jumpForce = 7f;     // 점프력

    [Header("지면 체크")]
    public float groundCheckDistance = 0.6f;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // 공이 너무 가볍게 굴러가지 않도록 마찰/무게감 조절 (원하는 대로 인스펙터에서 수정 가능)
        rb.mass = 1f;
        rb.linearDamping = 0.5f;
    }

    void Update()
    {
        // 1. 지면 체크 (공의 중심에서 아래로 레이를 쏘아 바닥에 닿아있는지 확인)
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        // 2. 점프 (스페이스바 + 바닥에 닿아있을 때만)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // 위쪽 방향으로 순간적인 힘(Impulse)을 가함
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // 물리 이동은 FixedUpdate에서 처리하는 것이 안전합니다.

        // 1. 앞으로 자동 전진 (혹은 W키로 가고 싶다면 Input.GetAxis 사용해도 됨. 여기선 자동 전진으로 구현)
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.fixedDeltaTime;

        // 2. 좌우 이동 입력 (A/D 키 또는 왼쪽/오른쪽 방향키)
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 sideMove = Vector3.right * horizontalInput * sideSpeed * Time.fixedDeltaTime;

        // 힘을 직접 더해 공을 굴립니다.
        rb.MovePosition(rb.position + forwardMove + sideMove);
    }
}