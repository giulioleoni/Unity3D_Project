using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsText : MonoBehaviour
{
    public TMP_Text myText;
    // Start is called before the first frame update
    void Start()
    {
        myText.text = Transporter.Instance.playerPoints.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
