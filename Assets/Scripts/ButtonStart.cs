using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    private Button myButton;
    private UnityAction myAction;
    [SerializeField] private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
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
        SceneLoader.Instance.LoadNextScene(sceneIndex);
    }
}
