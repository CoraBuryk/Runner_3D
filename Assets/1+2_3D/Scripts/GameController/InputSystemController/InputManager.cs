using UnityEngine;
using UnityEngine.InputSystem;


namespace _1_2_3D.Scripts.GameController.InputSystemController
{
    public class InputManager : Singleton<InputManager>
    {

        #region Events
        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnEndTouch;
        #endregion

        private PlayerControls _playerControls;
        private Camera _mainCamera;

        private void Awake()
        {          
            _playerControls = new PlayerControls();
            _mainCamera = Camera.main; 
        }

        private void OnEnable()
        {
            _playerControls.Enable();
        }

        private void OnDisable()
        {
            _playerControls.Disable();
        }

        private void Start()
        {
            _playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
            _playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        }

        private void StartTouchPrimary(InputAction.CallbackContext context)
        {
            if (OnStartTouch != null) 
                OnStartTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        }

        private void EndTouchPrimary(InputAction.CallbackContext context)
        {
            if (OnEndTouch != null) 
                OnEndTouch(Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
        }

        public Vector2 PrimaryPosition()
        {
            return Utils.ScreenToWorld(_mainCamera, _playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}
