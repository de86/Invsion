using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

using Invsion.Engine;
using Invsion.Engine.Input;
using Invsion.Engine.Graphics;
using Invsion.Engine.Utilities;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Invsion.Src.Screens
{
    class TitleScreen : GameScreen
    {
        private SpriteFont _titleFont;
        private SpriteFont _titleFontSmall;
        private Song _titleMusic;

        private IInputActionMap _inputActionMap;
        private SwitchTimer _blinkTimer;
        private float _blinkDuration = 1;

        // ToDo: Move to localisation
        private string _titleTextString = "INVSION";
        private string _startTextString = "Press X to start";

        private StaticText _titleText;
        private StaticText _startText;

        private int RESOLUTION_WIDTH;
        private int RESOLUTION_HEIGHT;



        public TitleScreen (GameServiceContainer services) : base(ScreenName.TITLE, services) {
            Initialize();
        }



        public override void Initialize ()
        {
            RESOLUTION_WIDTH = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_WIDTH);
            RESOLUTION_HEIGHT = SettingsManager.GetSettingValue<int>(SETTINGS.RESOLUTION_HEIGHT);

            _inputActionMap = new InputActionMap();
            _inputActionMap.BindActionToInput(_skipScreen, Keys.Space);

            _blinkTimer = new SwitchTimer(_blinkDuration);
        }


        
        private void _skipScreen ()
        {
            GameScreenService.SetActiveScreen(ScreenName.GAMEPLAY);
        }



        public override void Start ()
        {
            base.Start();

            InputManager.SetActiveInputActionMap(_inputActionMap);
        }



        public override void LoadContent ()
        {
            _titleFont = AssetManager.LoadLevelAsset<SpriteFont>(ASSETS.TITLE_FONT);
            _titleFontSmall = AssetManager.LoadLevelAsset<SpriteFont>(ASSETS.TITLE_FONT_SMALL);

            _titleMusic = AssetManager.LoadLevelAsset<Song>(ASSETS.TITLE_MUSIC_SMALL);
            MediaPlayer.Play(_titleMusic);
            MediaPlayer.IsRepeating = true;

            Vector2 screenCentre = new Vector2(RESOLUTION_WIDTH / 2, RESOLUTION_HEIGHT / 2);
            _titleText = new StaticText(_titleTextString, _titleFont, screenCentre);
            _titleText.SetOriginCentre();

            _startText = new StaticText(_startTextString, _titleFontSmall, new Vector2(screenCentre.X, screenCentre.Y + 100));
            _startText.SetOriginCentre();

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            _blinkTimer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            _startText.UpdateAlpha(_blinkTimer.GetValue());

            return;
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _titleText.Draw(defaultSpriteBatch);
            _startText.Draw(defaultSpriteBatch);

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
