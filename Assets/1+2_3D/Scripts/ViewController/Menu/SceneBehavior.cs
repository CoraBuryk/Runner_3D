using _1_2_3D.Scripts.GameController;
using _1_2_3D.Scripts.ViewController.Animations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class SceneBehavior : MonoBehaviour
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private GameOverMenu _gameOverMenu;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private PlayerMovementController _playerMovementController;
        [SerializeField] private PlayerAnimator _playerAnimator;

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

        public void ZeroHealth()
        {
 
            
            if (_healthController.NumOfHeart > 0)
            {
                _playerAnimator.Fall(); 
            }
            else if(_healthController.NumOfHeart <= 0)
            {
                _playerAnimator.GameOver();
                _gameOverMenu.End();
            }

        }
    }
}
