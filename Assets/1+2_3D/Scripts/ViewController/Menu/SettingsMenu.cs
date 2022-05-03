using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _previousPanel;
        [SerializeField] private GameObject _settingsPanel;
        // [SerializeField] private MainMenuAnimations _mainMenuAnimations;
        // [SerializeField] private StartMenuAnimations _startMenuAnimator;
        //private Button _back;
        [SerializeField] private Button _back;

        private bool _isOpened = false;

        //private void Awake()
        //{
        //    _back = GetComponent<Button>();
        //}

        public void BackInStart()
        {
            _previousPanel.SetActive(!_isOpened);
            _settingsPanel.SetActive(_isOpened);
           // _startMenuAnimator.ForBack();
        }

        public void BackInMain()
        {
            _previousPanel.SetActive(!_isOpened);
            _settingsPanel.SetActive(_isOpened);
           // _mainMenuAnimations.ForPause();
        }
    }
}
