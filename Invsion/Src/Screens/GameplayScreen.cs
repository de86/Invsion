using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Components;
using Invsion.Engine.Events;
using Invsion.Engine.Input;
using Invsion.Engine.Utilities;

using Invsion.Src.Constants;
using Invsion.Src.Entities.Ship;

namespace Invsion.Src.Screens
{
    class GameplayScreen : GameScreen
    {
        private int _playerStartPositionX = 900;
        private int _playerStartPositionY = 900;

        private const int WORLD_BOUNDARY_WIDTH = 800;
        private const int WORLD_BOUNDARY_HEIGHT = 1080;
        
        private PlayerShip _player;
        private Rect _worldBoundary;



        public GameplayScreen (GameServiceContainer services) : base(ScreenName.GAMEPLAY, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            _player = new PlayerShip(InputEventBus, _playerStartPositionX, _playerStartPositionY);

            _worldBoundary = new Rect(Vector2.Zero, WORLD_BOUNDARY_WIDTH, WORLD_BOUNDARY_HEIGHT);
            _worldBoundary.CenterPositionAt(
                SettingsManager.GetSetting(SETTINGS.RESOLUTION_WIDTH).GetParsedValue<int>() / 2,
                SettingsManager.GetSetting(SETTINGS.RESOLUTION_HEIGHT).GetParsedValue<int>() / 2
            );
        }



        public override void RegisterInputEventHandlers ()
        {
            
        }



        public override void UnregisterInputEventHandlers ()
        {
            // Unregister _player event handlers
            return;
        }



        public override void Start ()
        {
            base.Start();
        }



        public override void LoadContent ()
        {
            _player.LoadContent(AssetManager);

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            _player.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
            _constrainPositionToWorldBounds(_player.boundingBox);
        }



        private void _constrainPositionToWorldBounds (Rect playerBoundingBox)
        {;
            if (playerBoundingBox.Right() > _worldBoundary.Right())
            {
                playerBoundingBox.SetRight(_worldBoundary.Right());
            }
            else if (playerBoundingBox.Left() < _worldBoundary.Left())
            {
                playerBoundingBox.SetLeft(_worldBoundary.Left());
            }

            if (playerBoundingBox.Top() < _worldBoundary.Top())
            {
                playerBoundingBox.SetTop(_worldBoundary.Top());
            }
            else if (playerBoundingBox.Bottom() > _worldBoundary.Bottom())
            {
                playerBoundingBox.SetBottom(_worldBoundary.Bottom());
            }
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _player.Draw(defaultSpriteBatch);
        }



        public override void DebugDraw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _player.DebugDraw(defaultSpriteBatch, GraphicsDevice);
            DebugUtils.DrawRect(defaultSpriteBatch, GraphicsDevice, _worldBoundary);
        }



        public override void Pause ()
        {
            return;
        }



        public override void Resume ()
        {
            return;
        }



        public override void Reset ()
        {
            return;
        }



        public override void Exit ()
        {
            base.Exit();
            // exit statemachines unregister event handlers
        }
    }
}
