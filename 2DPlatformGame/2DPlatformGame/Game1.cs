using DPlatformGame.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2DPlatformGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D _SamuraiIdleTexture;
    Texture2D _SamuraiMoveTexture;
    Texture2D _LevelBackground;

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

        samurai = new Samurai(_SamuraiIdleTexture, _SamuraiMoveTexture);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        //Load sprites
        _SamuraiIdleTexture = Content.Load<Texture2D>("samurai/idle");
        _SamuraiMoveTexture = Content.Load<Texture2D>("samurai/run");
        _LevelBackground = Content.Load<Texture2D>("Background");
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
        _spriteBatch.Draw(_LevelBackground, new Rectangle(0,0,1280,720), Color.White);
        samurai.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}

