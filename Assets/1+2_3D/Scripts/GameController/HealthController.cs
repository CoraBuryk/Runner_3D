using System;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int _maxHealth;
        public int NumOfHeart { get; private set; }

        public event Action HealthChange;

        private void Awake()
        {
            NumOfHeart = _maxHealth;
        }

        public void HealthDecreased()
        {
            _maxHealth -= 1;
            NumOfHeart = _maxHealth;

            HealthChange?.Invoke();
        }

        public void ResetHealth()
        {
            _maxHealth = 3;
            NumOfHeart = _maxHealth;

            HealthChange?.Invoke();
        }
    }
}