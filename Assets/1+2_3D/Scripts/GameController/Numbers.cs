using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class Numbers
    {
        public int Result { get; private set; }
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int X { get; set; }
        public string MathExample { get; private set; }

        public void DoLevelOne()
        {               
            do
            {
                Num1 = Random.Range(0, 10);
                Num2 = Random.Range(0, Num1);
                Result = Num1 - Num2;
            } while (Result >= 4 || Result <= 0);

            MathExample = $"{Num1} - {Num2} = ?";
        }

        public void DoLevelTwo()
        {
            do
            {
                Num1 = Random.Range(1, 10);
                Num2 = Random.Range(1, Num1);
                if (Num1 % Num2 == 0 && Num1 * 1 == Num2 || Num2 * 2 == Num1 || Num2 * 3 == Num1)
                {
                    Result = Num1 / Num2;
                }
                else Result = 0;
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} / {Num2} = ?";
        }

        public void DoLevelThree()
        {
            do
            {
                Num1 = Random.Range(10, 100);
                Num2 = Random.Range(10, Num1);
                Result = Num1 - Num2;
                MathExample = $"{Num1} - {Num2} = ?";
            } while (Result >= 4 || Result == 0);

            MathExample = $"{Num1} - {Num2} = ?";
        }

        public void DoLevelFour()
        {      
            do
            {
                Num1 = Random.Range(10, 100);
                Num2 = Random.Range(10, Num1);
                if (Num1 % Num2 == 0 && Num1 * 1 == Num2 || Num2 * 2 == Num1 || Num2 * 3 == Num1)
                {
                    Result = Num1 / Num2;
                }
                else Result = 0;
            } while (Result >= 4 || Result == 0);

            MathExample = $" {Num1} / {Num2} = ?";
        }

        public void DoLevelFive()
        {
            do
            {
                Num1 = Random.Range(1, 50);
                Num2 = Random.Range(1, Num1);
                if ((Num1 - Num2) % 2 == 0 && 2 * 1 == (Num1 - Num2) || 2 * 2 == (Num1 - Num2) || 2 * 3 == (Num1 - Num2))
                {
                    Result = (Num1 - Num2) / 2;
                }
                else Result = 0;
            } while (Result >= 4 || Result == 0);

            MathExample = $"({Num1} - {Num2}) / 2 = ?";
        }

        public void DoLevelSix()
        {
            do
            {
                Num1 = Random.Range(100, 150);
                Num2 = Random.Range(100, Num1);

                if ((Num1 - Num2) % 2 == 0 && 2 * 1 == (Num1 - Num2) || 2 * 2 == (Num1 - Num2) || 2 * 3 == (Num1 - Num2))
                {
                    Result = (Num1 - Num2) / 2;
                }
                else Result = 0;
            } while (Result >= 4 || Result == 0);

            MathExample = $"({Num1} - {Num2}) / 2 = ?";
        }

        public void DoLevelSeven()
        {
            do
            {
                Num1 = Random.Range(1, 50);
                Num2 = Random.Range(1, Num1);
                X = Random.Range(0, 3);
                Result = (Num1 - Num2) * X;
            } while (Result >= 4 || Result == 0);

            MathExample = $" ({Num1} - {Num2}) * {X} = ?";
        }

        public void DoLevelEight()
        {
            do
            {
                Num1 = Random.Range(50, 100);
                Num2 = Random.Range(50, Num1);
                X = Random.Range(0, 3);
                Result = (Num1 - Num2) * X;
            } while (Result >= 4 || Result == 0);

            MathExample = $" ({Num1} - {Num2}) * {X} = ?";
        }
    }
}