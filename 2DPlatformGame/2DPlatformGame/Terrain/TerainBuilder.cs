using System;
using System.Collections.Generic;
using DPlatformGame.Interfaces;
using DPlatformGame.Terrain.Blocks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace DPlatformGame.Terrain
{
    public class TerainBuilder
    {
        Blueprint print;

        public List<Block> blocks { get; set; }

        public TerainBuilder(Blueprint print)
        {
            blocks = new List<Block>();
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
                        blocks.Add(new PlatformBlock1(j*32, i*32, texture));
                    }
                    else if (print.board[i, j] == 2)
                    {
                        blocks.Add(new PlatformBlock2(j * 32, i * 32, texture));
                    }
                    else if (print.board[i, j] == 3)
                    {
                        blocks.Add(new PlatformBlock3(j * 32, i * 32, texture));
                    }
                    else if (print.board[i, j] == 4)
                    {
                        blocks.Add(new ExitBlock(j * 32, i * 32, texture));
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

