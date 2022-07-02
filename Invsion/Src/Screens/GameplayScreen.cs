using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Events;
using Invsion.Engine.Input;

using Invsion.Src.Entities.Ship;

namespace Invsion.Src.Screens
{
    class GameplayScreen : GameScreen
    {
        private PlayerShip player;

        public GameplayScreen (GameServiceContainer services) : base(ScreenName.GAMEPLAY, services) {
            Initialize();
        }



        public override void RegisterInputEventHandlers ()
        {
            player.RegisterInputEventHandlers(InputEventBus);
        }



        public override void UnregisterInputEventHandlers ()
        {
            // Unregister player event handlers
            return;
        }



        public override void Initialize ()
        {
            player = new PlayerShip();
        }



        public override void Start ()
        {
            base.Start();
        }



        public override void LoadContent ()
        {
            player.LoadContent(AssetManager);

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            player.Update(gameTime.ElapsedGameTime.TotalMilliseconds);
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            player.Draw(defaultSpriteBatch);
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
        }
    }
}
