using UnityEngine.AI;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public NavMeshSurface surface;

    public int width = 50;
    public int height = 50;

    public GameObject wall;
    public GameObject player;

    private bool playerSpawned = false;

    void Start()
    {
        GenerateLevel();

        surface.BuildNavMesh();
    }


    void GenerateLevel()
    {
        for(int x = 10; x<= width; x += 2)
        {
            for(int y=0; y<=height; y += 2)
            {
                if(Random.value > .7f)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                }else if(!playerSpawned)
                {
                    Vector3 pos = new Vector3(x - width / 2f, 1.25f, y - height / 2f);
                    Instantiate(wall, pos, Quaternion.identity, transform);
                    playerSpawned = true;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
