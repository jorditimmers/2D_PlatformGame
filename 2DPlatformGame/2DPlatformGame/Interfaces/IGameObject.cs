using System;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Interfaces
{
    public interface IGameObject
    {
        void Update(GameTime gameTime, TerainBuilder terrain);
        void Draw(SpriteBatch spriteBatch);
    }
}

