using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    public Vector2Int mazeSize;
    public int startPos = 0;
    private int up = 0;
    private int down = 1;
    private int right = 2;
    private int left = 3;

    public List<GameObject> roomsPrefabs;
    public Vector3 offset;

    public List<MazeRoomInfo> maze;

    public GameObject player, goblet, door, key, coin;

    private int coinSpawnPercentage = 40;

    void Awake()
    {
        MazeGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomInstantiator()
    {
        int RandI = Random.Range(1, mazeSize.x);  // da 1 altrimenti potrebbero venire entrambi 0
        int RandJ = Random.Range(0, mazeSize.y);

        for (int i = 0; i < mazeSize.x; i++)
        {
            for (int j = 0; j < mazeSize.y; j++)
            {
                MazeRoomInfo currentRoom = maze[i + j * mazeSize.x];

                int randomRoom = Random.Range(0, roomsPrefabs.Count);
                
                GameObject go = Instantiate(roomsPrefabs[randomRoom], new Vector3(i * offset.x, offset.y, -j * offset.z), Quaternion.identity, transform);
                RoomLogic newRoom = go.GetComponent<RoomLogic>();
                newRoom.UpdateRoomStatus(currentRoom.doorState, currentRoom.hasKey, currentRoom.hasDoor);

                if (newRoom.hasKey)
                {
                    SpawnKey(go.transform);
                }

                if (newRoom.hasDoor)
                {
                    SpawnDoor(newRoom);
                }

                if (i == 0 && j == 0)
                {
                    Instantiate(player, go.transform.position, Quaternion.identity);
                }
                
                if (i == RandI && j == RandJ)
                {
                    Instantiate(goblet, go.transform.position, Quaternion.identity);
                }

                int randomInt = Random.Range(0, 100);
                if (randomInt < coinSpawnPercentage)
                {
                    SpawnCoin(go.transform);
                }
            }
        }


    }

    private void SpawnKey(Transform roomTransform)
    {
        Transform spawner = roomTransform.GetChild(0);

        List<Transform> spawnPoints = new List<Transform>();
        for (int i = 0; i < spawner.childCount; i++)
        {
            spawnPoints.Add(spawner.GetChild(i));
        }

        int randIndex = Random.Range(0, spawnPoints.Count);
        GameObject go = Instantiate(key, spawnPoints[randIndex].position, key.transform.rotation, spawnPoints[randIndex]);
        go.transform.position = new Vector3(go.transform.position.x, 1, go.transform.position.z);
        
    }

    private void SpawnCoin(Transform roomTransform)
    {
        Transform spawner = roomTransform.GetChild(0);

        for (int i = 0; i < spawner.childCount; i++)
        {
            if (spawner.GetChild(i).childCount == 0)
            {
                Instantiate(coin, spawner.GetChild(i));
                return;
            }
        }
    }

    private void SpawnDoor(RoomLogic room)
    {
        int randIndex = Random.Range(0, room.activeDoors.Count);

        Transform root = room.activeDoors[randIndex].transform;

        Transform spawn = root.GetChild(0);
        Instantiate(door, spawn);
    }

    public void MazeGenerator()
    {
        maze = new List<MazeRoomInfo>();

        for (int i = 0; i < mazeSize.x; i++)
        {
            for (int j = 0; j < mazeSize.y; j++)
            {
                maze.Add(new MazeRoomInfo());
            }
        }

        int currentRoom = startPos;

        Stack<int> path = new Stack<int>();
        bool pathExplored = false;

        int cycle = 0;
        int cycleSpawnStep = 2;
        int nextCycleSpawn = cycleSpawnStep;
        bool spawnedKey = false;

        while (!pathExplored)
        {
            maze[currentRoom].visited = true;

            List<int> neighbours = CheckNeighbours(currentRoom);

            if (neighbours.Count == 0)
            {
                if (path.Count == 0)
                {
                    // se non troviamo stanze vicine e il labirinto è stato tutto esplorato 
                    pathExplored = true;
                }
                else
                {
                    // se non è stato esplorato tutto il labirinto, torniamo all'ultima stanza visitata
                    // e riprendiamo a controllare le stanze vicine
                    currentRoom = path.Pop();
                }
            }
            else
            {
                path.Push(currentRoom);

                int randIndex = Random.Range(0, neighbours.Count);
                int nextRoom = neighbours[randIndex];

                if (nextRoom > currentRoom)
                {
                    // down or right
                    if (nextRoom - 1 == currentRoom)
                    {
                        // right 
                        maze[currentRoom].doorState[right] = true;
                        currentRoom = nextRoom;
                        maze[currentRoom].doorState[left] = true;
                    }
                    else
                    {
                        // down 
                        maze[currentRoom].doorState[down] = true;
                        currentRoom = nextRoom;
                        maze[currentRoom].doorState[up] = true;
                    }
                }
                else
                {
                    // up or left
                    if (nextRoom + 1 == currentRoom)
                    {
                        // left 
                        maze[currentRoom].doorState[left] = true;
                        currentRoom = nextRoom;
                        maze[currentRoom].doorState[right] = true;
                    }
                    else
                    {
                        // up 
                        maze[currentRoom].doorState[up] = true;
                        currentRoom = nextRoom;
                        maze[currentRoom].doorState[down] = true;
                    }
                }

                if (cycle == nextCycleSpawn)
                {
                    if (!spawnedKey)
                    {
                        maze[currentRoom].hasKey = true;
                        spawnedKey = true;
                    }
                    else
                    {
                        maze[currentRoom].hasDoor = true;
                        spawnedKey = false;
                    }

                    if (nextCycleSpawn < maze.Count - (cycleSpawnStep * 2 + 1))
                    {
                        nextCycleSpawn += cycleSpawnStep;
                    }
                }

                cycle++;
            }
        }
        RoomInstantiator();
    }

    public List<int> CheckNeighbours(int room)
    {
        List<int> neighbours = new List<int>();

        // up
        // controllo prima che non ci sia una stanza sopra di noi, e poi se non è già stata visitata
        if (room - mazeSize.x >= 0 && !maze[room - mazeSize.x].visited)
        {
            neighbours.Add(room - mazeSize.x);
        }
        
        // down
        if (room + mazeSize.x < maze.Count && !maze[room + mazeSize.x].visited)
        {
            neighbours.Add(room + mazeSize.x);
        }

        // right
        if ((room + 1) % mazeSize.x != 0 && !maze[room + 1].visited)
        {
            neighbours.Add(room + 1);
        }

        // left
        if (room % mazeSize.x != 0 && !maze[room - 1].visited)
        {
            neighbours.Add(room - 1);
        }

        return neighbours;
    }
}


[System.Serializable]
public class MazeRoomInfo
{
    public bool visited;
    public bool[] doorState = new bool[4];
    public bool hasDoor;
    public bool hasKey;
}