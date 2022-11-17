﻿using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using DPlatformGame.Animations;
using Microsoft.Xna.Framework.Input;
using DPlatformGame.Input;
using DPlatformGame.Combat;

namespace DPlatformGame.Characters
{
    public class Samurai : IGameObject
    {
        public AnimationPool pool;
        public Health health;

        public Samurai(Texture2D idleTexture, Texture2D moveTexture, Texture2D jumpTexture, Texture2D attackTexture)
        {
            //create animation pool
            pool = new AnimationPool();
            pool.AddAnimation(new Animation(), idleTexture); //idle
            pool.AnimationList[0].GetFramesFromTextureProperties(idleTexture.Width, idleTexture.Height, 3, 1); //idle
            pool.AddAnimation(new Animation(), moveTexture); //move
            pool.AnimationList[1].GetFramesFromTextureProperties(moveTexture.Width, moveTexture.Height, 12, 1); //move
            pool.AddAnimation(new Animation(), jumpTexture); //jump
            pool.AnimationList[2].GetFramesFromTextureProperties(jumpTexture.Width, jumpTexture.Height, 4, 1); //jump
            pool.AddAnimation(new Animation(), attackTexture); //attack
            pool.AnimationList[3].GetFramesFromTextureProperties(attackTexture.Width, attackTexture.Height, 7, 1); //attack
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pool.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            pool.Update(gameTime);
        }
    }
}

