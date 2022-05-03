using _1_2_3D.Scripts.GameController;
using TMPro;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.UI
{
    public class BoneCounterView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _bones;
        [SerializeField] private BoneCounterContoller boneCounterController;

        private void OnEnable()
        {
            boneCounterController.BoneCountChange += HandleCounterDelegate;
        }

        private void OnDisable()
        {
            boneCounterController.BoneCountChange -= HandleCounterDelegate;
        }

        private void Start()
        {
            HandleCounterDelegate();
        }

        public void HandleCounterDelegate()
        {
            _bones.text = $"{boneCounterController.BoneCounter}";
        }
    }
}
