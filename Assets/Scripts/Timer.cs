using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : Singleton<Timer>
{
    public float gameTime;
    [SerializeField] private TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            SceneManager.LoadScene(2);
        }

        int minutes = (int)(gameTime / 60);
        int seconds = (int)(gameTime % 60);

        timeText.text = string.Format("{0:0} : {1:00}", minutes, seconds);
    }
}
