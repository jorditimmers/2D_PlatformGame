using System;
using DPlatformGame.Animations;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.GameObjects
{
    public class Rat : IGameObject, ICollision
    {
        Texture2D RatTexture;
        Vector2 position;
        Animation anim;
        public SpriteEffects effect;
        bool goesRight = false;
        int minX;
        int maxX;

        public AnimationPool pool;
        public float scale = 2.0f;

        public Rectangle Frame
        {
            get
            {
                return new Rectangle((int)position.X + RatTexture.Width / 8, (int)position.Y + RatTexture.Height / 4 + RatTexture.Height / 8, RatTexture.Width / 8, RatTexture.Height / 8);
            }
            set
            {
                Frame = value;
            }
        }

        public Rat(Texture2D t, Vector2 position, int minX, int maxX)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.RatTexture = t;
            effect = SpriteEffects.None;

            Rectangle hitBox = new Rectangle(0, 0, RatTexture.Width / 4, RatTexture.Height / 2);
            this.position = position;

            anim = new Animation(hitBox);
            anim.GetFramesFromTextureProperties(RatTexture.Width, RatTexture.Height, 4, 2);
            anim.frames.RemoveAt(7);
            anim.frames.RemoveAt(6);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.RatTexture, this.position, anim.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), scale, effect, 0);
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            //720 - 64 - (currentTexture.Height * scale) + 6
            anim.Update(gameTime);
            if (goesRight)
            {
                effect = SpriteEffects.None;
                position.X += (float)2;
                if (position.X >= maxX)
                {
                    goesRight = false;
                }
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
                position.X -= (float)2;
                if (position.X <= minX)
                {
                    goesRight = true;
                }
            }

        }
    }
}

