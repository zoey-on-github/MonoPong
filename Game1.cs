using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong;


public class Game1 : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D pixel;
    private Texture2D ballTexture;
    private Rectangle leftPaddle;
    private Rectangle rightPaddle;
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // A single-pixel texture
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData<Color>(new Color[]
        {
            Color.White
        });
        leftPaddle = new Rectangle(100, 100, 30, 100);
        rightPaddle = new Rectangle(700, 100, 30, 100);
        ballTexture = Content.Load<Texture2D>("circle");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            leftPaddle.Y -= 10;
        }
        // TODO: Add your update logic here

        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Draw(pixel, leftPaddle, Color.White);
        _spriteBatch.Draw(pixel, rightPaddle, Color.White);
        _spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
