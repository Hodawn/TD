using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform teleportLocation;       // 이동할 위치 설정
    public CanvasGroup fadeCanvasGroup;      // 페이드 인/아웃을 위한 CanvasGroup
    public Canvas canvasToShow;              // 이동 후 표시할 캔버스
    public float fadeDuration = 1.0f;        // 페이드 인/아웃 지속 시간
    public float displayDuration = 5.0f;     // 캔버스 표시 지속 시간

    private bool isTeleporting = false;

    void Start()
    {
        // 페이드 캔버스 시작 시 보이지 않도록 설정
        fadeCanvasGroup.alpha = 0;
        fadeCanvasGroup.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isTeleporting)
        {
            StartCoroutine(TeleportRoutine());
        }
    }

    private IEnumerator TeleportRoutine()
    {
        isTeleporting = true;

        // 1. 첫 번째 페이드 인
        yield return StartCoroutine(Fade(1));

        // 2. 플레이어 위치 이동
        transform.position = teleportLocation.position;
        transform.rotation = teleportLocation.rotation;

        // 3. 캔버스 활성화
        canvasToShow.gameObject.SetActive(true);

        // 4. 캔버스 표시 시간 동안 대기
        yield return new WaitForSeconds(displayDuration);

        // 5. 캔버스 비활성화
        canvasToShow.gameObject.SetActive(false);

        // 6. 두 번째 페이드 아웃 (캔버스 비활성화 후 시작)
        yield return StartCoroutine(Fade(0));

        isTeleporting = false;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadeCanvasGroup.alpha;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            yield return null;
        }
        fadeCanvasGroup.alpha = targetAlpha;
    }
}
