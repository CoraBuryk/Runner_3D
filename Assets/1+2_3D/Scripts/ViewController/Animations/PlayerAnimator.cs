using _1_2_3D.Scripts.GameController;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;

namespace _1_2_3D.Scripts.ViewController.Animations
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private PlayableDirector _playableDirector;

        private const string Run = "isRun";
        private const string Jump = "isJump";
        private const string Falling = "isFalling";
        private const string Right = "isRight";
        private const string Wrong = "isWrong";
        private const string Pause = "isPause";
        private const string Break = "isBreak";

        public void ForRun()
        {
            if(_playableDirector.state != PlayState.Playing)
            {
                _playerMovementController.IsStop = false;
                _playerMovementController.Speed = 10;
                _playerAnimator.SetBool(Run, true);
                _playerAnimator.SetBool(Jump, false);
                _playerAnimator.SetBool(Falling, false);
                _playerAnimator.SetBool(Right, false);
                _playerAnimator.SetBool(Wrong, false);
                _playerAnimator.SetBool(Pause, false);
                _playerAnimator.SetBool(Break, false);
            }
        }

        private void ForJump()
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, true);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
        }

        public void ForBreak()
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, true);
        }

        public void ForFalling()
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, true);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
        }

        private void ForRight()
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, true);
            _playerAnimator.SetBool(Wrong, false);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
        }

        private void ForWrong()
        {
            _playerAnimator.SetBool(Run, false);
            _playerAnimator.SetBool(Jump, false);
            _playerAnimator.SetBool(Falling, false);
            _playerAnimator.SetBool(Right, false);
            _playerAnimator.SetBool(Wrong, true);
            _playerAnimator.SetBool(Pause, false);
            _playerAnimator.SetBool(Break, false);
        }

        public async void RightAnswer()
        {
            _playerMovementController.IsStop = true;
            ForRight();
            await Task.Delay(1500);
            if (_pauseMenu.activeSelf == false)
            {
                ForRun();
            }
        }

        public async void WrongAnswer()
        {
            _playerMovementController.IsStop = true;
            ForWrong();
            await Task.Delay(2000);
            if (_pauseMenu.activeSelf == false)
            {
                ForRun();
            }
        }

        public async void Jumping()
        {
            ForJump();
            await Task.Delay(1000);
            if (_pauseMenu.activeSelf == false)
            {
                ForRun();
            }
        }

        public async void Fall()
        {
            if (_playableDirector.state != PlayState.Playing && _pauseMenu.activeSelf == false)
            {
                ForFalling();
            }
            await Task.Delay(2300);
            if (_pauseMenu.activeSelf == false)
            {
                ForRun();
            }
        }
    }
}
