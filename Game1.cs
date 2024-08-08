using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoPong;


public class Game1 : Game {

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D pixel;
    private Texture2D ballTexture;
    private Rectangle leftPaddle;
    private Rectangle rightPaddle;
    private float paddleSpeed;
    private Vector2 ballPosition;
    private Vector2 ballVelocity;
    private Rectangle ball;
    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // A single-pixel texture
    }

    protected override void Initialize() {
        paddleSpeed = 500f;
        ballPosition = new Vector2(0, 0);
        ballVelocity = new Vector2(5f, 1f);
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        pixel = new Texture2D(GraphicsDevice, 1, 1);
        pixel.SetData(new Color[] {
            Color.White
        });
        leftPaddle = new Rectangle(100, 100, 30, 100);
        rightPaddle = new Rectangle(700, 100, 30, 100);
        ball = new Rectangle((int)ballPosition.X,(int)ballPosition.Y,70, 70);
        ballTexture = Content.Load<Texture2D>("circle");
    }
    protected override void Update(GameTime gameTime) {
       var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
       if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)) {
           Exit();
       }
       rightPaddle.Y = (int)ballPosition.Y;
       float ballTest = ballPosition.X += ballVelocity.X;
       if (ball.Right <= _graphics.PreferredBackBufferWidth) {
           ballPosition.X--;
       }

       int testPositionX = leftPaddle.Top - (int)(paddleSpeed * delta);
       if (Keyboard.GetState().IsKeyDown(Keys.Up) && testPositionX >= 0) {
           leftPaddle.Y -= (int)(paddleSpeed * delta);
       }
       //}
       int testPositionY = leftPaddle.Bottom + (int)(paddleSpeed * delta);
       if (Keyboard.GetState().IsKeyDown(Keys.Down) && testPositionY <= _graphics.PreferredBackBufferHeight) {
           leftPaddle.Y += (int)(paddleSpeed * delta);
       }

//        ballPosition.X++;
        if (ballTest >= +_graphics.PreferredBackBufferWidth) {
            ballPosition.X += ballVelocity.X;
        }
        else {
            return;
        }
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime) {
        _spriteBatch.Begin();
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Draw(pixel, leftPaddle, Color.White);
        _spriteBatch.Draw(pixel, rightPaddle, Color.White);
        _spriteBatch.Draw(ballTexture, ballPosition, ball, Color.White);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}