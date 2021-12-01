using UnityEngine;
using System;
using PlayerClasses.MovementClasses.InputClasses;
using PlayerClasses.MovementClasses.StateClasses;

namespace PlayerClasses.MovementClasses
{
    public class PlayerMovementService : MonoBehaviour
    {
        [SerializeField] private KeyBindings keyBindings;

        [SerializeField] private D_PlayerDodgeState D_DodgeState;
        [SerializeField] private D_PlayerWalkState D_WalkState;

        #region Components
        public Camera cam { private set; get; }
        public PlayerRbController rbController { private set; get; }
        #endregion

        #region Movement
        public PlayerInputHandler inputHandler { get; private set; }
        private PlayerStateSwitcher stateSwitcher;

        public PlayerDodgeState dodgeState;
        public PlayerWalkState walkState;
        public PlayerIdleState idleState;
        #endregion

        private void Awake()
        {
            cam = Camera.main;
            rbController = new PlayerRbController(GetComponent<Rigidbody2D>());

            inputHandler = new PlayerInputHandler(keyBindings);
            stateSwitcher = new PlayerStateSwitcher();

            dodgeState = new PlayerDodgeState(this, stateSwitcher, rbController, inputHandler, D_DodgeState);
            walkState = new PlayerWalkState(this, stateSwitcher, rbController, inputHandler, D_WalkState);
            idleState = new PlayerIdleState(this, stateSwitcher, rbController, inputHandler);

            stateSwitcher.Initialize(idleState);
        }

        private void Start()
        {
        }

        private void Update()
        {
            inputHandler.HandleInput();
            stateSwitcher.currentState.Update();
        }

        private void FixedUpdate()
        {
            RotatePlayerToMouse();
            stateSwitcher.currentState.FixedUpdate();
        }
        #region SideMethod
        private void RotatePlayerToMouse()
        {
            Vector2 lookDir = inputHandler.MousePosition - rbController.rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            rbController.SetRotation(angle);
        }
        #endregion
    }
}