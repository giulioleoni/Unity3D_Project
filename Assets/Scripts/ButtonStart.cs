using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonStart : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneLoader.Instance.LoadNextScene(sceneIndex);
    }
}
