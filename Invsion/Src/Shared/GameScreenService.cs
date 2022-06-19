using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Src.Shared.Assets;
using Invsion.Src.Shared.Errors;

namespace Invsion.Src.Shared
{
    class GameScreenService : IGameScreenService
    {

        private GameScreenService _INSTANCE {
            get
            {
                if (_INSTANCE == null)
                {
                    throw new SingletonNotInitializedException("GameScreenService");
                } else
                {
                    return _INSTANCE;
                }
            }
        }


        private IAssetManager _assetManager;
        private SpriteBatch _defaultSpriteBatch;

        private Dictionary<ScreenName, IGameScreen> _gameScreens;
        private IGameScreen _activeGameScreen;



        public GameScreenService (IAssetManager assetManager, SpriteBatch defaultSpriteBatch)
        {
            _assetManager = assetManager;
            _defaultSpriteBatch = defaultSpriteBatch;
            _gameScreens = new Dictionary<ScreenName, IGameScreen>();
        }



        public void AddScreen (IGameScreen screen)
        {
            var searchResult = _gameScreens.Where(_screen => _screen.Key.CompareTo(screen.name) == 1);
            if (!searchResult.Any())
            {
                _gameScreens.Add(screen.name, screen);
            }
        }



        public void RemoveAllScreens ()
        {
            foreach (KeyValuePair<ScreenName, IGameScreen> screen in _gameScreens)
            {
                screen.Value.Exit();
            }

            _gameScreens.Clear();
        }



        public void RemvoveScreen (IGameScreen screen)
        {
            throw new NotImplementedException();
        }



        public void SetActiveScreen (ScreenName screenName)
        {
            _activeGameScreen.Exit();
            var nextScreen = GetScreen(screenName);
            nextScreen.Start();
            _activeGameScreen = _gameScreens[screenName];
        }



        public void Start (ScreenName screenName)
        {
            _activeGameScreen = GetScreen(screenName);
            _activeGameScreen.Start();
        }



        private IGameScreen GetScreen (ScreenName screenName)
        {
            return _gameScreens[screenName];
        }



        public IGameScreen GetActiveScreen ()
        {
            return _activeGameScreen;
        }



        public void LoadContent ()
        {
            _activeGameScreen.LoadContent();
        }



        public void UnloadAllContent ()
        {
            _assetManager.UnloadAllAssets();
        }



        public void DrawActiveScreen (GameTime gameTime)
        {
            _activeGameScreen.Draw(_defaultSpriteBatch, gameTime);
        }

        public void UpdateActiveScreen (GameTime gameTime)
        {
            _activeGameScreen.Update(gameTime);
        }
    }
}
