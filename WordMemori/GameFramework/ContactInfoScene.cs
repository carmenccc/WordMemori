using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.Component;
using WordMemori.GameObject;
using static System.Formats.Asn1.AsnWriter;

namespace WordMemori.GameFramework
{
    internal class ContactInfoScene : SceneBase
    {
        //Display Variables
        private Button _menuButton;

        public ContactInfoScene()
            : base()
        {
            // Initialize menu button
            this._menuButton = new Button("btnMenu", (Setting.ScreenWidth / 2 - Game1.Textures["btnMenu"].Width / 2), Setting.ScreenHeight / 8);
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

            // Draw logo, menuBoard, instructions & contactInfo, button
            _menuButton.Draw(spriteBatch);
            Text.DrawContactInformation(spriteBatch, Setting.ContactInfo1, 1);
            Text.DrawContactInformation(spriteBatch, Setting.ContactInfo2, 2);
        }
    }
}
