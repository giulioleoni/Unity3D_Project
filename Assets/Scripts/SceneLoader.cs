using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Singleton<SceneLoader>
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadNextScene(int nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
