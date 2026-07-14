using UnityEngine;
using UnityEngine.SceneManagement; // 씬 재시작을 위해 필요

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // 빨간 장애물에 부딪히거나 바닥으로 떨어졌을 때 게임 오버 처리
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RestartGame();
        }
    }

    void Update()
    {
        // 길 밖으로 떨어졌을 때 (Y값이 일정 수준 이하로 내려가면 죽음)
        if (transform.position.y < -5f)
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        // 현재 활성화된 씬을 처음부터 다시 로드 (처음으로 돌아감)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}