using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public List<GameObject> collectibles;
    private int maxCollectibles;

    private int takenCollectibles;
    [SerializeField] private TMP_Text collectiblesNumberText;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxCollectibles = collectibles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < maxCollectibles; i++) 
        {
            if (collectibles[i] != null)
            {
                collectibles[i].transform.Rotate(2, 2, 0, Space.World);
            }
            
        }
    }

    public void PickUpCollectible(GameObject collectible)
    {
        Destroy(collectible);
        takenCollectibles++;
        collectiblesNumberText.text = takenCollectibles.ToString();

        if(takenCollectibles >= maxCollectibles ) 
        {
            SceneManager.LoadScene(2);
        }
    }

}
