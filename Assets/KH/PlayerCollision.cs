using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        // 씬에 있는 GameManager를 자동으로 찾아서 연결합니다.
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // 오브젝트와 물리적으로 '부딪혔을 때' 호출되는 함수 (Is Trigger 꺼진 상태)
    void OnCollisionEnter(Collision collision)
    {
        // 아무 물체에나 부딪히면 무조건 콘솔창에 부딪힌 물체의 이름을 출력합니다.
        Debug.Log("부딪힌 물체 이름: " + collision.gameObject.name);

        // ... 이하 생략
        // 1. 일반 장애물에 부딪혔을 때 -> 게임 재시작
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartGame();
            return; // 아래 피니쉬 체크를 하지 않고 나감
        }

        // 2. 피니쉬 라인(오브젝트 이름이 FinishLine인 벽)에 부딪혔을 때 -> 클리어!
        if (collision.gameObject.name == "FinishLine")
        {
            // 공의 물리 움직임을 즉시 멈춰 세웁니다.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; // 벽에 붙어서 더 이상 움직이지 않게 고정
            }

            // 게임 매니저에게 골인했다고 알려줍니다.
            gameManager.FinishGame();
        }
    }

    void Update()
    {
        // 낙사 처리
        if (transform.position.y < -5f)
        {
            RestartGame();
        }
    }


    void RestartGame()
    {
        SceneManager.LoadScene("Finish");
    }
}