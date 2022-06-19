using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Invsion.Src.Input;
using Invsion.Src.Shared;
using Invsion.Src.Shared.Helpers;

namespace Invsion.Src.Screens
{
    class LogoSplashScreen : GameScreen
    {
        private Texture2D _tex_logo;
        private SoundEffect _sfx_intro_jingle;
        private IInputActionMap _inputActionMap;
        private Color _logoColor = new Color (255f, 255f, 255f, 255);
        private float _logoAlpha = 0;
        private float _elapsedTime = 0;
        private bool _hasJinglePlayed = false;



        public LogoSplashScreen (GameServiceContainer services) : base(ScreenName.LOGO_SPLASH, services) {
            Initialize();
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        public override void Initialize ()
        {
            _inputActionMap = new InputActionMap();
            _inputActionMap.BindActionToInput(SkipScreen, Buttons.A);
            _inputActionMap.BindActionToInput(SkipScreen, Keys.Space);
            _inputActionMap.BindActionToInput(PlayJingle, Keys.S);

        }



        public override void LoadContent ()
        {
            _tex_logo = AssetManager.LoadLevelAsset<Texture2D>("Art/LogoWhiteYellow");
            _sfx_intro_jingle = AssetManager.LoadLevelAsset<SoundEffect>("Audio/FX/confirmation_002");

            return;
        }



        // Todo: Find a better way to do "Pre-programmed" sequnces
        public override void Update (GameTime gameTime)
        {
            _increaseAlpha((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (!_hasJinglePlayed &&_logoAlpha >= 1)
            {
                PlayJingle();
                _hasJinglePlayed = true;

            } 

            return;
        }



        private void _increaseAlpha (float deltaTime)
        {
            if (_logoAlpha >= 1)
                return;

            _elapsedTime += deltaTime / 2;
           _logoAlpha = Math.Clamp(_elapsedTime, 0, 1);
        }



        private void SkipScreen ()
        {
            GameScreenService.SetActiveScreen(ScreenName.SPLASH);
        }



        private void PlayJingle ()
        {
            _sfx_intro_jingle.Play();
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
                _logoColor * _logoAlpha
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
    }
}
