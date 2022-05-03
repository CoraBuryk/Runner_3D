using _1_2_3D.Scripts.ViewController.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class StartMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private GameObject _startPanel;
        [SerializeField] private PlayerAnimator _playerAnimator;
        //[SerializeField] private StartMenuAnimations _startMenuAnimations;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(Settings);
           // _startMenuAnimations.ForStart();
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _settingsButton.onClick.RemoveListener(Settings);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //_playerAnimator.ForStart();
            //_startMenuAnimations.KillAnimations();
        }

        private void Settings()
        {
            //_startMenuAnimations.ForSettings();
            _settingsPanel.SetActive(!_isOpened);
            _startPanel.SetActive(_isOpened);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
