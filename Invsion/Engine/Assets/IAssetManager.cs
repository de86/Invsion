namespace Invsion.Engine.Assets
{
    public interface IAssetManager
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
