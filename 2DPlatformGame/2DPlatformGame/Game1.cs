using DPlatformGame.Characters;
using DPlatformGame.Enums;
using DPlatformGame.GameObjects;
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
    Texture2D _SamuraiJumpTexture;
    Texture2D _LevelBackgroundTexture;
    Texture2D _PlayButton;
    Texture2D _BackButton;

    GameState _GameState;

    Texture2D _FloorTexture;
    Rectangle _FloorRect;

    Button playbutton;
    Button backbutton;

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

        samurai = new Samurai(_SamuraiIdleTexture, _SamuraiMoveTexture, _SamuraiJumpTexture);
        playbutton = new Button("playbutton", _PlayButton, (_graphics.PreferredBackBufferWidth/2)-(_PlayButton.Width/2), (_graphics.PreferredBackBufferHeight / 2) - (_PlayButton.Height / 2));
        backbutton = new Button("backbutton", _BackButton, (_graphics.PreferredBackBufferWidth / 2) - (_PlayButton.Width / 2), (_graphics.PreferredBackBufferHeight / 2) + 40);


        _GameState = GameState.Menu;
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
        _SamuraiJumpTexture = Content.Load<Texture2D>("samurai/jump");
        _LevelBackgroundTexture = Content.Load<Texture2D>("Background");
        _PlayButton = Content.Load<Texture2D>("playbutton");
        _BackButton = Content.Load<Texture2D>("backbutton");

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            _GameState = GameState.Menu;

        if (_GameState == GameState.Menu)
        {
            playbutton.Update(gameTime);
            _GameState = playbutton.GetGameState();
            if(_GameState == GameState.Menu)
            {
                backbutton.Update(gameTime);
                _GameState = backbutton.GetGameState();
            }
        }
        else if (_GameState == GameState.Playing)
        {
            //Update characters
            samurai.Update(gameTime);
        }
        else if (_GameState == GameState.Quiting)
        {
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkGray);

        if(_GameState == GameState.Menu)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            _spriteBatch.Draw(_LevelBackgroundTexture, new Rectangle(0, 0, 1280, 720), Color.White); //Background
            playbutton.Draw(_spriteBatch);
            backbutton.Draw(_spriteBatch);
            _spriteBatch.End();
        }
        else if(_GameState == GameState.Playing)
        {
            //Draw Characters
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, null, null);
            _spriteBatch.Draw(_LevelBackgroundTexture, new Rectangle(0, 0, 1280, 720), Color.White); //Background
            //_spriteBatch.Draw(_FloorTexture, _FloorRect, Color.Aqua); //Floor for debugging
            samurai.Draw(_spriteBatch); //Samurai
            _spriteBatch.End();
        }

        base.Draw(gameTime);
    }
}