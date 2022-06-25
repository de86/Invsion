using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Invsion.Src.Input;
using Invsion.Src.Shared;
using Invsion.Src.Shared.Helpers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Invsion.Src.Shared.Graphics;
using Invsion.Src.Shared.Utilities;

namespace Invsion.Src.Screens
{
    class PlayScreen : GameScreen
    {
        private Texture2D _playerShipTexture;
        private IInputActionMap _inputActionMap;

        private int RESOLUTION_WIDTH;
        private int RESOLUTION_HEIGHT;



        public PlayScreen (GameServiceContainer services) : base(ScreenName.PLAY, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            RESOLUTION_WIDTH = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_WIDTH);
            RESOLUTION_HEIGHT = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_HEIGHT);

            _inputActionMap = new InputActionMap();
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        public override void LoadContent ()
        {
            _playerShipTexture = AssetManager.LoadLevelAsset<Texture2D>("Art/ship_L");

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            return;
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            defaultSpriteBatch.Draw(
                _playerShipTexture,
                new Vector2(100, 100),
                Color.White
            );

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
