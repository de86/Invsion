using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine.Assets;
using Invsion.Engine.Components;
using Invsion.Engine.Events;
using Invsion.Engine.Input;

using Invsion.Src.Constants;

namespace Invsion.Src.Entities.Ship
{
    class PlayerShip
    {
        // Ability to move
        // Guns[]
        // Ability to fire
        // Ability to change weapons
        // Finite State Machine
        // Animations

        private int _maxHealth;
        private int _maxShield;
        private float _maxMoveSpeed = 10;
        private Vector2 _currentVelocity = Vector2.Zero;

        private IHealthComponent _health;
        private IHealthComponent _shield;
        private IPositionComponent _position;

        private Texture2D _playerShipTexture;

        public PlayerShip ()
        {
            _health = new HealthComponent(_maxHealth);
            _shield = new HealthComponent(_maxShield);
            // Starting position probably should be passed in
            _position = new PositionComponent(new Vector2(900, 900));
        }



        public void LoadContent (IAssetManager AssetManager)
        {
            _playerShipTexture = AssetManager.LoadLevelAsset<Texture2D>(ASSETS.TEXTURE_PLAYER_SHIP);
        }



        public void RegisterInputEventHandlers (IInputEventBus inputEventBus)
        {
            inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_LEFT, _onMoveLeft);
            inputEventBus.SubscribeToEvent(INPUT_ACTIONS.MOVE_RIGHT, _onMoveRight);
        }



        public void Update (double deltaMS)
        {
            float delta = (float)deltaMS / 1000;
            UpdatePosition(delta);
        }



        public void UpdatePosition (float delta)
        {
            _position.Translate(_currentVelocity.X * delta, _currentVelocity.Y);
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _playerShipTexture,
                _position.GetPosition(),
                Color.White
            );
        }        



        public void _onMoveLeft (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            Debug.WriteLine(inputState);
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentVelocity.X = -_maxMoveSpeed;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentVelocity.X = 0;
            }
        }


        public void _onMoveRight (object source, object rawInputState)
        {
            ushort inputState = (ushort)rawInputState;
            Debug.WriteLine(inputState);
            if (inputState == InputManager.INPUT_STATE_PRESSED)
            {
                _currentVelocity.X = _maxMoveSpeed;
            }
            else if (inputState == InputManager.INPUT_STATE_RELEASED)
            {
                _currentVelocity.X = 0;
            }
        }
    }
}
