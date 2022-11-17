
using System;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DPlatformGame.Input
{
    public class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
            {
                direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                direction.Y = -12345;
            }
            return direction;
        }
    }
}

