using System;
using System.Collections.Generic;
using System.Text;

using Invsion.Src.Input;
using Invsion.Src.Shared;
using Invsion.Src.Shared.Helpers;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

using Invsion.Src.Shared.Utilities;

namespace Invsion.Src.Screens
{
    class TitleScreen : GameScreen
    {
        // ToDo: Create Text/Dynamic Text wrapper class
        private SpriteFont _titleFont;
        private SpriteFont _titleFontSmall;
        private Song _titleMusic;

        private Vector2 _titleFontSize;
        private Vector2 _startTextSize;
        private IInputActionMap _inputActionMap;
        private SwitchTimer _blinkTimer;
        private float _blinkDuration = 1;

        // ToDo: Move to localisation
        private string _titleText = "INVSION";
        private string _startText = "Press X to start";

        private int RESOLUTION_WIDTH;
        private int RESOLUTION_HEIGHT;



        public TitleScreen (GameServiceContainer services) : base(ScreenName.TITLE, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            RESOLUTION_WIDTH = SettingsManager.GetSettingValue<int>("RESOLUTION_WIDTH");
            RESOLUTION_HEIGHT = SettingsManager.GetSettingValue<int>("RESOLUTION_HEIGHT");

            _inputActionMap = new InputActionMap();

            _blinkTimer = new SwitchTimer(_blinkDuration);
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        public override void LoadContent ()
        {
            _titleFont = AssetManager.LoadLevelAsset<SpriteFont>("Fonts/orbitron-regular");
            _titleFontSize = _titleFont.MeasureString(_titleText);

            _titleFontSmall = AssetManager.LoadLevelAsset<SpriteFont>("Fonts/orbitron-regular-24");
            _startTextSize = _titleFontSmall.MeasureString(_startText);

            _titleMusic = AssetManager.LoadLevelAsset<Song>("Audio/Music/neon-god-loop");
            MediaPlayer.Play(_titleMusic);
            MediaPlayer.IsRepeating = true;

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            _blinkTimer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            return;
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            defaultSpriteBatch.DrawString(
                _titleFont,
                _titleText,
                RenderHelpers.ScreenCentre(
                    _titleFontSize.X,
                    _titleFontSize.Y,
                    RESOLUTION_WIDTH,
                    RESOLUTION_HEIGHT

                ),
                Color.White
            );

            defaultSpriteBatch.DrawString(
                _titleFontSmall,
                _startText,
                RenderHelpers.ScreenCentre(
                    _startTextSize.X,
                    _startTextSize.Y - 200,
                    RESOLUTION_WIDTH,
                    RESOLUTION_HEIGHT
                ),
                Color.White * _blinkTimer.GetValue()
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
