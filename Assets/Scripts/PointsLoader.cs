using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text PointsValueText;
    // Start is called before the first frame update
    void Start()
    {
        PointsValueText.text = PlayerPrefs.GetInt("Points").ToString();
    }
}
