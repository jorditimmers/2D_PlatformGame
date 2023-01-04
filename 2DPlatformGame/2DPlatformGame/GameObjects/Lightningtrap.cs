using System;
using DPlatformGame.Animations;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.GameObjects
{
    public class Lightningtrap : IGameObject, ICollision
    {
        Texture2D lightningTexture;
        Vector2 position;
        Animation anim;
        public SpriteEffects effect;

        public AnimationPool pool;
        public float scale = 2.0f;

        public Rectangle Frame
        {
            get
            {
                return new Rectangle((int)position.X + lightningTexture.Width / 24, (int)position.Y, lightningTexture.Width / 24, (int)(lightningTexture.Height * scale));
            }
            set
            {
                Frame = value;
            }
        }

        public Lightningtrap(Texture2D t)
        {
            this.lightningTexture = t;
            effect = SpriteEffects.None;

            Rectangle hitBox = new Rectangle(0, 0, lightningTexture.Width / 12, lightningTexture.Height / 1);
            position = new Vector2(700, 469);

            anim = new Animation(hitBox);
            anim.GetFramesFromTextureProperties(lightningTexture.Width, lightningTexture.Height, 12, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.lightningTexture, this.position, anim.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), scale, effect, 0);
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            //720 - 64 - (currentTexture.Height * scale) + 6
            anim.Update(gameTime);

        }
    }
}

