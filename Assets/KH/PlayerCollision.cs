using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rb;
    private bool isFinished = false;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isFinished) return;

        Debug.Log("부딪힌 물체 이름: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartGame();
            return; 
        }

        if (collision.gameObject.name == "FinishLine")
        {
            isFinished = true;

            // 1. 공의 물리 정지 및 고정
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true; 
            }

            // 2. ★★★ 플레이어 이동 스크립트 꺼버리기 ★★★
            // 본인의 이동 스크립트 클래스 이름(예: PlayerMovement)으로 변경해 주세요.
            PlayerMovement movement = GetComponent<PlayerMovement>();
            if (movement != null)
            {
                movement.enabled = false; // 스크립트를 비활성화하여 키 입력과 이동을 완전히 차단합니다.
            }

            if (gameManager != null)
            {
                gameManager.FinishGame();
            }
        }
    }

    void Update()
    {
        if (isFinished) return;

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