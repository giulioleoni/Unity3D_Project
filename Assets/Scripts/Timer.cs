using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    private float timeValue;
    [SerializeField] private TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeValue = 120;
    }

    // Update is called once per frame
    void Update()
    {
        //timeValue = Time.timeSinceLevelLoad;
        timeValue -= Time.deltaTime;
        int minutes = (int)(timeValue / 60);
        int seconds = (int)(timeValue % 60);

        timeText.text = minutes + ":" + seconds;
    }
}
