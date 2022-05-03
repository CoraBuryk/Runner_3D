using System.Collections.Generic;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private GameObject[] roadPrefabs;
        private List<GameObject> activeRoads = new List<GameObject>();
        private float spawnPosition = 0;
        private float roadLength = 30;
        private int startRoads = 5;

        void Awake()
        {
            for (int i = 0; i < startRoads; i++)
            {
                CreateRoad(Random.Range(0, roadPrefabs.Length));
            }
        }

        void Update()
        {
            if (player.position.z - 60 > spawnPosition - (startRoads * roadLength))
            {
                CreateRoad(Random.Range(0, roadPrefabs.Length));
                DeleteRoads();
            }
        }

        private void CreateRoad(int roadIndex)
        {
            GameObject nextRoad = Instantiate(roadPrefabs[roadIndex], transform.forward * spawnPosition, transform.rotation);
            activeRoads.Add(nextRoad);
            spawnPosition += roadLength;
        }

        private void DeleteRoads()
        {
            Destroy(activeRoads[0]);
            activeRoads.RemoveAt(0);
        }
    }
}
