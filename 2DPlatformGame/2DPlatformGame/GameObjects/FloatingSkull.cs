using System;
using DPlatformGame.Animations;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.GameObjects
{
    public class FloatingSkull : IGameObject
    {
        Texture2D floatingTexture;
        Vector2 position;
        Animation anim;
        public SpriteEffects effect;

        public AnimationPool pool;
        public float scale = 3.0f;

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
            position.X -= 5;
        }
    }
}

