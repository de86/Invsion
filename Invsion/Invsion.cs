﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Invsion.Engine;
using Invsion.Engine.Events;
using Invsion.Engine.Input;
using Invsion.Engine.Settings;
using Invsion.Engine.Assets;

using Invsion.Src.Screens;
using Invsion.Src.Constants;

namespace Invsion
{
    public class Invsion : Game
    {
        // Hardcode some default values for Launch config
        private int WINDOW_WIDTH = 1280;
        private int WINDOW_HEIGHT = 720;
        private int RESOLUTION_WIDTH = 1920;
        private int RESOLUTION_HEIGHT = 1080;
        private ScreenName _startingGameScreen = ScreenName.GAMEPLAY;

        private GraphicsDeviceManager _graphics;
        private GraphicsDevice _graphicsDevice;
        private RenderTarget2D _renderTarget;
        private SpriteBatch _spriteBatch;

        private IGameScreenService _gameScreenService;
        private IInputManager _inputManager;
        private ISettingsManager _settingsManager;
        private IAssetManager _assetManager;

        private float scale = 0.44444f;



        public Invsion()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }



        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _graphicsDevice = GraphicsDevice;

            // Init Input
            var keyboardInputControlScheme = new InputControlScheme<Keys>();
            keyboardInputControlScheme.BindActionToInput(Keys.Space, INPUT_ACTIONS.FIRE_PRIMARY);
            keyboardInputControlScheme.BindActionToInput(Keys.Left, INPUT_ACTIONS.MOVE_LEFT);
            keyboardInputControlScheme.BindActionToInput(Keys.Right, INPUT_ACTIONS.MOVE_RIGHT);
            keyboardInputControlScheme.BindActionToInput(Keys.Up, INPUT_ACTIONS.MOVE_UP);
            keyboardInputControlScheme.BindActionToInput(Keys.Down, INPUT_ACTIONS.MOVE_DOWN);

            // Init Input Events
            var inputEventBus = new InputEventBus();
            inputEventBus.CreateEventForAction(INPUT_ACTIONS.FIRE_PRIMARY);
            inputEventBus.CreateEventForAction(INPUT_ACTIONS.MOVE_LEFT);
            inputEventBus.CreateEventForAction(INPUT_ACTIONS.MOVE_RIGHT);
            inputEventBus.CreateEventForAction(INPUT_ACTIONS.MOVE_UP);
            inputEventBus.CreateEventForAction(INPUT_ACTIONS.MOVE_DOWN);

            _inputManager = new InputManager(inputEventBus, keyboardInputControlScheme);

            // Initialize Services
            _settingsManager = new SettingsManager();
            var sharedContentManager = new ContentManager(Services, Content.RootDirectory);
            var uiContentManager = new ContentManager(Services, Content.RootDirectory);
            var levelContentManager = new ContentManager(Services, Content.RootDirectory);
            _assetManager = new AssetManager(sharedContentManager, uiContentManager, levelContentManager);
            _gameScreenService = new GameScreenService(_assetManager, _spriteBatch);

            // Add services to service provider
            Services.AddService(typeof(ISettingsManager), _settingsManager);
            Services.AddService(typeof(InputEventBus), inputEventBus);
            Services.AddService(typeof(IInputManager), _inputManager);
            Services.AddService(typeof(GraphicsDevice), _graphicsDevice);
            Services.AddService(typeof(IAssetManager), _assetManager);
            Services.AddService(typeof(IGameScreenService), _gameScreenService);

            // Add Screens
            _gameScreenService.AddScreen(new SplashScreen(Services));
            _gameScreenService.AddScreen(new TitleScreen(Services));
            _gameScreenService.AddScreen(new GameplayScreen(Services));
            _gameScreenService.Start(_startingGameScreen);

            // Get settings required for launch
            WINDOW_WIDTH = _settingsManager.GetSettingValue<int>("WINDOW_WIDTH");
            WINDOW_HEIGHT = _settingsManager.GetSettingValue<int>("WINDOW_HEIGHT");
            RESOLUTION_WIDTH = _settingsManager.GetSettingValue<int>("RESOLUTION_WIDTH");
            RESOLUTION_HEIGHT = _settingsManager.GetSettingValue<int>("RESOLUTION_HEIGHT");

            base.Initialize();

            // Must go after base.Initialize()
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();
        }



        protected override void LoadContent()
        {
            _gameScreenService.LoadContent();

            _renderTarget = new RenderTarget2D(GraphicsDevice, RESOLUTION_WIDTH, RESOLUTION_HEIGHT);
        }



        protected override void Update(GameTime gameTime)
        {
            _inputManager.ProcessInput();

            _gameScreenService.UpdateActiveScreen(gameTime);

            base.Update(gameTime);
        }



        protected override void Draw(GameTime gameTime)
        {
            scale = 1f / ((float)RESOLUTION_HEIGHT / GraphicsDevice.Viewport.Height);

            GraphicsDevice.SetRenderTarget(_renderTarget);
            GraphicsDevice.Clear(Color.Black);

            // Will need spritebatch management. Must keep Begin/End calls to a minimum.
            // Perhaps a spritebatch service that can be queried to grab the needed pre-existing spritebatches
            _spriteBatch.Begin();
            // Pass in spritebatch or add graphics device to services?
            _gameScreenService.DrawActiveScreen(gameTime);
            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
