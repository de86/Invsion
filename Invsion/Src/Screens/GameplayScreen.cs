using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Input;

using Invsion.Src.Entities.Ship;

namespace Invsion.Src.Screens
{
    class GameplayScreen : GameScreen
    {
        
        private IInputActionMap _inputActionMap;

        private PlayerShip player;

        public GameplayScreen (GameServiceContainer services) : base(ScreenName.GAMEPLAY, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            player = new PlayerShip();
            _inputActionMap = new InputActionMap();
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        public override void LoadContent ()
        {
            player.LoadContent(AssetManager);

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            return;
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            player.Draw(defaultSpriteBatch);

            return;
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
