using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.GameObject;

namespace WordMemori.Component
{
    public class ParallaxBackground
    {
        private int _timer;

        public Sprite Ground;

        public ParallaxBackground()
        {
            Ground = new Sprite("ground", 0, 250);
        }

        public virtual void Update(GameTime gameTime, Game1 game)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Ground.Draw(spriteBatch);
        }
    }
}
