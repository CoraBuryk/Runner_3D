using _1_2_3D.Scripts.ViewController.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.GameController
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelController _levelController;
        [SerializeField] private BoneCounterContoller _boneCounterController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private Button[] _answerButtons;
        [SerializeField] private GameObject _examplePrefab;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private Bone bone;
        [SerializeField] private PlayerPref _playerPref;
        // [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private AudioEffects _audioEffects;
        //[SerializeField] private MainMenuAnimations _mainMenuAnimations;

        private void Start()
        {
            StartCoroutine(_timerController.StartTimer());
           //_timerController.ResetTotalTime();

            _answerButtons[0].onClick.AddListener(() => AnswerButton(1));
            _answerButtons[1].onClick.AddListener(() => AnswerButton(2));
            _answerButtons[2].onClick.AddListener(() => AnswerButton(3));
        }

        private void OnEnable()
        {
            //_mainMenuAnimations.ForMain();
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
            _examplePrefab.SetActive(false);
            _audioEffects.PlayExampleOff();
            _audioEffects.PlayMain();
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
        }

        private void BoneUpdate()
        {
             if (_timerController.TimeLeft > 5)
             {
                _boneCounterController.ChangeNumberOfBone(_boneCounterController.BoneCounter *= 2);
             }
             else if (_timerController.TimeLeft <= 5)
             {
                _boneCounterController.ChangeNumberOfBone(_boneCounterController.BoneCounter += _boneCounterController.BoneCounter);
             }
        }

        public void TimeZero()
        {
            if (_timerController.TimeLeft <= 0)
            {
                _timerController.TimerSwitch(1);
                _examplePrefab.SetActive(false);
                _healthController.HealthDecreased();
            }
        }

        public void Restart()
        {
            bone.BoneAnimation();
            _healthController.ResetHealth();
            _boneCounterController.ChangeNumberOfBone(0);
            _timerController.ResetTotalTime();
            _examplePrefab.SetActive(false);
        }

        public void Continue()
        {
            bone.BoneAnimation();
            _timerController.OpenedPauseTime();
            _timerController.IsPaused = false;
        }

        public void ActivateTimer()
        {
            if(_examplePrefab.activeSelf != true)
            {
                return;
            }
            _timerController.TimerSwitch(1);
        }

        public void Pause()
        {
            _timerController.ActivePause();
            _timerController.IsPaused = true;
            _examplePrefab.SetActive(false);
        }

        public void Over()
        {
            _timerController.ActiveGameTime();
            _playerPref.SaveHighScore();
            _timerController.TimerSwitch(0);
        }
    }
}
