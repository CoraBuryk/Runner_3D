using _1_2_3D.Scripts.GameController;
using _1_2_3D.Scripts.ViewController.Audio;
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
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _scoreBest;
        [SerializeField] private TextMeshProUGUI _time;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private TimerController _timerController;
        [SerializeField] private AudioEffectGameOverScene _audioEffectGameOver;

        private int _previousHighScore;

        private void OnEnable()
        {    
            _restartButton.onClick.AddListener(RestartGame);
            _exitButton.onClick.AddListener(ExitGame);
            BoneCounterContoller.BoneCountChange += FinalScore;
            BoneCounterContoller.BoneCountChange += BestScore;
            TotalTimeController.TotalTimeChange += TotalTime;
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(RestartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            BoneCounterContoller.BoneCountChange -= FinalScore;
            BoneCounterContoller.BoneCountChange -= BestScore;
            TotalTimeController.TotalTimeChange -= TotalTime;
        }

        private void Start()
        {
            FinalScore();
            BestScore();
            TotalTime();
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
            _scoreText.text = GetStringScore() + $"{BoneCounterContoller.BoneCounter}";
        }

        private void TotalTime()
        {
            int seconds = Mathf.FloorToInt(TotalTimeController.GameTime % 60);
            int minutes = Mathf.FloorToInt(TotalTimeController.GameTime / 60);

            string min = (minutes < 10) ? "" + minutes.ToString() : minutes.ToString();
            string sec = (seconds < 59) ? "" + seconds.ToString() : seconds.ToString();

            _time.text = string.Format(GetStringTime() + min + GetStringMin() + sec + GetStringSec());
        }

        private void BestScore()
        {
            _scoreBest.enabled = false;
            if (_previousHighScore < BoneCounterContoller.HighScore)
            {
                _scoreBest.enabled = true;
                _scoreBest.text = GetBestScoreString() + $"{BoneCounterContoller.BoneCounter}";
                _audioEffectGameOver.PlayOnBestScore();
                _previousHighScore = BoneCounterContoller.HighScore;
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
            _gameplayController.Restart();
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2, LoadSceneMode.Single);
        }
    }
}
