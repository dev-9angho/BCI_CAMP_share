using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [Header("이동 설정")]
    // 왔다 갔다 할 최대 거리 (중앙 기준 한쪽으로 움직이는 거리)
    public float movementRange = 3f;
    // 이동 속도
    public float speed = 5f;

    private Vector3 startPosition; // 게임 시작 시 중앙 위치

    void Start()
    {
        // 처음 배치된 위치를 중앙 기준점으로 저장
        startPosition = transform.position;
    }

    void Update()
    {
        // 사인 파동(Sin Wave)을 이용해서 부드럽게 좌우로 움직이는 값을 계산
        // MathF.Sin은 시간이 지날수록 -1 ~ 1 사이를 왕복합니다.
        float sinValue = Mathf.Sin(Time.time * speed);

        // 이동할 거리 계산 (-movementRange ~ movementRange)
        float offset = sinValue * movementRange;

        // 중앙 시작 위치에서 계산된 offset만큼 좌우(X축)로 이동한 새로운 위치 계산
        Vector3 nextPosition = new Vector3(
            startPosition.x + offset,
            startPosition.y,
            startPosition.z
        );

        // 오브젝트의 위치를 부드럽게 이동
        transform.position = nextPosition;
    }
}