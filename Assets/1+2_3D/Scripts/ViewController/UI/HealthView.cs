using _1_2_3D.Scripts.GameController;
using UnityEngine;
using UnityEngine.UI;

namespace _1_2_3D.Scripts.ViewController.UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image[] _hearts;
        [SerializeField] private Sprite _fullHeart;
        [SerializeField] private Sprite _emptyHeart;
        [SerializeField] private HealthController _healthController;

        private void OnEnable()
        {
            _healthController.HealthChange += HeartsView;
        }

        private void OnDisable()
        {
            _healthController.HealthChange -= HeartsView;
        }

        private void Start()
        {
            HeartsView();
        }

        public void HeartsView()
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < _healthController.NumOfHeart)
                {
                    _hearts[i].sprite = _fullHeart;
                }
                else
                {
                    _hearts[i].sprite = _emptyHeart;
                }
            }
        }
    }
}
