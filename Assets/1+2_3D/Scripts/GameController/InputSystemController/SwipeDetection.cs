using System.Collections;
using UnityEngine;

namespace _1_2_3D.Scripts.GameController.InputSystemController
{
    public class SwipeDetection : MonoBehaviour
    {
        [SerializeField] private float minimumDistance = 0.1f; //0.2f
        [SerializeField] private float maximumTime = 1f;
        [SerializeField] private GameObject trail;
        [SerializeField] private PlayerMovementController playerMovementController;
        private InputManager inputManager;

        private Vector2 startPosition;
        private float startTime;
        private Vector2 endPosition;
        private float endTime;

        private Coroutine coroutine;

        private void Awake()
        {
            inputManager = InputManager.Instance;
        }

        private void OnEnable()
        {
            inputManager.OnStartTouch += SwipeStart;
            inputManager.OnEndTouch += SwipeEnd;

        }
        private void OnDisable()
        {
            inputManager.OnStartTouch -= SwipeStart;
            inputManager.OnEndTouch -= SwipeEnd;
        }

        private void SwipeStart(Vector2 position, float time)
        {
            startPosition = position;
            startTime = time;
            trail.SetActive(true);
            trail.transform.position = position;
            coroutine = StartCoroutine(Trail());
        }

        private IEnumerator Trail()
        {
            while (true)
            {
                trail.transform.position = inputManager.PrimaryPosition();
                yield return null;
            }
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            trail.SetActive(false);
            StopCoroutine(coroutine);
            endPosition = position;
            endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if(Vector3.Distance(startPosition,endPosition) >= minimumDistance &&
               (endTime - startTime) <= maximumTime)
            {
                Debug.Log("swipe");
                Vector3 direction = endPosition - startPosition;
                Vector2 direction2D = new Vector2(direction.x,direction.y).normalized;
                playerMovementController.SwipeDirection(direction2D);
                
            }
        }
    }
}
