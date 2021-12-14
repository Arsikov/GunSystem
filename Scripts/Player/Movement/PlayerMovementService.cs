using UnityEngine;
using PlayerClasses.MovementClasses.InputClasses;
using PlayerClasses.MovementClasses.StateClasses;

namespace PlayerClasses.MovementClasses
{
    public class PlayerMovementService : MonoBehaviour
    {
        [SerializeField] private KeyBindings _keyBindings;

        [SerializeField] private D_PlayerDodgeState D_DodgeState;
        [SerializeField] private D_PlayerWalkState D_WalkState;

        #region Components
        public Camera CameraComponent { private set; get; }
        public PlayerRbController RigidBodyController { private set; get; }
        #endregion

        #region Movement
        public PlayerInputHandler InputHandler { get; private set; }

        private PlayerStateSwitcher _stateSwitcher;

        public PlayerDodgeState _dodgeState;
        public PlayerWalkState _walkState;
        public PlayerIdleState _idleState;
        #endregion

        private void Awake()
        {
            CameraComponent = Camera.main;
            RigidBodyController = new PlayerRbController(GetComponent<Rigidbody2D>());

            InputHandler = new PlayerInputHandler(_keyBindings);
            _stateSwitcher = new PlayerStateSwitcher();

            _dodgeState = new PlayerDodgeState(this, _stateSwitcher, RigidBodyController, InputHandler, D_DodgeState);
            _walkState = new PlayerWalkState(this, _stateSwitcher, RigidBodyController, InputHandler, D_WalkState);
            _idleState = new PlayerIdleState(this, _stateSwitcher, RigidBodyController, InputHandler);

            _stateSwitcher.Initialize(_idleState);
        }

        private void Update()
        {
            InputHandler.HandleInput();
            _stateSwitcher.currentState.Update();
        }

        private void FixedUpdate()
        {
            RotatePlayerToMouse();
            _stateSwitcher.currentState.FixedUpdate();
        }


        private void RotatePlayerToMouse()
        {
            Vector2 lookDir = InputHandler.MousePosition - RigidBodyController.rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            RigidBodyController.SetRotation(angle);
        }
    }
}