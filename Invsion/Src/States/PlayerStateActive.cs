using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Assets;
using Invsion.Engine.Components;
using Invsion.Engine.Events;
using Invsion.Engine.Input;
using Invsion.Engine.State;

using Invsion.Src.Constants;

namespace Invsion.Src.States
{
    class PlayerStateActive : IFSMState
    {
        private float _maxMoveSpeed;

        private Vector2 _currentDirection;
        private IInputEventBus _inputEventBus;
        private Position _position;
        private IPositionAccelerator _positionAccelerator;
        private Texture2D _playerShipTexture;



        public PlayerStateActive (
            IInputEventBus inputEventBus,
            Position position,
            IPositionAccelerator positionAccelerator,
            Texture2D playerShipTexture,
            float maxMoveSpeed
        )
        {
            _inputEventBus = inputEventBus;
            _position = position;
            _positionAccelerator = positionAccelerator;
            _playerShipTexture = playerShipTexture;
            _maxMoveSpeed = maxMoveSpeed;
        }



        public void Enter ()
        {
            RegisterInputEventHandlers();
        }



        public void RegisterInputEventHandlers ()
        {
            _inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_LEFT,  _onMoveLeft);
            _inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_RIGHT, _onMoveRight);
            _inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_UP,    _onMoveUp);
            _inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_DOWN,  _onMoveDown);
        }



        public void _onMoveLeft (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentDirection.X -= 1;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentDirection.X += 1;
            }
        }



        public void _onMoveRight (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentDirection.X += 1;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentDirection.X -= 1;
            }
        }



        public void _onMoveDown (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentDirection.Y += 1;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentDirection.Y -= 1;
            }
        }



        public void _onMoveUp (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentDirection.Y -= 1;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentDirection.Y += 1;
            }
        }



        public void Update (double deltaMS)
        {
            float delta = (float)deltaMS / 1000;
            _positionAccelerator.AccelerateAndMove(_currentDirection, _maxMoveSpeed, delta);
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _playerShipTexture,
                _position.GetPosition(),
                Color.White
            );
        }



        public void Exit ()
        {
            UnregisterInputEventHandlers();
        }



        public void UnregisterInputEventHandlers ()
        {
            _inputEventBus.UnsubscribeFromEvent(INPUT_ACTIONS.MOVE_LEFT,  _onMoveLeft);
            _inputEventBus.UnsubscribeFromEvent(INPUT_ACTIONS.MOVE_RIGHT, _onMoveRight);
            _inputEventBus.UnsubscribeFromEvent(INPUT_ACTIONS.MOVE_UP,    _onMoveUp);
            _inputEventBus.UnsubscribeFromEvent(INPUT_ACTIONS.MOVE_DOWN, _onMoveDown);
        }
    }
}
