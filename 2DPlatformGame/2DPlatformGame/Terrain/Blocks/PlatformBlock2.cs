using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain.Blocks
{
    public class PlatformBlock2 : Block
    {
        public PlatformBlock2(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this.Frame = new Rectangle(208, 156, 16, 16);
            this.Position = new Vector2(x, y);
            this.Passable = false;
            this.Color = Color.GreenYellow;
            this.Texture = texture;
        }
    }
}

