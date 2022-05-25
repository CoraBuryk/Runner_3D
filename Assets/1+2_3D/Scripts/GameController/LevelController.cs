using System;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class LevelController : MonoBehaviour
    {
        private Numbers _numbers = new Numbers();

        public string ExampleText { get => _numbers.MathExample; }
        public int Total { get => _numbers.Result; }
        public int Level { get; private set; }

        public event Action LevelChange;

        private const int NumbersOfExamplesForLvl1 = 5;
        private const int NumbersOfExamplesForLvl2 = 10;
        private const int NumbersOfExamplesForLvl3 = 15;
        private const int NumbersOfExamplesForLvl4 = 25;
        private const int NumbersOfExamplesForLvl5 = 35;
        private const int NumbersOfExamplesForLvl6 = 55;
        private const int NumbersOfExamplesForLvl7 = 75;

        private void Awake()
        {
            FirstLevel();
            SetExample();
        }

        public void FirstLevel()
        {
            Level = 0;
        }

        public void SetExample()
        {
            if (Level <= NumbersOfExamplesForLvl1)
            {
                _numbers.DoLevelOne();
            }
            else if (Level <= NumbersOfExamplesForLvl2)
            {
                _numbers.DoLevelTwo();
            }
            else if (Level <= NumbersOfExamplesForLvl3)
            {
                _numbers.DoLevelThree();
            }
            else if (Level <= NumbersOfExamplesForLvl4)
            {
                _numbers.DoLevelFour();
            }
            else if (Level <= NumbersOfExamplesForLvl5)
            {
                _numbers.DoLevelFive();
            }
            else if (Level <= NumbersOfExamplesForLvl6)
            {
                _numbers.DoLevelSix();
            }
            else if (Level <= NumbersOfExamplesForLvl7)
            {
                _numbers.DoLevelSeven();
            }
            else
            {
                _numbers.DoLevelEight();
            }
            LevelChange?.Invoke();
        }

        public void LevelUp()
        {
            Level++;
        }
    }
}