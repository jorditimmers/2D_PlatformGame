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

        public Block(int x, int y, Texture2D texture)
        {
            this.Position = new Vector2(x, y);
            this.Passable = false;
            this.Color = Color.White;
            this.Texture = texture;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color);
        }
        public virtual void IsCollidedWithEvent(Samurai collider)
        {
            //CollideWithEvent.Execute();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
