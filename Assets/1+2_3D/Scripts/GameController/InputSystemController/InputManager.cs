using UnityEngine;
using UnityEngine.InputSystem;


namespace _1_2_3D.Scripts.GameController.InputSystemController
{
    [DefaultExecutionOrder(-1)]
    public class InputManager : Singleton<InputManager>
    {

        #region Events
        public delegate void StartTouch(Vector2 position, float time);
        public event StartTouch OnStartTouch;
        public delegate void EndTouch(Vector2 position, float time);
        public event StartTouch OnEndTouch;
        #endregion

        private PlayerControls playerControls;
        private Camera mainCamera;

        private void Awake()
        {
                      
            playerControls = new PlayerControls();
            mainCamera = Camera.main; 
        }

        private void OnEnable()
        {
            playerControls.Enable();
        }

        private void OnDisable()
        {
            playerControls.Disable();
        }

        private void Start()
        {
            playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
            playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
        }

        private void StartTouchPrimary(InputAction.CallbackContext context)
        {
            if (OnStartTouch != null) 
                OnStartTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.startTime);
        }

        private void EndTouchPrimary(InputAction.CallbackContext context)
        {
            if (OnEndTouch != null) 
                OnEndTouch(Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
        }

        public Vector2 PrimaryPosition()
        {
            return Utils.ScreenToWorld(mainCamera, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
        }
    }
}
