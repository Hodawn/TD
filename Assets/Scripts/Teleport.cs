using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public Transform teleportLocation;       // �̵��� ��ġ ����
    public CanvasGroup fadeCanvasGroup;      // ���̵� ��/�ƿ��� ���� CanvasGroup
    public Canvas canvasToShow;              // �̵� �� ǥ���� ĵ����
    public float fadeDuration = 1.0f;        // ���̵� ��/�ƿ� ���� �ð�
    public float displayDuration = 5.0f;     // ĵ���� ǥ�� ���� �ð�

    private bool isTeleporting = false;

    void Start()
    {
        // ���̵� ĵ���� ���� �� ������ �ʵ��� ����
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

        // 1. ù ��° ���̵� ��
        yield return StartCoroutine(Fade(1));

        // 2. �÷��̾� ��ġ �̵�
        transform.position = teleportLocation.position;
        transform.rotation = teleportLocation.rotation;

        // 3. ĵ���� Ȱ��ȭ
        canvasToShow.gameObject.SetActive(true);

        // 4. ĵ���� ǥ�� �ð� ���� ���
        yield return new WaitForSeconds(displayDuration);

        // 5. ĵ���� ��Ȱ��ȭ
        canvasToShow.gameObject.SetActive(false);

        // 6. �� ��° ���̵� �ƿ� (ĵ���� ��Ȱ��ȭ �� ����)
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
