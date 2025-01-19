using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int maxPoints;
    private int totalPoints;
    private Timer timer;
    [SerializeField] private List<GameObject> collectibles;
    [SerializeField] private int collectiblePoints;
    [SerializeField] private TMP_Text collectiblesNumberText;
    [SerializeField] private Vector3 rotationSpeed;

    private void Awake()
    {
        maxPoints = collectibles.Count * collectiblePoints;
        Cursor.lockState = CursorLockMode.Locked;
        timer = GetComponent<Timer>();
        if (timer != null )
        {
            Debug.Log("Timer non è nullo");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        for (int i = 0; i < collectibles.Count; i++)
        {
            collectibles[i].transform.Rotate(rotationSpeed, Space.World);
        }
    }

    public void PickUpCollectible(GameObject collectible)
    {
        collectibles.Remove(collectible);
        Destroy(collectible);
        totalPoints += collectiblePoints;
        collectiblesNumberText.text = totalPoints.ToString();

        if(totalPoints >= maxPoints) 
        {
            LoadGameEndScene();
        }
    }

    public void LoadGameEndScene()
    {
        totalPoints *= (int)(timer.GameTime * 2);
        PlayerPrefs.SetInt("Points", totalPoints);
        Cursor.lockState = CursorLockMode.Confined;
        SceneLoader.Instance.LoadNextScene(SceneManager.loadedSceneCount + 1);
        //SceneManager.LoadScene(2);
    }

}
