using UnityEngine;
using System.Collections;

public class CylinderTrap : MonoBehaviour
{
    // 위로 올라가는 높이
    public float moveHeight = 3f;

    // 올라가는 속도
    public float moveSpeed = 12f;

    // 몇 초마다 반복할지
    public float interval = 3f;

    private Vector3 startPos;
    private Vector3 upPos;

    void Start()
    {
        startPos = transform.position;
        upPos = startPos + Vector3.up * moveHeight;

        StartCoroutine(TrapRoutine());
    }

    IEnumerator TrapRoutine()
    {
        while (true)
        {
            // 3초 대기
            yield return new WaitForSeconds(interval);

            // 빠르게 올라감
            while (Vector3.Distance(transform.position, upPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    upPos,
                    moveSpeed * Time.deltaTime);

                yield return null;
            }

            // 위에서 잠깐 멈춤
            yield return new WaitForSeconds(0.2f);

            // 다시 내려감
            while (Vector3.Distance(transform.position, startPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    startPos,
                    moveSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}