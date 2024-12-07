using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.Component;
using WordMemori.GameObject;

namespace WordMemori.GameFramework
{
    internal class InstructionScene : SceneBase
    {
        //Display Variables
        private Sprite _menuBoard;
        private Button _menuButton;
        private Sprite _instructions;

        public InstructionScene()
            : base()
        {
            // Initialize menu button
            this._menuBoard = new Sprite("menu-board", (Setting.ScreenWidth / 2 - Game1.Textures["menu-board"].Width / 2), Setting.ScreenHeight / 4);
            this._menuButton = new Button("btnMenu", (Setting.ScreenWidth / 2 - Game1.Textures["btnMenu"].Width / 2), Setting.ScreenHeight * 4 / 5);
            this._instructions = new Sprite("Instructions", Setting.ScreenWidth / 2 - Game1.Textures["Instructions"].Width / 2, Setting.ScreenHeight / 3);
        }

        public override void Update(GameTime gameTime, Game1 game, Input input)
        {
            base.Update(gameTime, game, input);

            _menuButton.Update(gameTime, input);

            // Handle button pressing logic
            if (_menuButton.IsPressed)
            {
                game.SwitchToScene(Scene.MANU);
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw menu button & instructions
            _menuBoard.Draw(spriteBatch);
            _instructions.Draw(spriteBatch);
            _menuButton.Draw(spriteBatch);
        }
    }
}
