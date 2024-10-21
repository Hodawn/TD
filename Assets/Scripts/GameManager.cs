using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // �̱��� ������ ����Ͽ� GameManager �ν��Ͻ� ����
    public static GameManager Instance;

    private void Awake()
    {
        // GameManager �ν��Ͻ��� �̹� �����ϸ� ���� ������ GameManager�� �ı�
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ���� �ٲ� �ı����� �ʰ� ����
        }
        else
        {
            Destroy(gameObject); // ���� �ν��Ͻ��� ������ ���� ������ ��ü �ı�
        }
    }

    // ���� �ε��ϴ� �޼���
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ���� �ε��ϴ� �ڷ�ƾ (�񵿱� �ε�)
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            // �ε� ���൵�� UI�� ǥ���� �� ����
            Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%");
            yield return null;
        }
    }

    // ���� ���� �ٽ� �ε��ϴ� �޼���
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
