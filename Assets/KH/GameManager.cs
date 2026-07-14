using UnityEngine;
using TMPro; // TextMeshPro를 쓰기 위해 필수!
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 화면의 Text UI와 연결할 변수

    private float elapsedTime = 0f;   // 흘러간 시간
    private bool isGameFinished = false; // 게임이 끝났는지 체크

    void Update()
    {
        // 게임이 끝나지 않았다면 매 프레임 시간을 더해줍니다.
        if (!isGameFinished)
        {
            elapsedTime += Time.deltaTime;

            // 소수점 둘째 자리까지만 화면에 표시 (예: Time: 12.34)
            timerText.text = "Time: " + elapsedTime.ToString("F2") + "s";
        }
        else
        {
            // 게임이 끝났을 때 R키를 누르면 재시작하는 기능
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // 피니쉬 라인에 닿았을 때 호출될 함수
    public void FinishGame()
    {
        if (isGameFinished) return; // 이미 끝났다면 무시

        isGameFinished = true;

        // 화면에 최종 기록을 보여줍니다.
        timerText.text = "CLEAR! \nYour Time: " + elapsedTime.ToString("F2") + "s\nPress 'R' to Restart";
        timerText.color = Color.yellow; // 글자색을 깔끔하게 노란색으로 변경
        timerText.fontSize = 45; // 글자 크기 키우기
    }
}