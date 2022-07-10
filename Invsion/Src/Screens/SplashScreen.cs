using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine;
using Invsion.Engine.Events;
using Invsion.Engine.Graphics;

using Invsion.Src.Constants;

namespace Invsion.Src.Screens
{
    class SplashScreen : GameScreen
    {
        private float FADE_IN_TIME_SCALE = 2;

        private Sprite _logo;
        private Texture2D _tex_logo;
        private SoundEffect _sfx_intro_jingle;
        private float _logoAlpha = 0;
        private float _elapsedTime = 0;
        private bool _hasJinglePlayed = false;

        private int RESOLUTION_WIDTH;
        private int RESOLUTION_HEIGHT;



        public SplashScreen (GameServiceContainer services) : base(ScreenName.SPLASH, services) {
            _setDefaultScreenState();
            Initialize();
        }



        public override void RegisterInputEventHandlers ()
        {
            InputEventBus.SubscribeToEvent(INPUT_ACTIONS.FIRE_PRIMARY, _onSkipScreen);
        }



        public override void UnregisterInputEventHandlers ()
        {
            InputEventBus.UnsubscribeFromEvent(INPUT_ACTIONS.FIRE_PRIMARY, _onSkipScreen);
        }



        public override void Start ()
        {
            _setDefaultScreenState();

            base.Start();
        }



        public override void Initialize ()
        {
            RESOLUTION_WIDTH = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_WIDTH);
            RESOLUTION_HEIGHT = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_HEIGHT);
        }



        private void _setDefaultScreenState ()
        {
            _logoAlpha = 0;
            _elapsedTime = 0;
            _hasJinglePlayed = false;
        }



        public override void LoadContent ()
        {
            _tex_logo = AssetManager.LoadLevelAsset<Texture2D>(ASSETS.SPLASH_LOGO);
            _sfx_intro_jingle = AssetManager.LoadLevelAsset<SoundEffect>(ASSETS.SPLASH_JINGLE);

            _logo = new Sprite(_tex_logo, new Vector2(RESOLUTION_WIDTH / 2, RESOLUTION_HEIGHT / 2));
            _logo.SetOriginCentre();

            return;
        }



        // Todo: Find a better way to do "Pre-programmed" sequences
        public override void Update (GameTime gameTime)
        {
            base.Update(gameTime);

            _increaseAlpha((float)gameTime.ElapsedGameTime.TotalSeconds);
            _logo.UpdateAlpha(_logoAlpha);

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

            _elapsedTime += deltaTime / FADE_IN_TIME_SCALE;
           _logoAlpha = Math.Clamp(_elapsedTime, 0, 1);
        }



        private void _onSkipScreen (object source, object actionObj)
        {
            var action = (string)actionObj;
            GameScreenService.SetActiveScreen(ScreenName.TITLE);
        }



        private void PlayJingle ()
        {
            _sfx_intro_jingle.Play();
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _logo.Draw(defaultSpriteBatch);
            

            return;
        }


        public override void DebugDraw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
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
