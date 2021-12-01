using UnityEngine;

namespace PlayerClasses.MovementClasses.InputClasses
{
    public class PlayerInputHandler
    {
        public bool DodgeInput { get; private set; }
        public Vector2 WalkDirection { get; private set; }
        public Vector2 MousePosition { get; private set; }


        private KeyBindings keyBindings;

        public PlayerInputHandler(KeyBindings keyBindings)
        {
            this.keyBindings = keyBindings;
        }

        public void HandleInput()
        {
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            DodgeInput = Input.GetKeyDown(GetKeyAction(KeyActions.Dodge));
            #region WalkDirection
            WalkDirection = new Vector2
                (
                    GetMovementAxisInput
                    (
                        GetKeyAction(KeyActions.MoveRight), GetKeyAction(KeyActions.MoveLeft)
                    ),

                    GetMovementAxisInput
                    (
                        GetKeyAction(KeyActions.MoveUp), GetKeyAction(KeyActions.MoveDown)
                    )
                );
            #endregion
        }

        private float GetMovementAxisInput(KeyCode posAction, KeyCode negAction)
        {
            float posValue, negValue;
            
            if (Input.GetKey(posAction)) posValue = 1;
            else posValue = 0; 

            if (Input.GetKey(negAction)) negValue = 1;
            else negValue = 0;

            return posValue - negValue;
        }

        private KeyCode GetKeyAction(KeyActions action)
        {
            foreach (KeyBindings.KeyBindingValue check in keyBindings.values)
            {
                if (check.action == action) return check.keyCode;
            }

            return KeyCode.None;
        }
    }
}