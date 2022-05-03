using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] mapPrefabs;
    private List<GameObject> activeMaps = new List<GameObject>();
    private float spawnPosition = 0;
    private float mapLength = 30;
    private int startMaps = 5;


    void Awake()
    {
        for (int i = 0; i < startMaps; i++)
        {
            CreateRoad(Random.Range(0, mapPrefabs.Length));
        }
    }

    void Update()
    {
        if (player.position.z - 60 > spawnPosition - (startMaps * mapLength))
        {
            CreateRoad(Random.Range(0, mapPrefabs.Length));
            DeleteRoads();
        }
    }

    private void CreateRoad(int mapIndex)
    {
        GameObject nextRoad = Instantiate(mapPrefabs[mapIndex], transform.forward * spawnPosition, transform.rotation);
        activeMaps.Add(nextRoad);
        spawnPosition += mapLength;
    }

    private void DeleteRoads()
    {
        Destroy(activeMaps[0]);
        activeMaps.RemoveAt(0);
    }
}
