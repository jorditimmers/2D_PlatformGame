using DPlatformGame.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace _2DPlatformGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D _SamuraiIdleTexture;
    Texture2D _SamuraiMoveTexture;
    Texture2D _LevelBackgroundTexture;

    Texture2D _FloorTexture;
    Rectangle _FloorRect;

    Samurai samurai;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize(); //Put logic AFTER this

        _FloorRect = new Rectangle(0, 720-64 ,1280,64);

        samurai = new Samurai(_SamuraiIdleTexture, _SamuraiMoveTexture);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //Loading and creating floor texture
        _FloorTexture = new Texture2D(GraphicsDevice, 1, 1);
        _FloorTexture.SetData(new[] { Color.White });

        //Load sprites
        _SamuraiIdleTexture = Content.Load<Texture2D>("samurai/idle");
        _SamuraiMoveTexture = Content.Load<Texture2D>("samurai/run");
        _LevelBackgroundTexture = Content.Load<Texture2D>("Background");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        //Update characters
        samurai.Update(gameTime);     

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkGray);

        //Draw Characters
        _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
        _spriteBatch.Draw(_LevelBackgroundTexture, new Rectangle(0,0,1280,720), Color.White); //Background
        //_spriteBatch.Draw(_FloorTexture, _FloorRect, Color.Aqua); //Floor
        samurai.Draw(_spriteBatch); //Samurai
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

