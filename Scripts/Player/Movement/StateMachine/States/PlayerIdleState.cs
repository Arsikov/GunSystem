using UnityEngine;
using PlayerClasses.MovementClasses.InputClasses;

namespace PlayerClasses.MovementClasses.StateClasses
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerMovementService playerMovementService, PlayerStateSwitcher stateSwitcher, PlayerRbController rbController, PlayerInputHandler inputHandler) : base(playerMovementService, stateSwitcher, rbController, inputHandler)
        {
        }

        public override void Enter()
        {
            base.Enter();

            rbController.SetVelocity(Vector2.zero);
        }

        public override void Update()
        {
            base.Update();

            if (inputHandler.WalkDirection != Vector2.zero)
            {
                SwitchState(playerMovementService.walkState);
            }
        }
    }
}
