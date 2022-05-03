using System;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class BoneCounterContoller : MonoBehaviour
    {
        public int BoneCounter;

        public int HighScore { get; set; }

        public event Action BoneCountChange;

        public void ChangeNumberOfBone(int newCounter)
        {
            BoneCounter = newCounter;
            BoneCountChange?.Invoke();
        }
    }
}
