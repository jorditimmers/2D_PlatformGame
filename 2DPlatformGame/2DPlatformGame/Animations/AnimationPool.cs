﻿using System;
using System.Collections.Generic;
using DPlatformGame.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Animations
{
    public class AnimationPool
    {
        #region variables

        public List<Animation> AnimationList = new List<Animation>();
        public List<Texture2D> Texturelist = new List<Texture2D>();
        public SpriteEffects effect;

        private Vector2 position;
        private Vector2 velocity;
        private Rectangle currentFrame;
        private Texture2D currentTexture;
        private float scale = 3.0f;

        private readonly float gravity = 0.5f;
        private readonly float horizontalMovementSpeed = 5;
        private readonly float jumpingForce = 15;

        private bool isTouchingGround
        {
            get
            {
                if (position.Y >= 720 - 64 - (currentTexture.Height * scale) + 6)
                {
                    return true;
                }
                return false;
            }
        }

        #endregion


        public AnimationPool()
        {
            effect = SpriteEffects.None;
            position = new Vector2(0, 0);
            velocity = new Vector2(5, 9.81f);

        }

        public void AddAnimation(Animation a, Texture2D t)
        {
            currentTexture = t; //giving currenttexture a value so it is not null when we use it to check the height of texture
            this.AnimationList.Add(a);
            this.Texturelist.Add(t);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardReader k = new KeyboardReader();
            var direction = k.ReadInput();
            if (isTouchingGround)
            {
                if (direction.Y == -12345)
                {
                    velocity.Y = -jumpingForce;
                }
                else
                {
                    velocity.Y = 0;
                    position.Y = 720 - 64 - (currentTexture.Height * scale) + 6; //make sure player is pixel perfect on ground
                }
            }
            else
            {
                velocity.Y += gravity;
            }
            position.X += direction.X * horizontalMovementSpeed;
            position.Y += velocity.Y;

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

