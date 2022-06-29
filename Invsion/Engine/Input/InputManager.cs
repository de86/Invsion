using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework.Input;

using Invsion.Engine.Errors;
using Invsion.Engine.Events;

namespace Invsion.Engine.Input
{
    public class InputManager : IInputManager
    {
        private InputEventBus _eventBus;

        private IInputControlScheme<Keys> _keyboardControlScheme;

        private KeyboardState keyboardState;
        private KeyboardState previousKeyboardState;

        private GamePadState gamePadState;
        private GamePadState previousGamePadState;
        
        private Array _allButtons;
        private Array _allKeys;

        private const int PLAYER_ONE = 1;



        private static InputManager _INSTANCE
        {
            get
            {
                if (_INSTANCE == null)
                {
                    throw new SingletonNotInitializedException("GameScreenService");
                }
                else
                {
                    return _INSTANCE;
                }
            }
        }



        public InputManager (InputEventBus eventBus, IInputControlScheme<Keys> keyboardControlScheme)
        {
            _eventBus = eventBus;
            _keyboardControlScheme = keyboardControlScheme;

            _allButtons = Enum.GetValues(typeof(Buttons));
            _allKeys = Enum.GetValues(typeof(Keys));
        }



        public void SetKeyboardControlScheme(IInputControlScheme<Keys> keyboardControlScheme)
        {
            _keyboardControlScheme = keyboardControlScheme;
        }



        public void ProcessInput ()
        {
            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PLAYER_ONE);

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
                    Debug.WriteLine("Controller input not yest supported");
                }
            }
        }



        private void _processPressedKeys ()
        {
            foreach (Keys key in _allKeys)
            {
                if (keyboardState.IsKeyDown(key))
                {
                    string action = _keyboardControlScheme.GetActionForInput(key);
                    _eventBus.InvokeInputEvent(this, action);
                }
            }
        }
    }
}
