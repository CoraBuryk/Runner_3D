using _1_2_3D.Scripts.ViewController.Animations;
using _1_2_3D.Scripts.ViewController.Audio;
using _1_2_3D.Scripts.ViewController.Menu;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private GameObject _examplePrefab;
        [SerializeField] private GameplayController _gameplayController;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private SceneBehavior _sceneBehavior;
        [SerializeField] private AudioEffectsMainScene _audioEffects;
        [SerializeField] private float _lineDistance = 1.5f;
        [SerializeField, Range(0f, 1f)] private float _directionThreshold = 0.65f;
        public float Speed { get; set; } = 10;
        public bool IsStop { get; set; } = false;

        private CharacterController _characterController;
        private Vector3 _direction;
        private int _lineToMove = 1;
        private float _jumpForce = 10f;
        private float _gravity = -20;
        private bool _isGrounded = true;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            Time.timeScale = 1;
            _examplePrefab.SetActive(false);
            _playerAnimator.ForRun();
            TotalTimeController.ResetTotalTime();
        }

        private void Update()
        {
            PlayerDirection();
        }

        public void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > _directionThreshold && IsStop != true && _isGrounded == true)
            {
                Jump();
            }
            if (Vector2.Dot(Vector2.right, direction) > _directionThreshold && IsStop != true)
            {
                if (_lineToMove < 2)
                    _lineToMove++;
            }
            if (Vector2.Dot(Vector2.left, direction) > _directionThreshold && IsStop != true)
            {
                if (_lineToMove > 0)
                    _lineToMove--;
            }
        }

        public void PlayerDirection()
        {
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            if (_lineToMove == 0)
                targetPosition += Vector3.left * _lineDistance;
            else if (_lineToMove == 2)
                targetPosition += Vector3.right * _lineDistance;

            if (transform.position == targetPosition)
                return;
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.sqrMagnitude)
                _characterController.Move(moveDir);
            else
                _characterController.Move(diff);
        }

        public void Jump()
        {
            _audioEffects.PlayJump();
            _direction.y = _jumpForce;
            _playerAnimator.Jumping();
            _isGrounded = false;
        }

        private void FixedUpdate()
        {
            _direction.z = Speed;
            _direction.y += _gravity * Time.deltaTime;
            _characterController.Move(_direction * Time.fixedDeltaTime);
        }

        private void OnControllerColliderHit(ControllerColliderHit hit)
        {
            if (hit.gameObject.tag == "Obstacle")
            {
                _audioEffects.PlayObstacle();
                _sceneBehavior.ZeroHealth();
                _healthController.HealthDecreased();
                Destroy(hit.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Bone")
            {
                _audioEffects.PlayBone();
                BoneCounterContoller.ChangeNumberOfBone(BoneCounterContoller.BoneCounter += 1);
                other.gameObject.SetActive(false);
            }

            if (other.gameObject.tag == "Door")
            {
                _examplePrefab.SetActive(true);
                _gameplayController.ActivateTimer();
                Speed = 0;
                _playerAnimator.ForBreak();
                IsStop = true;
            }

            if (other.gameObject.tag == "Floor")
            {
                _isGrounded = true;
            }
                
        }
    }
}
