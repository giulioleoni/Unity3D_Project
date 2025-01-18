using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transporter : Singleton<Transporter>
{
    public float playerPoints = 0;
    void Start()
    {
        GameObject[] transporters = GameObject.FindGameObjectsWithTag("Manager");
        if (transporters.Length > 1)
        {
            Debug.Log("distruzione, troppi transporter");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadNextScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
