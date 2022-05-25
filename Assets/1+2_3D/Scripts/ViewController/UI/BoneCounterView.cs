using _1_2_3D.Scripts.GameController;
using TMPro;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.UI
{
    public class BoneCounterView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bones;

        private void OnEnable()
        {
            BoneCounterContoller.BoneCountChange += HandleCounterDelegate;
        }

        private void OnDisable()
        {
            BoneCounterContoller.BoneCountChange -= HandleCounterDelegate;
        }

        private void Start()
        {
            HandleCounterDelegate();
        }

        public void HandleCounterDelegate()
        {
            _bones.text = $"{BoneCounterContoller.BoneCounter}";
        }
    }
}
