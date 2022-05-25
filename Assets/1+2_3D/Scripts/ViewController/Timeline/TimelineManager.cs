using UnityEngine;
using UnityEngine.Playables;

namespace _1_2_3D.Scripts.ViewController.Timeline
{
    public class TimelineManager : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private RuntimeAnimatorController _playerControl;
        [SerializeField] private PlayableDirector _playableDirector;

        private bool _fix = false;

        private void OnEnable()
        {
            _playerControl = _playerAnimator.runtimeAnimatorController;
            _playerAnimator.runtimeAnimatorController = null;
        }

        private void Update()
        {
            if(_playableDirector.state != PlayState.Playing && !_fix)
            {
                _fix = true;
                _playerAnimator.runtimeAnimatorController = _playerControl;
            }
        }
    }
}
