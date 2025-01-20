using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [HideInInspector] public float GameTime { get { return gameTime; } private set { gameTime = value; } }
    [Header("Insert GameTime in seconds")]
    [SerializeField] private float gameTime;
    [SerializeField] private TMP_Text timeText;

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;

        if (gameTime <= 0)
        {
            GameManager.Instance.LoadGameEndScene();
        }

        int minutes = (int)(gameTime / 60);
        int seconds = (int)(gameTime % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

}
