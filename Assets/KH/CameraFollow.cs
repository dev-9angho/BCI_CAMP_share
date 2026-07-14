using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 쫓아갈 타겟 (공)

    // 공의 뒤(Z: -10), 위(Y: 6)에서 바라보는 기본값
    public Vector3 offset = new Vector3(0f, 6f, -10f);

    // 카메라 반응 속도 (낮을수록 타이트하게, 높을수록 부드럽게 따라감)
    public float smoothTime = 0.15f;

    private Vector3 currentVelocity = Vector3.zero;

    void Start()
    {
        // 카메라의 고정 각도 세팅 (30도 정도 아래를 내려다봄)
        transform.rotation = Quaternion.Euler(30f, 0f, 0f);
    }

    void LateUpdate()
    {
        if (target == null) return;

        // 카메라가 있어야 할 목표 위치 계산
        Vector3 desiredPosition = target.position + offset;

        // 부드럽게 위치 이동
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref currentVelocity,
            smoothTime
        );
    }
}