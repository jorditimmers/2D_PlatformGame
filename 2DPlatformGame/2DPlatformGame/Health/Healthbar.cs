using System;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Health
{
    public class Healthbar : IGameObject
    {
        public int points;
        Texture2D HearthTexture;

        public Healthbar(Texture2D texture)
        {
            points = 3;
            HearthTexture = texture;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < points; i++)
            {
                spriteBatch.Draw(this.HearthTexture, new Vector2(80*i,30), new Rectangle(0,0,HearthTexture.Width, HearthTexture.Height), Color.White, 0, new Vector2(0, 0), .05f, SpriteEffects.None, 0);
            }
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            throw new NotImplementedException();
        }

        public bool takeHealthPoint()
        {
            points--;
            if(points <= 0)
            {
                return true;
            }
            return false;
        }
    }
}

