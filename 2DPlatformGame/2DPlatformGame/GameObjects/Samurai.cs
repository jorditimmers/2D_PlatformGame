using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DPlatformGame.Animations;
using Microsoft.Xna.Framework.Input;
using DPlatformGame.Input;
using DPlatformGame.Combat;
using DPlatformGame.Terrain;

namespace DPlatformGame.Characters
{
    public class Samurai : IGameObject
    {
        public AnimationPool pool;
        public Health health;

        public Samurai(Texture2D idleTexture, Texture2D moveTexture, Texture2D jumpTexture, Texture2D attackTexture)
        {
            //create hitBoxes for animations
            Rectangle idleHitBox = new Rectangle(8,3,12,18);
            Rectangle moveHitBox = new Rectangle(5, 3, 16, 22);
            Rectangle jumpHitBox = new Rectangle(3, 3, 16, 16);
            Rectangle attackHitBox = new Rectangle(12, 3, 14, 18);

            //create animation pool
            pool = new AnimationPool();
            pool.AddAnimation(new Animation(idleHitBox), idleTexture); //idle
            pool.AnimationList[0].GetFramesFromTextureProperties(idleTexture.Width, idleTexture.Height, 3, 1); //idle
            pool.AddAnimation(new Animation(moveHitBox), moveTexture); //move
            pool.AnimationList[1].GetFramesFromTextureProperties(moveTexture.Width, moveTexture.Height, 12, 1); //move
            pool.AddAnimation(new Animation(jumpHitBox), jumpTexture); //jump
            pool.AnimationList[2].GetFramesFromTextureProperties(jumpTexture.Width, jumpTexture.Height, 4, 1); //jump
            pool.AddAnimation(new Animation(attackHitBox), attackTexture); //attack
            pool.AnimationList[3].GetFramesFromTextureProperties(attackTexture.Width, attackTexture.Height, 7, 1); //attack
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pool.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            pool.Update(gameTime, terrain);
        }
    }
}