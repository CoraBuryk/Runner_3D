using _1_2_3D.Scripts.GameController;
using _1_2_3D.Scripts.ViewController.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerAnimator _playerAnimator;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _exitButton.onClick.AddListener(ExitGame);
            _restartButton.onClick.AddListener(RestartGame);
            _settingsButton.onClick.AddListener(GameSettings);
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveListener(ContinueGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _restartButton.onClick.RemoveListener(RestartGame);
            _settingsButton.onClick.RemoveListener(GameSettings);
        }

        public void PauseGame()
        {
            _pausePanel.SetActive(!_isOpened);
            _mainPanel.SetActive(_isOpened);
            _gameplayController.Pause();
            _playerMovementController.IsStop = true;
            _playerMovementController.Speed = 0;
            _playerAnimator.ForBreak();
        }

        private void ContinueGame()
        {
            _pausePanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Continue();
            _playerMovementController.IsStop = false;
            _playerMovementController.Speed = 10;
            _playerAnimator.ForRun();
        }

        private void RestartGame()
        {
            _pausePanel.SetActive(_isOpened);
            _mainPanel.SetActive(!_isOpened);
            _gameplayController.Restart();
            _playerMovementController.IsStop = false;
            _playerMovementController.Speed = 10;
            _playerAnimator.ForRun();
        }

        private void GameSettings()
        {
            _pausePanel.SetActive(_isOpened);
            _settingsPanel.SetActive(!_isOpened);
            _playerMovementController.IsStop = true;
            _playerMovementController.Speed = 0;
            _playerAnimator.ForBreak();
        }

        private void ExitGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
