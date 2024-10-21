using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FlagUICtrl : MonoBehaviour
{
    public string SceneName;
    public void OnUpdateFlag(int flag)
    {
        DataManager.Instance.Flag = flag;

        SceneManager.LoadScene(SceneName);
    }
}
