using UnityEngine;
using TMPro; // TextMeshPro를 쓰기 위해 필수!
using UnityEngine.SceneManagement;
using System.Collections; // 💡 [추가] 코루틴(IEnumerator)을 사용하기 위해 필수적입니다!

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText; // 화면의 Text UI와 연결할 변수

    private float elapsedTime = 0f;   // 흘러간 시간
    private bool isGameFinished = false; // 게임이 끝났는지 체크

    // 💡 다른 씬(FinishScene)에서 최종 기록을 가져다 쓸 수 있도록 static 변수로 유지합니다.
    public static float FinalTime { get; private set; }

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

        // 최종 시간 기록 저장
        FinalTime = elapsedTime;

        // 화면에 최종 기록을 보여줍니다.
        timerText.text = "CLEAR! \nYour Time: " + elapsedTime.ToString("F2") + "s\nPress 'R' to Restart";
        timerText.color = Color.yellow; // 글자색을 깔끔하게 노란색으로 변경
        timerText.fontSize = 45; // 글자 크기 키우기

        // 💡 [추가] 5초 후에 자동으로 FinishScene으로 전환하는 코루틴을 시작합니다.
        StartCoroutine(LoadFinishSceneAfterDelay(5f));
    }

    // 💡 [추가] 지정된 시간(초)만큼 대기한 후 FinishScene을 로드하는 코루틴 함수
    private IEnumerator LoadFinishSceneAfterDelay(float delay)
    {
        // 입력받은 시간(5초)만큼 흐름을 일시 정지(대기)합니다.
        yield return new WaitForSeconds(delay);

        // 5초 대기하는 동안 플레이어가 'R' 키를 눌러 씬이 재시작되지 않았다면,
        // 정상적으로 FinishScene으로 화면을 전환합니다.
        SceneManager.LoadScene("Finish");
    }
}