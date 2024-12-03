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

        public MenuScene()
            : base()
        {
            // Initialize logo, menuBoard, instructions & contactInfo, button
            this._logo = new Sprite("logo1", (Setting.ScreenWidth / 2 - Game1.Textures["logo1"].Width / 2), 75);
            this._startBtn = new Button("getready", (Setting.ScreenWidth / 2 - Game1.Textures["getready"].Width / 2), 200);
        }

        public override void Update(GameTime gameTime, Game1 game, Input input)
        {
            base.Update(gameTime, game, input);

            // Update button
            _startBtn.Update(gameTime, input);

            // Handle button pressing logic
            if (_startBtn.IsPressed)
            {
                game.SwitchToScene(Scene.GAME);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw logo, menuBoard, instructions & contactInfo, button
            _logo.Draw(spriteBatch);
            _startBtn.Draw(spriteBatch);
        }
    }
}
