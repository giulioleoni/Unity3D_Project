using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class ButtonQuit : MonoBehaviour
{
    public Button myButton;
    public UnityAction myAction;
    // Start is called before the first frame update
    void Start()
    {
        myAction += TransporterQuitGame;
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

    public void TransporterQuitGame()
    {
        Transporter.Instance.QuitGame();
    }
}
