using _1_2_3D.Scripts.GameController;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class GameOverMenu : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _scoreBest;
        [SerializeField] private TextMeshProUGUI _time;
        [SerializeField] private BoneCounterContoller _boneCounterController;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private TimerController _timerController;


        private bool _isOpened = false;
        private int _previousHighScore;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(RestartGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        private string GetStringScore()
        {
           return LocalizationSettings.StringDatabase.GetLocalizedString("UI Text", "Key_Score");
        }

        private string GetStringTime()
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString("UI Text", "Key_TotalTime");
        }

        private string GetStringMin()
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString("UI Text", "Key_Min");
        }

        private string GetStringSec()
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString("UI Text", "Key_Sec");
        }

        private string GetBestScoreString()
        {
            return LocalizationSettings.StringDatabase.GetLocalizedString("UI Text", "Key_BestScore");
        }

        private void FinalScore()
        {
            _score.text = GetStringScore() + $"{_boneCounterController.BoneCounter}";
        }
      
        private void TotalTime()
        {
            int seconds = Mathf.FloorToInt(_timerController.GameTime % 60);
            int minutes = Mathf.FloorToInt(_timerController.GameTime / 60);

            string min = (minutes < 10) ? "" + minutes.ToString() : minutes.ToString();
            string sec = (seconds < 59) ? "" + seconds.ToString() : seconds.ToString();

            _time.text = string.Format(GetStringTime() + min + GetStringMin() + sec + GetStringSec());
        }

        private void BestScore()
        {
            _scoreBest.enabled = false;
            if (_previousHighScore < _boneCounterController.HighScore)
            {
                _scoreBest.enabled = true;
                _scoreBest.text = GetBestScoreString() + $"{_boneCounterController.HighScore}";
                //_audioEffects.PlayOnBestScore();
                _previousHighScore = _boneCounterController.HighScore;
            }
        }

        private void RestartGame()
        {
            _gameOverPanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Restart();
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //_mainAnimations.KillAnimations();
        }

        public void End()
        {
            _mainPanel.SetActive(_isOpened);
            _gameOverPanel.SetActive(!_isOpened);
            _gameplayController.Over();
            BestScore();
            FinalScore();
            TotalTime();
        }
    }
}
