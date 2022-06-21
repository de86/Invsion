using System;
using System.Collections.Generic;
using System.Text;

using Invsion.Src.Input;
using Invsion.Src.Shared;
using Invsion.Src.Shared.Helpers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Invsion.Src.Screens
{
    class TitleScreen : GameScreen
    {
        private Texture2D _tex_logo;
        private IInputActionMap _inputActionMap;
        private Color color = Color.White;



        public TitleScreen (GameServiceContainer services) : base(ScreenName.TITLE, services) {
            Initialize();
        }


        public override void Initialize ()
        {
            // Load Texture
            _inputActionMap = new InputActionMap();
            _inputActionMap.BindActionToInput(SkipScreen, Buttons.A);
            _inputActionMap.BindActionToInput(SkipScreen, Keys.Space);
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        private void SkipScreen ()
        {
            GameScreenService.SetActiveScreen(ScreenName.SPLASH);
        }



        public override void LoadContent ()
        {
            _tex_logo = AssetManager.LoadLevelAsset<Texture2D>("Art/ship_L");
            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            return;
        }




        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            defaultSpriteBatch.Draw(
                _tex_logo,
                RenderHelpers.ScreenCentre(
                    _tex_logo,
                    SettingsManager.GetSettingValue<int>("RESOLUTION_WIDTH"),
                    SettingsManager.GetSettingValue<int>("RESOLUTION_HEIGHT")
                ),
                color);

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
