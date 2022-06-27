using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework.Input;

using Invsion.Engine.Utilities;

namespace Invsion.Engine.Input
{
    class InputManager : IInputManager
    {
        private EventBus _eventBus;

        //private IInputActionMap _activeInputActionMap;
        private List<Buttons> _pressedButtons;
        private List<Keys> _pressedKeys;

        private Dictionary<string, string> __actionKeyBinds;

        KeyboardState keyboardState;
        KeyboardState previousKeyboardState;

        GamePadState gamePadState;
        GamePadState previousGamePadState;
        
        // Move this out into keyboard/gamepad implemenations
        private Array _allButtons;
        private Array _allKeys;

        public InputManager (EventBus eventBus)
        {
            _eventBus = eventBus;
            _allButtons = Enum.GetValues(typeof(Buttons));
            _allKeys = Enum.GetValues(typeof(Keys));
            __actionKeyBinds = new Dictionary<string, string>(){
                { "F", "SkipScreen" }
            };
        }



        public void SetActiveInputActionMap(IInputActionMap activeInputActionMap)
        {
            //_activeInputActionMap = activeInputActionMap;
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
                    //_activeInputActionMap.ExecuteActionForInput(button);
                }
            }
        }



        private void _processPressedKeys ()
        {
            foreach (Keys key in _allKeys)
            {
                if (keyboardState.IsKeyDown(key))
                {
                    // Not going to work for both keyboard and pad support due to oduplicated inputs.
                    // Keyboard A and Controller A for example.
                    string action;
                    __actionKeyBinds.TryGetValue(key.ToString(), out action);
                    // Probably needs to be moved into a proper command structure
                    _eventBus.InputPressed.Invoke(this, action);
                }
            }
        }
    }
}
