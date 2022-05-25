using _1_2_3D.Scripts.GameController;
using _1_2_3D.Scripts.ViewController.Animations;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class SceneBehavior : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private PlayableDirector _playableDirector;
        [SerializeField] private RoadGenerator _roadGenerator;
        [SerializeField] private MapGenerator _mapGenerator;
        [SerializeField] private GameplayController _gameplayController;

        private void OnEnable()
        {
            _pauseButton.onClick.AddListener(_pauseMenu.PauseGame);
            _healthController.HealthChange += ZeroHealth;
        }

        private void OnDisable()
        {
            _pauseButton.onClick.RemoveListener(_pauseMenu.PauseGame);
            _healthController.HealthChange -= ZeroHealth;
        }

        public async void ZeroHealth()
        {           
            if (_healthController.NumOfHeart > 0)
            {
                _playerMovementController.IsStop = true;
                _playerMovementController.Speed = 0;
                _playerAnimator.Fall(); 
            }
            else if(_healthController.NumOfHeart <= 0)
            {
                _mapGenerator.DestroyAllMaps();
                _roadGenerator.DestroyAllRoads();
                _playableDirector.Play();
                await Task.Delay(5100);
                _gameplayController.Over();
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            }
        }
    }
}
