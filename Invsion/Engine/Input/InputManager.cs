using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework.Input;

using Invsion.Engine.Errors;
using Invsion.Engine.Events;
using Invsion.Engine.Utilities;

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

        private Keys[] _pressedKeys;
        private List<Keys> _prevPressedKeys;

        private const int PLAYER_ONE = 1;

        // probably should be enum
        public readonly static ushort INPUT_STATE_PRESSED = 1;
        public readonly static ushort INPUT_STATE_RELEASED = 2;


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
            _prevPressedKeys = new List<Keys>();
        }



        public void SetKeyboardControlScheme(IInputControlScheme<Keys> keyboardControlScheme)
        {
            _keyboardControlScheme = keyboardControlScheme;
        }



        public void ProcessInput ()
        {
            keyboardState = Keyboard.GetState();
            gamePadState = GamePad.GetState(PLAYER_ONE);

            _pressedKeys = keyboardState.GetPressedKeys();

            _processInputs();

            previousKeyboardState = keyboardState;
            previousGamePadState = gamePadState;
        }



        private void _processInputs ()
        {
            Keys[] keysToCheck = Utils.GetCombinedArray<Keys>(_pressedKeys, _prevPressedKeys.ToArray());

            foreach (Keys key in keysToCheck)
            {
                if (key.Equals(Keys.None))
                    continue;

                _processInput(key);
            }
        }



        private void _processInput (Keys key)
        {
            if (_keyIsNewlyPressed(key))
            {
                string action = _keyboardControlScheme.GetActionForInput(key);
                _prevPressedKeys.Add(key);
                _eventBus.InvokeInputEvent(this, action, INPUT_STATE_PRESSED);
            }
            else if (_keyIsReleased(key))
            {
                string action = _keyboardControlScheme.GetActionForInput(key);
                _prevPressedKeys.Remove(key);
                _eventBus.InvokeInputEvent(this, action, INPUT_STATE_RELEASED);
            }
        }



        private bool _keyIsNewlyPressed (Keys key)
        {
            int prevPressedKeyIndex = Array.IndexOf(_prevPressedKeys.ToArray(), key);

            return prevPressedKeyIndex < 0;
        }


        private bool _keyIsReleased (Keys key)
        {
            int pressedKeyIndex = Array.IndexOf(_pressedKeys, key);

            return pressedKeyIndex < 0;
        }
    }
}
