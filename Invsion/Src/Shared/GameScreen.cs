using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Src.Input;
using Invsion.Src.Shared;
using Invsion.Src.Shared.Assets;
using Invsion.Src.Shared.Helpers;
using Invsion.Src.Shared.Settings;

namespace Invsion.Src.Shared
{
    public abstract class GameScreen : IGameScreen
    {
        public ScreenName name { get; set; }
        public GameServiceContainer Services;

        internal IGameScreenService GameScreenService;
        internal IInputManager InputManager;
        internal ISettingsManager SettingsManager;
        internal IAssetManager AssetManager;

        public GameScreen (ScreenName screenName, GameServiceContainer services)
        {
            name = screenName;
            Services = services;

            GameScreenService = (IGameScreenService)services.GetService(typeof(IGameScreenService));
            InputManager = (IInputManager)services.GetService(typeof(IInputManager));
            SettingsManager = (ISettingsManager)services.GetService(typeof(ISettingsManager));
            AssetManager = (IAssetManager)services.GetService(typeof(IAssetManager));
        }

        public abstract void Draw (SpriteBatch defaultSpriteBatch, GameTime gameTime);
        public virtual void Start ()
        {
            LoadContent();
        }
        public virtual void Exit ()
        {
            AssetManager.UnloadLevelAssets();
        }

        public abstract void Initialize ();
        public abstract void LoadContent ();
        public abstract void Pause ();
        public abstract void Resume ();
        public abstract void Update (GameTime gameTime);
    }
}
