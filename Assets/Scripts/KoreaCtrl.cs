using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KoreaCtrl : MonoBehaviour
{
    public string SceneName;
    public void OnUpdateButtonIndex(int korea)
    {
        DataManager.Instance.Korea = korea;

        SceneManager.LoadScene(SceneName);
    }
}
