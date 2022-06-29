using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Invsion.Engine
{
    public interface IGameScreenService
    {
        public void AddScreen (IGameScreen screen);

        public void RemoveScreen (IGameScreen screen);

        public void RemoveAllScreens ();

        public void SetActiveScreen (ScreenName screen);

        public void Start (ScreenName screenName);

        public void LoadContent ();

        public void DrawActiveScreen (GameTime gameTime);

        public void UpdateActiveScreen (GameTime gameTime);
    }
}
