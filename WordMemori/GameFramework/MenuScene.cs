using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.Component;
using WordMemori.GameObject;

namespace WordMemori.GameFramework
{
    public class MenuScene : SceneBase
    {
        // Menu objects
        private Sprite _logo;
        private Sprite _menuBoard;
        private Button _startBtn;
        private Button _instructionsBtn;
        private Button _contactInfoBtn;
        private Button _exitBtn;

        public MenuScene()
            : base()
        {
            // Initialize logo, menuBoard, instructions & contactInfo, button
            this._logo = new Sprite("gameLogo", (Setting.ScreenWidth / 2 - Game1.Textures["gameLogo"].Width / 2), Setting.ScreenHeight / 5); //Top
            this._startBtn = new Button("btnStart", (Setting.ScreenWidth / 3 - Game1.Textures["btnStart"].Width / 2), Setting.ScreenHeight * 4 / 5); //Bottom-left
            this._exitBtn = new Button("btnQuit", (Setting.ScreenWidth / 2 + Game1.Textures["btnQuit"].Width / 2), Setting.ScreenHeight * 4 / 5); // Bottom-right

            //Adding the instructions and contact info buttons
            this._instructionsBtn = new Button("btnInstructions", (Setting.ScreenWidth / 2 - Game1.Textures["btnInstructions"].Width / 2), Setting.ScreenHeight * 3 / 5); //Middle-top
            this._contactInfoBtn = new Button("btnContactInfo", (Setting.ScreenWidth / 2 - Game1.Textures["btnContactInfo"].Width / 2), Setting.ScreenHeight * 2 / 5); //Middle-bottom
        }

        public override void Update(GameTime gameTime, Game1 game, Input input)
        {
            base.Update(gameTime, game, input);

            // Update button
            _startBtn.Update(gameTime, input);
            _instructionsBtn.Update(gameTime, input);
            _contactInfoBtn.Update(gameTime, input);
            _exitBtn.Update(gameTime, input);


            // Handle button pressing logic
            if (_startBtn.IsPressed)
            {
                game.SwitchToScene(Scene.GAME);
            }

            //Switch to instruction scene
            if (_instructionsBtn.IsPressed)
            {
                game.SwitchToScene(Scene.INSTRUCTIONS);
            }

            //Switch to Contact info scene
            if (_contactInfoBtn.IsPressed)
            {
                game.SwitchToScene(Scene.CONTACTINFO);
            }

            if (_exitBtn.IsPressed) { game.Exit(); }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw logo, menuBoard, instructions & contactInfo, button
            _logo.Draw(spriteBatch);
            _startBtn.Draw(spriteBatch);
            _instructionsBtn.Draw(spriteBatch);
            _contactInfoBtn.Draw(spriteBatch);
            _exitBtn.Draw(spriteBatch);
        }
    }
}
