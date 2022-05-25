using System.Collections.Generic;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private GameObject[] _mapPrefabs;
        private List<GameObject> _activeMaps = new List<GameObject>();
        private float _spawnPosition = 28;
        private const float _mapLength = 30;
        private int _startMaps = 5;

        void Awake()
        {
            for (int i = 0; i < _startMaps; i++)
            {
                CreateMap(Random.Range(0, _mapPrefabs.Length));
            }
        }

        void Update()
        {
            if (_player.position.z - 60 > _spawnPosition - (_startMaps * _mapLength))
            {
                CreateMap(Random.Range(0, _mapPrefabs.Length));
                DeleteMap();
            }
        }

        private void CreateMap(int mapIndex)
        {
            GameObject nextRoad = Instantiate(_mapPrefabs[mapIndex], transform.forward * _spawnPosition, transform.rotation);
            _activeMaps.Add(nextRoad);
            _spawnPosition += _mapLength;
        }

        private void DeleteMap()
        {
            Destroy(_activeMaps[0]);
            _activeMaps.RemoveAt(0);
        }

        public void DestroyAllMaps()
        {
            for(int i = 0; i < _activeMaps.Count; i++)
            {
                Destroy(_activeMaps[i]);
            }
        }
    }
}
