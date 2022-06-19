using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Content;

namespace Invsion.Src.Shared.Assets
{
    internal interface IAssetManager
    {
        public T LoadSharedAsset<T> (string assetName);

        public T LoadUIAsset<T> (string assetName);

        public T LoadLevelAsset <T> (string assetName);

        public void LoadSharedAssets<T> (string[] assetNames);

        public void LoadUIAssets<T> (string[] assetNames);

        public void LoadLevelAssets<T> (string[] assetNames);

        public void UnloadSharedAssets ();

        public void UnloadUIAssets ();

        public void UnloadLevelAssets ();

        public void UnloadAllAssets ();
    }
}
