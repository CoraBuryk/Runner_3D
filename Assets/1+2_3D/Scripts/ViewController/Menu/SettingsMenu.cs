using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.Menu
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _previousPanel;
        [SerializeField] private GameObject _settingsPanel;
        [SerializeField] private Button _back;

        private bool _isOpened = false;

        public void BackInStart()
        {
            _previousPanel.SetActive(!_isOpened);
            _settingsPanel.SetActive(_isOpened);
        }

        public void BackInMain()
        {
            _previousPanel.SetActive(!_isOpened);
            _settingsPanel.SetActive(_isOpened);
        }
    }
}
