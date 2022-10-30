using System;
using System.Collections.Generic;
using DPlatformGame.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Animations
{
    public class AnimationPool
    {
        public List<Animation> AnimationList = new List<Animation>();
        public List<Texture2D> Texturelist = new List<Texture2D>();
        public SpriteEffects effect;

        private Vector2 position;
        private Vector2 speed;
        private Rectangle currentFrame;
        private Texture2D currentTexture;
        private float scale = 3.0f;

        public AnimationPool()
        {
            effect = SpriteEffects.None;
            position = new Vector2(0, 0);
            speed = new Vector2(5, 5);
        }

        public void AddAnimation(Animation a, Texture2D t)
        {
            this.AnimationList.Add(a);
            this.Texturelist.Add(t);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardReader k = new KeyboardReader();
            var direction = k.ReadInput();
            direction *= speed;
            position += direction;

            CheckForFlip(direction);

            //chosing between animations based on movement
            if (direction.X == 0)
            {
                AnimationList[0].Update(gameTime);
                currentTexture = Texturelist[0];
                currentFrame = AnimationList[0].CurrentFrame.SourceRectangle;
            }
            else
            {
                AnimationList[1].Update(gameTime);
                currentTexture = Texturelist[1];
                currentFrame = AnimationList[1].CurrentFrame.SourceRectangle;
            }

            position.Y = 720 - 64 - (currentTexture.Height * scale) + 6;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.currentTexture, this.position, this.currentFrame, Color.White, 0, new Vector2(0, 0), scale, effect, 0);
        }

        public void CheckForFlip(Vector2 direction)
        {
            if (direction.X > 0)
            {
                effect = SpriteEffects.None;
            }
            else if (direction.X < 0)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
        }
    }
}

