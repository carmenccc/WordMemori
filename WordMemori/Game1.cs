using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using WordMemori.Component;
using WordMemori.GameFramework;

namespace WordMemori
{
    public enum Scene
    {
        MANU,
        GAME,
        INSTRUCTIONS,
        CONTACTINFO
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SceneBase _scene;
        MouseState _oldMouseState;
        KeyboardState _oldKeyboardState;

        // Resources
        public static Dictionary<string, Texture2D> Textures;
        public static Dictionary<string, SoundEffect> Sounds;
        public static SpriteFont Font;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Set screen size
            _graphics.PreferredBackBufferWidth = Setting.ScreenWidth * Setting.SCALE_RATIO;
            _graphics.PreferredBackBufferHeight = Setting.ScreenHeight * Setting.SCALE_RATIO;
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            _scene = new MenuScene();
            _oldMouseState = Mouse.GetState();
            _oldKeyboardState = Keyboard.GetState();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Textures = new Dictionary<string, Texture2D>();
            List<string> images = new List<string>()
            {
                "getready",
                "item_name",
                "ground",
                "Player Avatar",
                "Sun",
                "StaticSky Background",
                "Bee Kite",
                "Dragonfly Kite",
                "Fish Kite",
                "Owl Kite",
                "Rainbow Kite",
                "btnContactInfo",
                "btnInstructions",
                "btnQuit",
                "btnRetry",
                "btnStart",
                "btnGameOver",
                "btnMenu",
                "gameLogo",
                "Instructions",
                "bluesky",
                "cloudblue1",
                "cloudblue2",
                "cloudblue3",
            };
            foreach (var i in images)
            {
                Textures.Add(i, Content.Load<Texture2D>(i));
            }

            

            // Load Font
            Font = Content.Load<SpriteFont>("Font/Arial");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update Scene
            Input input = new Input(_oldMouseState, Mouse.GetState(), _oldKeyboardState, Keyboard.GetState());
            _scene.Update(gameTime, this, input);

            _oldMouseState = Mouse.GetState();
            _oldKeyboardState = Keyboard.GetState();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            

            this._scene.Draw(this._spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // Helper method to switch scene
        public void SwitchToScene(Scene scene)
        {
            switch (scene)
            {
                case Scene.MANU:
                    _scene = new MenuScene();
                    break;
                case Scene.GAME:
                    _scene = new GameScene();
                    break;
                case Scene.INSTRUCTIONS:
                    _scene = new InstructionScene();
                    break;
                case Scene.CONTACTINFO:
                    _scene = new ContactInfoScene();
                    break;
                default:
                    break;
            }
        }

    }
}
