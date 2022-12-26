using System;
using System.Numerics;
using _2DPlatformGame;
using DPlatformGame.Enums;
using DPlatformGame.Input;
using DPlatformGame.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DPlatformGame.GameObjects
{
    public class Button : IGameObject
    {
        public int Button_X { get; set; }
        public int Button_Y { get; set; }
        public string Name { get; set; }
        public Rectangle Frame { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private Texture2D texture;

        MouseRead MouseInput;

        public Button(string name, Texture2D texture, int buttonX, int buttonY)
        {
            this.Name = name;
            this.texture = texture;
            this.Button_X = buttonX;
            this.Button_Y = buttonY;
            MouseInput = new MouseRead();
        }

        public bool enterButton()
        {
            if (MouseInput.currentState.X < Button_X + texture.Width &&
            MouseInput.currentState.X > Button_X &&
                    MouseInput.currentState.Y < Button_Y + texture.Height &&
                    MouseInput.currentState.Y > Button_Y)
            {
                return true;
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle((int)Button_X, (int)Button_Y, texture.Width, texture.Height), Color.White);
        }

        public void Update(GameTime gameTime)
        {
            MouseInput.Update();
        }

        public GameState GetGameState()
        {
            if (enterButton() && MouseInput.PrevState.LeftButton == ButtonState.Released && MouseInput.currentState.LeftButton == ButtonState.Pressed)
            {
                switch (Name)
                {
                    case "playbutton": //the name of the button
                        return GameState.Playing;
                    case "backbutton":
                        return GameState.Quiting;
                    default:
                        break;
                }
            }
            return GameState.Menu;
        }
    }
}

