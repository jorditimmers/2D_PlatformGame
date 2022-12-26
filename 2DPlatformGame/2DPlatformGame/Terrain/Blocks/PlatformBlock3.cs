using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain.Blocks
{
    public class PlatformBlock3 : Block
    {
        public PlatformBlock3(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this.Frame = new Rectangle(224, 156, 16, 16);
            this.Position = new Vector2(x, y);
            this.Passable = true;
            this.Color = Color.GreenYellow;
            this.Texture = texture;
        }
    }
}

