using System;
using DPlatformGame.Terrain.Blocks;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Terrain
{
    class BlockFactory
    {
        public static Block CreateBlock(
        string type, int x, int y, Texture2D texture)
        {
            Block newBlock = null;
            type = type.ToUpper();
            if (type == "Platform")
            {
                newBlock = new PlatformBlock(x, y, texture);
            }
            return newBlock;
        }
    }



}

