using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WordMemori.Component;

namespace WordMemori.GameObject
{
    public class Item : Sprite
    {
        private int _timer = 0;
        private bool _isRemoved = false;
        public bool IsRemoved
        {
            get { return _isRemoved; }
            set { _isRemoved = value; }
        }

        public string Word { get; set; }

        public Item(string imgName, int x, int y) : base(imgName, x, y)
        {
            Word = imgName;
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            _timer += gameTime.ElapsedGameTime.Milliseconds;

            if(_timer >= Setting.ItemScrollSpeed)
            {
                _timer = 0;

                // scrolling
                _destinationRec.X -= Setting.SCALE_RATIO;

                if(_destinationRec.Right < 0)
                    _isRemoved = true;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }

    
}
