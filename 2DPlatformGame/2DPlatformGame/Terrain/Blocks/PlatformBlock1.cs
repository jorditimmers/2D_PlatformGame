using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain.Blocks
{
    public class PlatformBlock1 : Block
    {
        //192 W Start
        //156 H Start
        public PlatformBlock1(int x, int y, Texture2D texture) : base(x, y, texture)
        {
            this.SpriteFrame = new Rectangle(192,156,16,16);
            this.Position = new Vector2(x, y);
            this.Passable = false;
            this.Color = Color.GreenYellow;
            this.Texture = texture;
        }
    }
}

