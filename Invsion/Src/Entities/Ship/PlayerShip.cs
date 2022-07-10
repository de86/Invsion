using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Assets;
using Invsion.Engine.Components;
using Invsion.Engine.Events;
using Invsion.Engine.Input;
using Invsion.Engine.State;
using Invsion.Engine.Utilities;

using Invsion.Src.Constants;
using Invsion.Src.States;

namespace Invsion.Src.Entities.Ship
{
    class PlayerShip
    {
        // Guns[]
        // Ability to fire
        // Ability to change weapons
        // Finite State Machine
        // Animations

        private int _maxHealth;
        private int _maxShield;
        private float _acceleration = 200;
        private float _decelerationRate = 0.2f;
        private float _maxMoveSpeed = 750;

        private IHealthComponent _health;
        private IHealthComponent _shield;
        private IInputEventBus _inputEventBus;
        private IFiniteStateMachine _stateMachine;
        private Texture2D _playerShipTexture;
        public Rect boundingBox;
        private IPositionAccelerator positionAccelerator;
        private Vector2 _boundingBoxPositionOffset = new Vector2(22.5f, 22.5f);

        public Position position;



        public PlayerShip (IInputEventBus inputEventBus, int _startPositionX, int _startPositionY)
        {
            _inputEventBus = inputEventBus;
            _health = new HealthComponent(_maxHealth);
            _shield = new HealthComponent(_maxShield);

            position = new Position(_startPositionX, _startPositionY);
            positionAccelerator = new PositionAccelerator(position, _acceleration, _decelerationRate);
            boundingBox = new Rect(position, 80, 80, _boundingBoxPositionOffset);

            _stateMachine = new FiniteStateMachine();
        }



        public void LoadContent (IAssetManager AssetManager)
        {
            _playerShipTexture = AssetManager.LoadLevelAsset<Texture2D>(ASSETS.TEXTURE_PLAYER_SHIP);

            _stateMachine.AddState(
                "active",
                new PlayerStateActive(
                    _inputEventBus,
                    position,
                    positionAccelerator,
                    _playerShipTexture,
                    _maxMoveSpeed
                )
            );

            _stateMachine.SetInitialState("active");
        }



        public void Update (double deltaMS)
        {
            _stateMachine.Update(deltaMS);
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            _stateMachine.Draw(spriteBatch);
        }



        public void DebugDraw (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            DebugUtils.DrawRect(spriteBatch, graphicsDevice, boundingBox);
        }
    }
}
