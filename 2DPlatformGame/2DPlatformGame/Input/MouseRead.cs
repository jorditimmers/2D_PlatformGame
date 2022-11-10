using System;
using Microsoft.Xna.Framework.Input;

namespace DPlatformGame.Input
{
    public class MouseRead
    {
        public MouseState currentState { get; set; }
        public MouseState PrevState { get; set; }

        public MouseRead()
        {
            currentState = Mouse.GetState();
        }

        public void Update()
        {
            PrevState = currentState;
            currentState = Mouse.GetState();
        }


    }
}

