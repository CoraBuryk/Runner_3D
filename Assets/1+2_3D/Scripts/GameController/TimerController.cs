using System;
using System.Collections;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private int _timer; 

        public int TimeLeft { get; set; }
        private int _delta = 0;

        public event Action TimerChange;      

        private void Awake()
        {
            TimerSwitch(0);
        }

        public IEnumerator StartTimer()
        {
            while (TimeLeft > 0)
            {
                TimeLeft -= _delta;
                TimerChange?.Invoke();
                yield return new WaitForSeconds(1);
            }
        }

        public void TimerSwitch(int delta)
        {
            TimeLeft = _timer;
            _delta = delta;
        }
    }
}