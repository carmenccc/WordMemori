using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.GameObject;
using WordMemori.Component;
using System.Net.Mime;

namespace WordMemori.GameFramework
{
    public class SceneBase
    {
        protected Sprite _background;
        protected ParallaxBackground _parallaxBackground;

        protected List<ParallaxBackground> _parallaxBackgroundsList;
        private float cameraSpeed = 100f;

        public SceneBase()
        {
            //this._background = new Sprite("cloud1", 0, 0);
            this._parallaxBackground = new ParallaxBackground();
        }

        public virtual void Update(GameTime gameTime, Game1 game, Input input)
        {
            this._parallaxBackground.Update(gameTime, game);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //this._background.Draw(spriteBatch);
            this._parallaxBackground.Draw(spriteBatch);
        }
    }
}
