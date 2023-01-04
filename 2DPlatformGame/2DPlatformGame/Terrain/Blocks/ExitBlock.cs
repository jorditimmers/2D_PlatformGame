using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain.Blocks
{
    public class ExitBlock : Block
    {
        public ExitBlock(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this.SpriteFrame = new Rectangle(168, 456, 53, 24);
            this.Position = new Vector2(x, y);
            this.Passable = true;
            this.Color = Color.GreenYellow;
            this.Texture = texture;
        }
    }
}

