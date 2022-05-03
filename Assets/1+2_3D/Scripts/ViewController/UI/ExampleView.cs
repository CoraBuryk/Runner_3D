using _1_2_3D.Scripts.GameController;
using TMPro;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.UI
{
    public class ExampleView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _example;
        [SerializeField] private LevelController _levelController;

        private void OnEnable()
        {
            _levelController.LevelChange += ExampleText;
        }

        private void OnDisable()
        {
            _levelController.LevelChange -= ExampleText;
        }

        private void Awake()
        {
            ExampleText();
        }

        public void ExampleText()
        {
            _example.text = _levelController.ExampleText;
        }
    }
}
