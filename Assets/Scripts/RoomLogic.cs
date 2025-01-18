using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLogic : MonoBehaviour
{
    public List<GameObject> walls; 
    public List<GameObject> doors;
    public List<GameObject> activeDoors;
    public bool hasDoor;
    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRoomStatus(bool[] doorState, bool key, bool door)
    {
        for (int i = 0; i < doorState.Length; i++)
        {
            doors[i].SetActive(doorState[i]);
            if (doors[i].activeSelf)
            {
                activeDoors.Add(doors[i]);
            }
            walls[i].SetActive(!doorState[i]);
            
        }

        hasKey = key;
        hasDoor = door;
    }
}
