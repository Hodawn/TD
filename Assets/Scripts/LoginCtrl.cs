using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginCtrl : MonoBehaviour
{
    public string SceneName;
    public void OnUpdateButtonIndex(int login)
    {
        DataManager.Instance.Login = login;

        SceneManager.LoadScene(SceneName);
    }
}
