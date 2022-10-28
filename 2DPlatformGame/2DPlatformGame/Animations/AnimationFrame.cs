using System;
using Microsoft.Xna.Framework;

namespace DPlatformGame.Animations
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle sourceRectangle)
        {
            this.SourceRectangle = sourceRectangle;
        }
    }
}

