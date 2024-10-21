using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 싱글톤 패턴을 사용하여 GameManager 인스턴스 생성
    public static GameManager Instance;

    private void Awake()
    {
        // GameManager 인스턴스가 이미 존재하면 새로 생성된 GameManager를 파괴
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 파괴되지 않게 설정
        }
        else
        {
            Destroy(gameObject); // 기존 인스턴스가 있으면 새로 생성된 객체 파괴
        }
    }

    // 씬을 로드하는 메서드
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 씬을 로드하는 코루틴 (비동기 로딩)
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            // 로딩 진행도를 UI로 표시할 수 있음
            Debug.Log("Loading progress: " + (asyncOperation.progress * 100) + "%");
            yield return null;
        }
    }

    // 현재 씬을 다시 로드하는 메서드
    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
