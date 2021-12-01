using UnityEngine;
using PlayerClasses.MovementClasses.InputClasses;

namespace PlayerClasses.MovementClasses.StateClasses
{
    public class PlayerWalkState : PlayerState
    {
        private D_PlayerWalkState data;

        public PlayerWalkState(PlayerMovementService playerMovementService, PlayerStateSwitcher stateSwitcher, PlayerRbController rbController, PlayerInputHandler inputHandler, D_PlayerWalkState data) : base(playerMovementService, stateSwitcher, rbController, inputHandler)
        {
            this.data = data;
        }

        public override void Update()
        {
            base.Update();

            if (inputHandler.WalkDirection == Vector2.zero)
            {
                SwitchState(playerMovementService.idleState);
            }
            if (inputHandler.DodgeInput && playerMovementService.dodgeState.AbleToDodge())
            {
                SwitchState(playerMovementService.dodgeState);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            Walk();
        }

        private void Walk()
        {
            rbController.SetVelocity(inputHandler.WalkDirection * data.Speed);
        }
    }
}
