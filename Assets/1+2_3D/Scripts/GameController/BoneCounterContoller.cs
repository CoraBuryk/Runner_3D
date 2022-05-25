using System;

namespace _1_2_3D.Scripts.GameController
{
    public static class BoneCounterContoller
    {
        public static int BoneCounter { get; set; }

        public static int HighScore { get; set; }

        public static event Action BoneCountChange;

        public static void ChangeNumberOfBone(int newCounter)
        {
            BoneCounter = newCounter;
            BoneCountChange?.Invoke();
        }
    }
}
