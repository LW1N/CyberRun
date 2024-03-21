using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("StartScreen");
    }
    public void LoadIntro()
    {
        SceneManager.LoadScene("BackgroundStoryScene");
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene("GameScene");
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
