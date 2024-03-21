using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
