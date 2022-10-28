using System;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Interfaces
{
    public interface IGameObject
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}

