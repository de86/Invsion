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

using Invsion.Src.Constants;
using Invsion.Src.Entities.Ship;

namespace Invsion.Src.Screens
{
    class GameplayScreen : GameScreen
    {
        private int _playerStartPositionX = 900;
        private int _playerStartPositionY = 900;
        private PlayerShip _player;
        private SimpleRect _worldBoundary;



        public GameplayScreen (GameServiceContainer services) : base(ScreenName.GAMEPLAY, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            _player = new PlayerShip(InputEventBus, _playerStartPositionX, _playerStartPositionY);

            _worldBoundary = new SimpleRect(0, 0, 500, 1080);
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
            _constrainPositionToWorldBounds(_player.position);
        }



        private void _constrainPositionToWorldBounds (IPositionComponent entityPositionComponent)
        {
            Vector2 entityPosition = entityPositionComponent.GetPosition();
            if (entityPosition.X > _worldBoundary.Right())
            {
                entityPosition.X = _worldBoundary.Right();
            }
            else if (entityPosition.X < _worldBoundary.Left())
            {
                entityPosition.X = _worldBoundary.Left();
            }

            if (entityPosition.Y < _worldBoundary.Top())
            {
                entityPosition.Y = _worldBoundary.Top();
            }
            else if (entityPosition.Y > _worldBoundary.Bottom())
            {
                entityPosition.Y = _worldBoundary.Bottom();
            }

            entityPositionComponent.SetPosition(entityPosition);
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _player.Draw(defaultSpriteBatch);
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
