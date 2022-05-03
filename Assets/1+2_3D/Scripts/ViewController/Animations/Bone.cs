using DG.Tweening;
using UnityEngine;

namespace _1_2_3D.Scripts.ViewController.Animations
{
    public class Bone : MonoBehaviour
    {
        [SerializeField] private RectTransform _boneRectTransform;

        private void Awake()
        {
            BoneAnimation();
        }

        public void BoneAnimation()
        {
            if (_boneRectTransform == null)
                _boneRectTransform.DOKill();

            _boneRectTransform.DOBlendableRotateBy(new Vector3(Random.Range(0f, 2f), Random.Range(0f, 360f), Random.Range(0f, 10f)), 30f).SetLoops(100);
        }
    }
}
