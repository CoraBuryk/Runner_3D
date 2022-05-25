using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
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
        [SerializeField] private PlayableDirector _playableDirector;

        private bool _isOpened = false;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(ExitGame);
            _settingsButton.onClick.AddListener(Settings);
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(StartGame);
            _exitButton.onClick.RemoveListener(ExitGame);
            _settingsButton.onClick.RemoveListener(Settings);
        }

        private async void StartGame()
        {
            _playableDirector.Play();
            await Task.Delay(2000);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
        }

        private void Settings()
        {
            _settingsPanel.SetActive(!_isOpened);
            _startPanel.SetActive(_isOpened);
        }

        private void ExitGame()
        {
            Application.Quit();
        }
    }
}
