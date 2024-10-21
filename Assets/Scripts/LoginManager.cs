using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public string correctUsername = "1234";  // 원하는 아이디
    public string correctPassword = "12345";  // 원하는 비밀번호
    public string nextSceneName = "ChapterScene";     // 넘어갈 씬 이름

    public void OnLogin()
    {
        // 입력된 아이디와 비밀번호가 올바른지 확인
        if (usernameInput.text == correctUsername && passwordInput.text == correctPassword)
        {
            // 씬 전환
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("로그인 실패: 아이디 또는 비밀번호가 틀렸습니다.");
        }
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            // 씬 전환
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
