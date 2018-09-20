using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

     public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnRankListButton()
    {
        SceneManager.LoadScene(2);
    }

    public void OnLevelButton()
    {
        SceneManager.LoadScene(3);
    }

    public void OnExitButton()
    {
#if UNITY_EDITOR
     UnityEditor.EditorApplication.isPlaying=false;
#else
     Application.Quit();
#endif
 
    }
}
