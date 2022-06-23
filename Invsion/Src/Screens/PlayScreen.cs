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
        private SpriteFont _titleFont;
        private SpriteFont _titleFontSmall;
        private Song _titleMusic;

        private IInputActionMap _inputActionMap;
        private SwitchTimer _blinkTimer;
        private float _blinkDuration = 1;

        // ToDo: Move to localisation
        private string _titleTextString = "Play";

        private StaticText _titleText;

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

            _blinkTimer = new SwitchTimer(_blinkDuration);
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

            return;
        }
        


        public override void Update (GameTime gameTime)
        {
            _blinkTimer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);

            return;
        }



        public override void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime)
        {
            _titleText.Draw(defaultSpriteBatch);

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
