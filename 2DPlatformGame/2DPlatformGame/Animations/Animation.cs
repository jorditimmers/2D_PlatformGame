using System;
using System.Collections.Generic;

namespace DPlatformGame.Animations
{
    public class Animation
    {
        public AnimationFrame CurrentFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;

        public Animation()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame frame)
        {
            this.frames.Add(frame);
            this.CurrentFrame = this.frames[0];
        }

        public void Update()
        {
            CurrentFrame = frames[counter];
            counter++;
            if(counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}

