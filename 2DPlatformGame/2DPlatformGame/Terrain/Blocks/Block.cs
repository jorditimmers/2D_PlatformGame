using System;
using DPlatformGame.Characters;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain
{
    public abstract class Block : IGameObject
    {
        public Vector2 Position { get; set; }
        public Rectangle Frame { get; set; }
        public bool Passable { get; set; }
        public Color Color { get; set; }
        public Texture2D Texture { get; set; }

        public Rectangle BoundingBox { get; set; }

        public Block(int x, int y, Texture2D texture)
        {
            this.Position = new Vector2(x, y);
            this.Passable = false;
            this.Color = Color.White;
            this.Texture = texture;
            this.Frame = new Rectangle((int)Position.X, (int)Position.Y, 32, 32); //32 want 16x16 worden aan scale 2 gedrawt
            this.BoundingBox = new Rectangle(x, y, 32, 32);
        }

        public bool CollidesWithObject(IGameObject obj)
        {
            return obj.Frame.Intersects(this.BoundingBox);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
