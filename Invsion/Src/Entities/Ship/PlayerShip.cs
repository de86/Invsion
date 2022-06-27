using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Invsion.Engine.Assets;
using Invsion.Engine.Components;

namespace Invsion.Src.Entities.Ship
{
    class PlayerShip
    {
        // Ability to move
        // Guns[]
        // Ability to fire
        // Ability to change weapons

        private int _maxHealth;
        private int _maxShield;

        private IHealthComponent _health;
        private IHealthComponent _shield;
        private IPositionComponent _position;

        private Texture2D _playerShipTexture;

        public PlayerShip ()
        {
            _health = new HealthComponent(_maxHealth);
            _shield = new HealthComponent(_maxShield);
            // Starting position probably should be passed in
            _position = new PositionComponent(new Vector2(100, 100));
        }



        public void LoadContent (IAssetManager AssetManager)
        {
            _playerShipTexture = AssetManager.LoadLevelAsset<Texture2D>("Art/ship_L");
        }



        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _playerShipTexture,
                _position.GetPosition(),
                Color.White
            );
        }
    }
}
