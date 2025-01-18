using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    public float timeValue;
    public TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeValue = Time.timeSinceLevelLoad;
        int minutes = (int)(timeValue / 60);
        int seconds = (int)(timeValue % 60);

        timeText.text = minutes + ": " + seconds;
    }
}
