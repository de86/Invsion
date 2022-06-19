using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace Invsion.Src.Input
{
    class InputManager : IInputManager
    {
        private IInputActionMap _activeInputActionMap;
        private List<Buttons> _pressedButtons;

        KeyboardState keyboardState;
        KeyboardState previousKeyboardState;

        GamePadState gamePadState;
        GamePadState previousGamePadState;
        // Move this out into keyboard/gamepad implemenations
        private Array _allButtons;
        private Array _allKeys;



        public InputManager ()
        {
            _allButtons = Enum.GetValues(typeof(Buttons));
            _allKeys = Enum.GetValues(typeof(Keys));
        }



        public void SetActiveInputActionMap(IInputActionMap activeInputActionMap)
        {
            _activeInputActionMap = activeInputActionMap;
        }



        public void ProcessInput ()
        {
            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(1);

            _processPressedButtons();
            _processPressedKeys();

            previousKeyboardState = keyboardState;
            previousGamePadState = gamePadState;
        }



        private void _processPressedButtons ()
        {
            foreach (Buttons button in _allButtons)
            {
                if (gamePadState.IsButtonDown(button))
                {
                    _activeInputActionMap.ExecuteActionForInput(button);
                }
            }
        }


        private void _processPressedKeys ()
        {
            foreach (Keys key in _allKeys)
            {
                if (keyboardState.IsKeyDown(key))
                {
                    _activeInputActionMap.ExecuteActionForInput(key);
                }
            }
        }
    }
}
