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
    public string correctUsername = "1234";  // ���ϴ� ���̵�
    public string correctPassword = "12345";  // ���ϴ� ��й�ȣ
    public string nextSceneName = "ChapterScene";     // �Ѿ �� �̸�

    public void OnLogin()
    {
        // �Էµ� ���̵�� ��й�ȣ�� �ùٸ��� Ȯ��
        if (usernameInput.text == correctUsername && passwordInput.text == correctPassword)
        {
            // �� ��ȯ
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("�α��� ����: ���̵� �Ǵ� ��й�ȣ�� Ʋ�Ƚ��ϴ�.");
        }
    }
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            // �� ��ȯ
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
