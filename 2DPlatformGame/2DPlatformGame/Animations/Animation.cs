using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DPlatformGame.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        public Rectangle hitBox;
        private List<AnimationFrame> frames;
        private int counter;
        private double secondCounter;
        private int fps = 15;

        public Animation(Rectangle hitBox)
        {
            this.hitBox = hitBox;
            frames = new List<AnimationFrame>();
            counter = 0;
            secondCounter = 0;
        }

        public void AddFrame(AnimationFrame frame)
        {
            this.frames.Add(frame);
            this.CurrentFrame = this.frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;

            if(secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if(counter >= frames.Count)
            {
                counter = 0;
            }
        }

        public AnimationFrame getFirstFrame()
        {
            return frames[0];
        }

        public void GetFramesFromTextureProperties(int width, int height, int numberOfWidthSprites, int numberOfHeightSprites)
        {
            int widthOfFrame = width / numberOfWidthSprites;
            int heightOfFrame = height / numberOfHeightSprites;

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    frames.Add(new AnimationFrame(new Rectangle(x, y, widthOfFrame, heightOfFrame)));
                }
            }
        }
    }
}

