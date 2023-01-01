using System;
using System.Collections.Generic;
using DPlatformGame.Input;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Animations
{
    public class AnimationPool : ICollision
    {
        #region variables

        public List<Animation> AnimationList = new List<Animation>();
        public List<Texture2D> Texturelist = new List<Texture2D>();
        public SpriteEffects effect;

        public Vector2 position;
        private Vector2 velocity;
        public Rectangle currentFrame { get; set; }
        public Texture2D currentTexture;
        public Rectangle currentHitBox { get; set; }
        public float scale = 3.0f;

        private readonly float gravity = 0.5f;
        private readonly float horizontalMovementSpeed = 5;
        private readonly float jumpingForce = 15;

        private bool isAttacking = false;
        private bool isInAir = false;
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

        public Rectangle Frame
        {
            get
            {
                return new Rectangle((int)this.position.X, (int)this.position.Y, (int)(16 * this.scale), (int)(16 * this.scale));
            }
            set { }
        }
        public bool isTouchingBlock = false;

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

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            KeyboardReader k = new KeyboardReader();
            var direction = k.ReadInput();
            if(isInAir && direction.Y == -12345) //for not double jumping through platform | Basicly saying, if already in air don't activte jump ever
            {
                direction.Y = 0;
            }
            if (isTouchingGround)
            {
                if (direction.Y == int.MaxValue && direction.X == 0)
                {
                    isAttacking = true;
                }
                else
                {
                    isAttacking = false;
                }
                if (direction.Y == -12345)
                {
                    velocity.Y = -jumpingForce;
                    isInAir = true;
                }
                else
                {
                    isInAir = false;
                    velocity.Y = 0;
                    position.Y = 720 - 64 - (currentTexture.Height * scale) + 6; //make sure player is on ground properly
                }
            }
            else
            {
                velocity.Y += gravity;
            }

            //calculate next position
            Rectangle nextPos = new Rectangle((int)(position.X + (direction.X * horizontalMovementSpeed) + (currentHitBox.X*scale)), (int)(position.Y + velocity.Y + (currentHitBox.Y * scale)), (int)(currentHitBox.Width*scale), (int)(currentHitBox.Height*scale));

            if (CheckForCollisionsWithTerrain(nextPos, terrain)) //if collision with terrain, don't move vertically, unless you jump when already on the terrain
            {
                isTouchingBlock = true; //this is for animation checker
                isInAir = false;
                if (direction.Y == int.MaxValue && direction.X == 0)
                {
                    isAttacking = true;
                }
                else
                {
                    isAttacking = false;
                }
                if (direction.Y == -12345)
                {
                    velocity.Y = -jumpingForce;
                }
                else
                {
                    velocity.Y = 0;
                }
                position.X += direction.X * horizontalMovementSpeed;
                position.Y += velocity.Y;
            }
            else
            {
                isTouchingBlock = false; //this is for animation checker
                position.X += direction.X * horizontalMovementSpeed;
                position.Y += velocity.Y;
            }

            CheckForFlip(direction);
            AnimationDecider(gameTime, direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.currentTexture, this.position, this.currentFrame, Color.White, 0, new Vector2(0, 0), scale, effect, 0);
        }

        #region Functions

        //public void BlockCollision(Block b)
        //{
        //    isTouchingBlock = true;
        //    BlockTop = b.BoundingBox.Top;
        //}

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

        public void AnimationDecider(GameTime gameTime, Vector2 direction)
        {
            if (!isTouchingGround && !isTouchingBlock)
            {
                AnimationList[2].Update(gameTime);
                currentTexture = Texturelist[2];
                currentFrame = AnimationList[2].CurrentFrame.SourceRectangle;
                currentHitBox = AnimationList[2].hitBox;
            }
            else if (isAttacking)
            {
                AnimationList[3].Update(gameTime);
                currentTexture = Texturelist[3];
                currentFrame = AnimationList[3].CurrentFrame.SourceRectangle;
                currentHitBox = AnimationList[3].hitBox;
            }
            else if (direction.X != 0)
            {
                AnimationList[1].Update(gameTime);
                currentTexture = Texturelist[1];
                currentFrame = AnimationList[1].CurrentFrame.SourceRectangle;
                currentHitBox = AnimationList[1].hitBox;
            }
            else
            {
                AnimationList[0].Update(gameTime);
                currentTexture = Texturelist[0];
                currentFrame = AnimationList[0].CurrentFrame.SourceRectangle;
                currentHitBox = AnimationList[0].hitBox;
            }
        }

        public bool CheckForCollisionsWithTerrain(Rectangle r, TerainBuilder terrain)
        {
            int count = 0;
            foreach (Block b in terrain.blocks)
            {
                if (b.BoundingBox.Intersects(r))
                {
                    Console.WriteLine("HIT"); //Debug

                    count++;
                    //pool.position.Y = b.Position.Y-(pool.currentTexture.Height*pool.scale);
                }
            }
            if (count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}

