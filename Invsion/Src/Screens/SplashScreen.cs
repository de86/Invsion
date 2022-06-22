﻿using System;
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
    class SplashScreen : GameScreen
    {
        private float FADE_IN_TIME_SCALE = 2;

        private Texture2D _tex_logo;
        private SoundEffect _sfx_intro_jingle;
        private IInputActionMap _inputActionMap;
        private Color _logoColor = new Color (255f, 255f, 255f, 255);
        private float _logoAlpha = 0;
        private float _elapsedTime = 0;
        private bool _hasJinglePlayed = false;

        private int RESOLUTION_WIDTH;
        private int RESOLUTION_HEIGHT;

        public SplashScreen (GameServiceContainer services) : base(ScreenName.SPLASH, services) {
            _setDefaultScreenState();
            Initialize();
        }



        public override void Start ()
        {
            _setDefaultScreenState();

            InputManager.SetActiveInputActionMap(_inputActionMap);

            base.Start();
        }



        public override void Initialize ()
        {
            RESOLUTION_WIDTH = SettingsManager.GetSettingValue<int>(CONSTANTS.SETTING_RESOLUTION_WIDTH);
            RESOLUTION_HEIGHT = SettingsManager.GetSettingValue<int>(CONSTANTS.SETTING_RESOLUTION_HEIGHT);

            _inputActionMap = new InputActionMap();
            _inputActionMap.BindActionToInput(SkipScreen, Buttons.A);
            _inputActionMap.BindActionToInput(SkipScreen, Keys.Space);
            _inputActionMap.BindActionToInput(PlayJingle, Keys.S);

        }



        private void _setDefaultScreenState ()
        {
            _logoColor = new Color(255f, 255f, 255f, 255);
            _logoAlpha = 0;
            _elapsedTime = 0;
            _hasJinglePlayed = false;
    }



        public override void LoadContent ()
        {
            _tex_logo = AssetManager.LoadLevelAsset<Texture2D>(CONSTANTS.ASSET_SPLASH_LOGO);
            _sfx_intro_jingle = AssetManager.LoadLevelAsset<SoundEffect>(CONSTANTS.ASSET_SPLASH_JINGLE);

            return;
        }



        // Todo: Find a better way to do "Pre-programmed" sequences
        public override void Update (GameTime gameTime)
        {
            base.Update(gameTime);

            _increaseAlpha((float)gameTime.ElapsedGameTime.TotalSeconds);

            if (!_hasJinglePlayed &&_logoAlpha >= 1)
            {
                PlayJingle();
                _hasJinglePlayed = true;

            } 

            return;
        }


        // ToDo: Move to Render Helpers
        private void _increaseAlpha (float deltaTime)
        {
            if (_logoAlpha >= 1)
                return;

            _elapsedTime += deltaTime / FADE_IN_TIME_SCALE;
           _logoAlpha = Math.Clamp(_elapsedTime, 0, 1);
        }



        private void SkipScreen ()
        {
            GameScreenService.SetActiveScreen(ScreenName.TITLE);
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
                    _tex_logo.Width,
                    _tex_logo.Height,
                    RESOLUTION_WIDTH,
                    RESOLUTION_HEIGHT
                ),
                _logoColor * _logoAlpha
            );
            

            return;
        }



        public override void Pause ()
        {
            base.Pause();

            return;
        }



        public override void Resume ()
        {
            base.Resume();

            return;
        }



        public override void Reset ()
        {
            _setDefaultScreenState();
        }



        public override void Exit ()
        {
            base.Exit();
        }
    }
}
