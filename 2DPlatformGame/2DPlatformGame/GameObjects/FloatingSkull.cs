using System;
using DPlatformGame.Animations;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.GameObjects
{
    public class FloatingSkull : IGameObject, ICollision
    {
        Texture2D floatingTexture;
        Vector2 position;
        Animation anim;
        public SpriteEffects effect;
        bool goesRight = false;

        public AnimationPool pool;
        public float scale = 2.0f;

        public Rectangle Frame
        {
            get
            {
                return new Rectangle((int)position.X,(int)position.Y,floatingTexture.Width / 4, floatingTexture.Height / 4);
            }
            set
            {
                Frame = value;
            }
        }

        public FloatingSkull(Texture2D t)
        {
            this.floatingTexture = t;
            effect = SpriteEffects.None;

            Rectangle hitBox = new Rectangle(0, 0, floatingTexture.Width/4, floatingTexture.Height/4);
            position = new Vector2(1000, 720 - 64 - (floatingTexture.Height/4 * scale) + 6);

            anim = new Animation(hitBox);
            anim.GetFramesFromTextureProperties(floatingTexture.Width, floatingTexture.Height, 4, 4);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.floatingTexture, this.position, anim.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), scale, effect, 0);
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            //720 - 64 - (currentTexture.Height * scale) + 6
            anim.Update(gameTime);
            if (goesRight)
            {
                effect = SpriteEffects.None;
                position.X += 3;
                if (position.X >= 1200)
                {
                    goesRight = false;
                }
            }
            else
            {
                effect = SpriteEffects.FlipHorizontally;
                position.X -= 3;
                if (position.X <= 0)
                {
                    goesRight = true;
                }
            }

        }
    }
}

