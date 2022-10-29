using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DPlatformGame.Animations;
using Microsoft.Xna.Framework.Input;
using DPlatformGame.Input;

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

        Rectangle currentFrame;
        Texture2D currentTexture;

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
            spriteBatch.Draw(this.currentTexture, this.position, this.currentFrame, Color.White, 0, new Vector2(0, 0), scale, effect, 0); //this.moveAnimation.CurrentFrame.SourceRectangle
        }

        public void Update(GameTime gameTime)
        {
            //input handling
            KeyboardReader k = new KeyboardReader();
            var direction = k.ReadInput();
            CheckForFlip(direction);
            direction *= speed;
            position += direction;

            //Animation decider
            if(direction.X == 0)
            {
                idleAnimation.Update(gameTime);
                currentTexture = idleTexture;
                currentFrame = idleAnimation.CurrentFrame.SourceRectangle;
            }
            else
            {
                moveAnimation.Update(gameTime);
                currentTexture = moveTexture;
                currentFrame = moveAnimation.CurrentFrame.SourceRectangle;
            }
        }

        private void CheckForFlip(Vector2 direction)
        {
            if(direction.X > 0)
            {
                effect = SpriteEffects.None;
            }
            else if (direction.X < 0)
            {
                effect = SpriteEffects.FlipHorizontally;
            }
        }

        private void Move()
        {
            position += speed;
            if (position.X > 1280 - ((moveTexture.Width/12)*scale)
                || position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y > 720 - ((moveTexture.Height*1)*scale)
                || position.Y < 0)
            {
                speed.Y *= -1;
            }
        }
    }
}

