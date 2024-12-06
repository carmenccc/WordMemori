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
        private Button _menuButton;
        private Sprite _instructions;

        public InstructionScene()
            : base()
        {
            // Initialize menu button
            this._menuButton = new Button("btnMenu", (Setting.ScreenWidth / 2 - Game1.Textures["btnMenu"].Width / 2), Setting.ScreenHeight / 8);
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
            _instructions.Draw(spriteBatch);
            _menuButton.Draw(spriteBatch);
        }
    }
}
