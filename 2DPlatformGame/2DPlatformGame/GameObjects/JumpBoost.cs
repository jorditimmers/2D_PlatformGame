using System;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.GameObjects
{
    public class JumpBoost : IGameObject, ICollision
    {
        public bool used;
        Texture2D Texture;
        Vector2 position;

        public Rectangle Frame
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
            }
            set
            {
                Frame = value;
            }
        }

        public JumpBoost(Texture2D text, Vector2 pos)
        {
            Texture = text;
            position = pos;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!used)
            {
                spriteBatch.Draw(this.Texture, this.position, new Rectangle(0, 0, Texture.Width, Texture.Height), Color.White, 0, new Vector2(0, 0), .15f, SpriteEffects.None, 0);
            }
        }

        public void Update(GameTime gameTime, TerainBuilder terrain)
        {
            used = true;
        }
    }
}

