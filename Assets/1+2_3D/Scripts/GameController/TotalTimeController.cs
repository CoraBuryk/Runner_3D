using System;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public static class TotalTimeController
    {
        public static float GameTime { get; private set; }
        public static float ActiveTime { get; private set; }
        public static float ActiveTimeForPause { get; private set; }
        public static float PausedTime { get; private set; }
        public static bool IsPaused { get; set; } = false;

        public static event Action TotalTimeChange;


        public static void ActiveGameTime()
        {
            GameTime = Time.timeSinceLevelLoad - ActiveTime - PausedTime;
            TotalTimeChange?.Invoke();
        }

        public static void ActivePause()
        {
            ActiveTimeForPause = Time.timeSinceLevelLoad;
        }

        public static void OpenedPauseTime()
        {
            if (IsPaused == true)
            {
                float margin = Time.timeSinceLevelLoad - ActiveTimeForPause;
                PausedTime += margin;
            }
        }

        public static void ResetTotalTime()
        {
            GameTime = 0;
            ActiveTime = Time.timeSinceLevelLoad;
            ActiveTimeForPause = 0;
            PausedTime = 0;
        }
    }
}
