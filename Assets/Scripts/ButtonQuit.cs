using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonQuit : MonoBehaviour
{
    private UnityAction myAction;

    // Start is called before the first frame update
    void Start()
    {
        Button myButton = GetComponent<Button>();
        myButton.onClick.AddListener(QuitGame);
    }


    public void QuitGame()
    {
        SceneLoader.Instance.QuitGame();
    }
}
