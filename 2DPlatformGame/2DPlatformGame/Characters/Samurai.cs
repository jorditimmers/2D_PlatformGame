using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Characters
{
    public class Samurai : IGameObject
    {
        private Texture2D texture;
        private Rectangle _frameSelector;
        private int move_X = 0;

        public Samurai(Texture2D texture)
        {
            this.texture = texture;
            _frameSelector = new Rectangle(0, 0, 0, 22);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), _frameSelector, Color.White, 0, new Vector2(0, 0), 4.0f, SpriteEffects.None, 0);
        }

        public void Update()
        {
            move_X += 30;
            if (move_X > 60)
            {
                move_X = 0;
            }
            _frameSelector.X = move_X;
        }
    }
}

