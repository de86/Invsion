using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine
{
    public interface IGameScreen
    {
        ScreenName name { get; set; }

        public void Initialize();

        public void LoadContent();

        public void Update(GameTime gameTime);

        /// <summary>
        /// Called from the GameScreenService when this GameScreen is the active GameScreen.
        /// </summary>
        /// <param name="defaultSpriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch defaultSpriteBatch, GameTime gameTime);

        /// <summary>
        /// Called from the GameScreenService after Draw(). Used for drawing debug information to the screen
        /// </summary>
        /// <param name="defaultSpriteBatch"></param>
        /// <param name="gameTime"></param>
        public void DebugDraw (SpriteBatch defaultSpriteBatch, GameTime gameTime);

        /// <summary>
        /// Called when the GameScreen is no longer the active running screen
        /// </summary>
        public void Pause();

        /// <summary>
        /// Called when the GameScreen is moved from inactive to active state
        /// </summary>
        public void Resume();

        /// <summary>
        /// Called immediately before the gamescreen is activated
        /// </summary>
        public void Start ();

        /// <summary>
        /// Called immediately before the gamescreen is disposed
        /// </summary>
        public void Exit();

        /// <summary>
        /// Called by the ScreenManager when a screen is set as active. Input event handlers should be registered here
        /// </summary>
        public abstract void RegisterInputEventHandlers ();

        /// <summary>
        /// Called by the ScreenManager before switching to a new screen. Input event handlers should be unregistered here.
        /// </summary>
        public abstract void UnregisterInputEventHandlers ();
    }
}
