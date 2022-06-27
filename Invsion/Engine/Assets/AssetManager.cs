using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Content;

namespace Invsion.Engine.Assets
{
    public class AssetManager : IAssetManager
    {
        private ContentManager _sharedContentManager,
                               _uiContentManager,
                               _levelContentManager;


        public  AssetManager (ContentManager SharedContentManager, ContentManager UIContentManager, ContentManager LevelContentManager)
        {
            _sharedContentManager = SharedContentManager;
            _uiContentManager = UIContentManager;
            _levelContentManager = LevelContentManager;
        }



        public T LoadSharedAsset<T> (string assetName)
        {
            return _sharedContentManager.Load<T>(assetName);
        }



        public T LoadUIAsset<T> (string assetName)
        {
            return _uiContentManager.Load<T>(assetName);
        }



        public T LoadLevelAsset<T> (string assetName)
        {
            return _levelContentManager.Load<T>(assetName);
        }



        public void LoadSharedAssets<T> (string[] assetNames)
        {
            foreach (string assetName in assetNames)
            {
                LoadSharedAsset<T>(assetName);
            }
        }



        public void LoadUIAssets<T> (string[] assetNames)
        {
            foreach (string assetName in assetNames)
            {
                LoadUIAsset<T>(assetName);
            }
        }



        public void LoadLevelAssets<T> (string[] assetNames)
        {
            foreach (string assetName in assetNames)
            {
                LoadLevelAsset<T>(assetName);
            }
        }



        public void UnloadSharedAssets ()
        {
            _sharedContentManager.Unload();
        }



        public void UnloadUIAssets ()
        {
            _uiContentManager.Unload();
        }



        public void UnloadLevelAssets ()
        {
            _levelContentManager.Unload();
        }



        public void UnloadAllAssets ()
        {
            UnloadSharedAssets();
            UnloadUIAssets();
            UnloadLevelAssets();
        }
    }
}
