using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain.Blocks
{
    public class PlatformBlock : Block
    {
        //192 W Start
        //156 H Start
        public PlatformBlock(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this.Frame = new Rectangle(192,156,16,16);
            this.Position = new Vector2(x, y);
            this.Passable = true;
            this.Color = Color.GreenYellow;
            this.Texture = texture;
        }
    }
}

