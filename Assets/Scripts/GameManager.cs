using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int totalPoints;
    private GameTimer gameTimer;
    [SerializeField] private List<GameObject> collectibles;
    [SerializeField] private int collectiblePoints;
    [SerializeField] private TMP_Text pointsValueText;
    [SerializeField] private Vector3 rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gameTimer = GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < collectibles.Count; i++)
        {
            Transform meshTransform = collectibles[i].transform.GetChild(0);
            meshTransform.Rotate(rotationSpeed * Time.deltaTime, Space.World);
        }
    }

    public void PickUpCollectible(GameObject collectible)
    {
        collectibles.Remove(collectible);
        Destroy(collectible);

        totalPoints += collectiblePoints;
        pointsValueText.text = totalPoints.ToString();

        if(collectibles.Count <= 0) 
        {
            LoadGameEndScene();
        }
    }

    public void LoadGameEndScene()
    {
        if (gameTimer.GameTime <= 0)
        {
            totalPoints = 0;
        }
        else
        {
            totalPoints += (int)(gameTimer.GameTime * 3);
        }

        PlayerPrefs.SetInt("Points", totalPoints);
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(SceneManager.loadedSceneCount + 1);
    }

}
