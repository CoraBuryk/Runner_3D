using DG.Tweening;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.Animations
{
    public class BoneAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _boneRectTransform;

        private void Awake()
        {
            BoneBehavior();
        }

        public void BoneBehavior()
        {
            if (_boneRectTransform == null)
                _boneRectTransform.DOKill();
            _boneRectTransform.DOLookAt(new Vector3(Random.Range(0f, 180f), Random.Range(0f, 360f), Random.Range(0f, 180f)), 30f).SetLoops(100);
        }
    }
}
