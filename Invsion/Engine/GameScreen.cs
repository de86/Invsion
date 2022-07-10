using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine.Events;
using Invsion.Engine.Input;
using Invsion.Engine.Assets;
using Invsion.Engine.Settings;

namespace Invsion.Engine
{
    public abstract class GameScreen : IGameScreen
    {
        public ScreenName name { get; set; }
        public GameServiceContainer Services;

        internal IGameScreenService GameScreenService;
        internal IInputManager InputManager;
        internal ISettingsManager SettingsManager;
        internal IAssetManager AssetManager;
        internal InputEventBus InputEventBus;
        internal GraphicsDevice GraphicsDevice;

        internal bool _isPaused = false;

        public GameScreen (ScreenName screenName, GameServiceContainer services)
        {
            name = screenName;
            Services = services;

            GameScreenService = (IGameScreenService)services.GetService(typeof(IGameScreenService));
            InputManager = (IInputManager)services.GetService(typeof(IInputManager));
            SettingsManager = (ISettingsManager)services.GetService(typeof(ISettingsManager));
            AssetManager = (IAssetManager)services.GetService(typeof(IAssetManager));
            InputEventBus = (InputEventBus)services.GetService(typeof(InputEventBus));
            GraphicsDevice = (GraphicsDevice)services.GetService(typeof(GraphicsDevice));
        }

        public abstract void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime);
        public abstract void DebugDraw (SpriteBatch defaultSpriteBatch, GameTime gameTime);

        public virtual void Start ()
        {
            RegisterInputEventHandlers();
        }

        public virtual void Exit ()
        {
            _isPaused = true;
            AssetManager.UnloadLevelAssets();
        }

        public abstract void Initialize ();

        public abstract void LoadContent ();

        public virtual void Pause ()
        {
            _isPaused = true;
        }

        public virtual void Resume () {
            _isPaused = false;
        }

        public virtual void Update (GameTime gameTime) {
            if (_isPaused)
                return;
        }

        public abstract void Reset ();



        public abstract void RegisterInputEventHandlers ();

        public abstract void UnregisterInputEventHandlers ();
    }
}
