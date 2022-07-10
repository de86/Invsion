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

        private const int WORLD_BOUNDARY_WIDTH = 1000;
        private const int WORLD_BOUNDARY_HEIGHT = 700;
        
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
                SettingsManager.GetSetting(SETTINGS.RESOLUTION_HEIGHT).GetParsedValue<int>() - WORLD_BOUNDARY_HEIGHT / 2
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
            Utils.ConstrainPositionToWorldBounds(_player.boundingBox, _worldBoundary);
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
