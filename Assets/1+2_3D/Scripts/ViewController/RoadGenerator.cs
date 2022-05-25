using System.Collections.Generic;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController
{
    public class RoadGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject[] _roadPrefabs;
        private List<GameObject> _activeRoads = new List<GameObject>();
        private float _spawnPosition = 28;
        private const float _roadLength = 30;
        private int _startRoads = 5;

        void Awake()
        {
            for (int i = 0; i < _startRoads; i++)
            {
                CreateRoad(Random.Range(0, _roadPrefabs.Length));
            }
        }

        void Update()
        {
            if (_player.position.z - 60 > _spawnPosition - (_startRoads * _roadLength))
            {
                CreateRoad(Random.Range(0, _roadPrefabs.Length));
                DeleteRoads();
            }
        }

        private void CreateRoad(int roadIndex)
        {
            GameObject nextRoad = Instantiate(_roadPrefabs[roadIndex], transform.forward * _spawnPosition, transform.rotation);
            _activeRoads.Add(nextRoad);
            _spawnPosition += _roadLength;
        }

        private void DeleteRoads()
        {
            Destroy(_activeRoads[0]);
            _activeRoads.RemoveAt(0);
        }

        public void DestroyAllRoads()
        {
            for(int i = 0; i < _activeRoads.Count; i++)
            {
                Destroy(_activeRoads[i]);
            }
        }
    }
}
