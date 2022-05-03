using _1_2_3D.Scripts.GameController;
using System.Threading.Tasks;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.Animations
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private PlayerMovementController _playerMovementController;


        private const string Start = "isStart";
        private const string Run = "isRun";
        private const string Jump = "isJump";
        private const string Falling = "isFalling";
        private const string Right = "isRight";
        private const string Wrong = "isWrong";
        private const string Pause = "isPause";
        private const string Break = "isQuestion";
        private const string Over = "isOver";

        public void ForStart()
        {
            _playerAnimator.SetBool(Start, true);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForRun()
        {
            if(_playerMovementController == null)
            {
                return;
            }

            _playerMovementController.enabled = true;
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, true);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForJump()
        {
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, true);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForBreak()
        {
            _playerMovementController.enabled = false;
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, true);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForFalling()
        {
            _playerMovementController.enabled = false;
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, true);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForRight()
        {
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, true);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForWrong()
        {
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, true);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForPause()
        {
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, true);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, false);
        }

        public void ForOver()
        {
            _playerAnimator.SetBool(Start, false);
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
            _playerAnimator.SetBool(Over, true);
        }

        public async void RightAnswer()
        {
            ForRight();
            await Task.Delay(1500);
            ForRun();
            _playerMovementController.Speed = 10;
        }

        public async void WrongAnswer()
        {
            ForWrong();
            await Task.Delay(2000);
            ForRun();
            _playerMovementController.Speed = 10;
        }

        public async void Jumping()
        {
            ForJump();
            await Task.Delay(1000);
            ForRun();
        }

        public async void Fall()
        {
            _playerMovementController.Speed = 0;
            ForFalling();
            await Task.Delay(2300);
            ForRun();
            _playerMovementController.Speed = 10;
        }

        public async void GameOver()
        {
            _playerMovementController.Speed = 0;
            ForFalling();
            await Task.Delay(2300);
            ForOver();
            _playerMovementController.Speed = 0;
        }
    }
}
