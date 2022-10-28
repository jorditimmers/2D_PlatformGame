using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DPlatformGame.Animations;

namespace DPlatformGame.Characters
{
    public class Samurai : IGameObject
    {
        private Texture2D texture;
        private int move_X = 0;
        Animation animation;

        public Samurai(Texture2D texture)
        {
            this.texture = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 3, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 4.0f, SpriteEffects.None, 0);
        }

        public void Update()
        {
            animation.Update();
        }
    }
}

