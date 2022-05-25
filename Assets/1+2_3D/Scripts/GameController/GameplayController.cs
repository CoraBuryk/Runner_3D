using _1_2_3D.Scripts.ViewController.Animations;
using _1_2_3D.Scripts.ViewController.Audio;
using _1_2_3D.Scripts.ViewController.Menu;
using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.GameController
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private Button[] _answerButtons;
        [SerializeField] private GameObject _examplePrefab;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private BoneAnimation _boneAnimation;
        [SerializeField] private PlayerPreferences _playerPref;
        [SerializeField] private AudioEffectsMainScene _audioEffects;
        [SerializeField] private GameOverMenu _gameOverMenu;

        private const int HighBonus = 20;
        private const int LowBonus = 10;

        private void Awake()
        {
            StartCoroutine(_timerController.StartTimer());
            TotalTimeController.ResetTotalTime();
            BoneCounterContoller.BoneCounter = 0;
            _answerButtons[0].onClick.AddListener(() => AnswerButton(1));
            _answerButtons[1].onClick.AddListener(() => AnswerButton(2));
            _answerButtons[2].onClick.AddListener(() => AnswerButton(3));
        }

        private void OnEnable()
        {
            _timerController.TimerChange += TimeZero;
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= TimeZero;
        }

        public void AnswerButton(int answer)
        {
            if (answer == _levelController.Total)
            {
                AnswerRight();              
            }
            else
            {
                AnswerWrong();               
            }
            _timerController.TimerSwitch(0);
            _examplePrefab.SetActive(false);
        }

        private void AnswerRight()
        {
            _audioEffects.PlayAnswerRight();
            _playerAnimator.RightAnswer();
            BoneUpdate();
            _levelController.LevelUp();
            _levelController.SetExample();
            _timerController.TimerSwitch(0);
        }

        private void AnswerWrong()
        {
            _audioEffects.PlayAnswerWrong();
            _playerAnimator.WrongAnswer();
            _timerController.TimerSwitch(0);
            _levelController.LevelUp();
            _levelController.SetExample();
            _healthController.HealthDecreased();
        }

        private void BoneUpdate()
        {
             if (_timerController.TimeLeft > 5)
             {
                BoneCounterContoller.ChangeNumberOfBone(BoneCounterContoller.BoneCounter += HighBonus);
             }
             else if (_timerController.TimeLeft <= 5)
             {
                BoneCounterContoller.ChangeNumberOfBone(BoneCounterContoller.BoneCounter += LowBonus);
             }
        }

        public void TimeZero()
        {
            if (_timerController.TimeLeft <= 0)
            {
                _timerController.TimerSwitch(1);
                _examplePrefab.SetActive(false);
                _healthController.HealthDecreased();
                AnswerWrong();
            }
        }

        public void Restart()
        {
            _boneAnimation.BoneBehavior();
            _healthController.ResetHealth();
            BoneCounterContoller.ChangeNumberOfBone(0);
            TotalTimeController.ResetTotalTime();
        }

        public void Continue()
        {
            _boneAnimation.BoneBehavior();
            TotalTimeController.OpenedPauseTime();
            TotalTimeController.IsPaused = false;
        }

        public void ActivateTimer()
        {
            _timerController.TimerSwitch(1);
        }

        public void Pause()
        {
            TotalTimeController.ActivePause();
            TotalTimeController.IsPaused = true;
            _examplePrefab.SetActive(false);
            _timerController.TimerSwitch(0);
        }

        public void Over()
        {
            TotalTimeController.ActiveGameTime();
            _playerPref.SaveHighScore();
            _timerController.TimerSwitch(0);
        }
    }
}
