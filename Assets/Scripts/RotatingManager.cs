using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingManager : MonoBehaviour
{
    public List<GameObject> rotatingKeys, rotatingCoins;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");
        foreach (GameObject key in keys) 
        {
            rotatingKeys.Add(key);
        }
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject coin in coins)
        {
            rotatingCoins.Add(coin);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < rotatingKeys.Count; i++)
        {
            if (rotatingKeys[i] != null)
            {
                rotatingKeys[i].transform.Rotate(2, 0, 0, Space.World);
            }
        }

        for (int i = 0; i < rotatingCoins.Count; i++)
        {
            if (rotatingCoins[i] != null)
            {
                rotatingCoins[i].transform.Rotate(0, 2, 0, Space.World); 
            }
        }
    }
}
