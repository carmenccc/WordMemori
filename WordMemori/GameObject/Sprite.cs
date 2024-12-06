using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.Component;

namespace WordMemori.GameObject
{
    public class Sprite
    {
        protected Texture2D _texture;
        protected Rectangle _destinationRec;
        protected Color _color;

        public bool CollideWith(Sprite sprite)
        {
            return this._destinationRec.Intersects(sprite._destinationRec);
        }

        public Sprite(string imgName, int x, int y)
        {
            this._texture = Game1.Textures[imgName];
            this._color = Color.White;
            this._destinationRec = new Rectangle
                (
                x * Setting.SCALE_RATIO, y * Setting.SCALE_RATIO, 
                this._texture.Width * Setting.SCALE_RATIO, 
                this._texture.Height * Setting.SCALE_RATIO
                );
        }
        
        public virtual void Update(GameTime gameTime, Input input)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this._texture, this._destinationRec, null, this._color);
        }

        //public Texture2D ReturnTexture (Sprite sprite)
        //{
        //    return this._texture;
        //}
    }
}
