using UnityEngine;
using UnityEngine.InputSystem;

namespace _1_2_3D.Scripts.GameController.InputSystemController
{
    public class SwipeDetection : MonoBehaviour
    {
        [SerializeField] private float _minimumDistance = 0.01f;
        [SerializeField] private float _maximumTime = 1f;
        [SerializeField] private PlayerMovementController _playerMovementController;
        private InputManager _inputManager;
        private Vector2 _startPosition;
        private float _startTime;
        private Vector2 _endPosition;
        private float _endTime;

        private void Awake()
        {
            _inputManager = InputManager.Instance;
        }

        private void OnEnable()
        {
            _inputManager.OnStartTouch += SwipeStart;
            _inputManager.OnEndTouch += SwipeEnd;

        }
        private void OnDisable()
        {
            _inputManager.OnStartTouch -= SwipeStart;
            _inputManager.OnEndTouch -= SwipeEnd;
        }

        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if(Vector3.Distance(_startPosition,_endPosition) >= _minimumDistance &&
               (_endTime - _startTime) <= _maximumTime)
            {
                Vector3 direction = _endPosition - _startPosition;
                Vector2 direction2D = new Vector2(direction.x,direction.y).normalized;
                _playerMovementController.SwipeDirection(direction2D);              
            }
        }
    }
}
