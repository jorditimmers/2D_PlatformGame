using System;
using System.Collections.Generic;
using DPlatformGame.Terrain.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Terrain
{
    public class TerainBuilder
    {
        Blueprint print;
        List<Block> blocks = new List<Block>();

        public TerainBuilder(Blueprint print)
        {
            this.print = print; 
        }

        public void LoadTerrain(Texture2D texture)
        {
            for (int i = 0; i < print.board.GetLength(0); i++)
            {
                for (int j = 0; j < print.board.GetLength(1); j++)
                {
                    if (print.board[i, j] == 1)
                    {
                        blocks.Add(new PlatformBlock(j*40, i*22, texture));
                    }
                }
            }
        }

        public void DrawTerrain(SpriteBatch spriteBatch)
        {
            foreach(Block b in blocks)
            {
                spriteBatch.Draw(b.Texture, b.Position, b.Frame, b.Color, 0, new Vector2(0, 0), 2.0f, SpriteEffects.None, 0);
            }
        }
    }
}

