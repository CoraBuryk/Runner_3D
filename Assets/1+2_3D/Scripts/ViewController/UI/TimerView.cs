using _1_2_3D.Scripts.GameController;
using TMPro;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.UI
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private TimerController _timerController;

        private void OnEnable()
        {
            _timerController.TimerChange += UpdateTimeText;
        }

        private void OnDisable()
        {
            _timerController.TimerChange -= UpdateTimeText;
        }

        private void UpdateTimeText()
        {
            float seconds = Mathf.FloorToInt(_timerController.TimeLeft % 60);
            _timerText.text = string.Format("{00:00}", seconds);
        }
    }
}
