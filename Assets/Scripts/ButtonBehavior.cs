using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
    public Button myButton;
    public UnityAction myAction;
    public int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        myAction += LoadSceneOfTheTransporter;
        myButton.onClick.AddListener(CallAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallAction()
    {
        myAction();
    }

    public void LoadSceneOfTheTransporter()
    {
        Transporter.Instance.LoadNextScene(sceneIndex);
    }
}
