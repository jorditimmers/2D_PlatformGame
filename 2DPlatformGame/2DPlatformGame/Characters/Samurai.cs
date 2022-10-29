using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DPlatformGame.Animations;

namespace DPlatformGame.Characters
{
    public class Samurai : IGameObject
    {
        private Texture2D idleTexture;
        private Texture2D moveTexture;
        private Vector2 position;
        private Vector2 speed;
        float scale = 4.0f;
        Animation idleAnimation;
        Animation moveAnimation;
        SpriteEffects effect;

        public Samurai(Texture2D idleTexture, Texture2D moveTexture)
        {
            //create spriteeffect
            effect = SpriteEffects.None;

            //get textures from constructor
            this.idleTexture = idleTexture;
            this.moveTexture = moveTexture;

            //create idle animation (this is with the texture you receive from the constructor parameter)
            this.idleAnimation = new Animation();
            this.idleAnimation.GetFramesFromTextureProperties(idleTexture.Width, idleTexture.Height, 3, 1);

            //create move animation
            this.moveAnimation = new Animation();
            this.moveAnimation.GetFramesFromTextureProperties(moveTexture.Width, moveTexture.Height, 12, 1);


            position = new Vector2(0,0);
            speed = new Vector2(5,0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.moveTexture, this.position, this.moveAnimation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 4.0f, effect, 0);
        }

        public void Update(GameTime gameTime)
        {
            moveAnimation.Update(gameTime);
            Move();
        }


        private void Move()
        {
            position += speed;
            if (position.X > 1280 - ((moveTexture.Width/12)*scale)
                || position.X < 0)
            {
                CheckForFlip();
                speed.X *= -1;
            }
            if (position.Y > 720 - ((moveTexture.Height*1)*scale)
                || position.Y < 0)
            {
                speed.Y *= -1;
            }
        }

        private void CheckForFlip()
        {
            if (effect == SpriteEffects.None)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                effect = SpriteEffects.None;
            }
        }
    }
}

