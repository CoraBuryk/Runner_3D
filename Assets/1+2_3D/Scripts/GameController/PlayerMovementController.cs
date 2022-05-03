using _1_2_3D.Scripts.GameController;
using _1_2_3D.Scripts.ViewController.Animations;
using _1_2_3D.Scripts.ViewController.Menu;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private BoneCounterContoller _boneCounterController;
    [SerializeField] private GameObject _examplePrefab;
    [SerializeField] private LevelController _levelController;
    [SerializeField] private GameplayController _gameplayController;
    [SerializeField] private HealthController _healthController;
    [SerializeField] private TimerController _timerController;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private SceneBehavior _sceneBehavior;
    [SerializeField] private AudioEffects _audioEffects;
    [SerializeField] private float lineDistance = 4;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = 0.9f;
    private CharacterController _characterController;
    private Vector3 _direction;
    public int lineToMove = 1;
    private float _jumpForce = 10;
    private float _gravity = -20;
    public float Speed  = 10;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        Time.timeScale = 1;
        _examplePrefab.SetActive(false);
        _playerAnimator.ForRun();
        _timerController.ResetTotalTime();
    }



    private void Update()
    {
        //SwipeSwipeController();
        PlayerDir();
    }

    /*public void SwipeSwipeController()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (_characterController.isGrounded)
                Jump();
        }
    }*/

    public void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
                Jump();

            Debug.Log(_characterController.isGrounded);
            Debug.Log("swipe up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("swipe down");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            if (lineToMove < 2)
                lineToMove++;
            Debug.Log("swipe right");
            Debug.Log(_characterController.isGrounded);
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            if (lineToMove > 0)
                lineToMove--;
            Debug.Log("swipe left");
        }
    }

    public void PlayerDir()
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

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
        Debug.Log(_characterController.isGrounded);
        _playerAnimator.Jumping();
    }

    private void FixedUpdate()
    {
        _direction.z = Speed;
        _direction.y += _gravity * Time.fixedDeltaTime;
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
            _boneCounterController.ChangeNumberOfBone(_boneCounterController.BoneCounter += 1);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Door")
        {
            _audioEffects.PlayMainOff();
            _audioEffects.PlayExample();
            _examplePrefab.SetActive(true);
            _gameplayController.ActivateTimer();
            Speed = 0;
            _playerAnimator.ForBreak();
        }
    } 
}
