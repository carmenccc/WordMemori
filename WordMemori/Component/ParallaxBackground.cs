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
        public Texture2D Texture { get; }
        public float ScrollSpeed { get; }
        public Vector2 Position { get; set; }

        public ParallaxBackground()
        {
            //Ground = new Sprite("ground", 0, 200);
        }
        public virtual void Update(GameTime gameTime, Game1 game)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //Ground.Draw(spriteBatch);
        }


        //Used for the scrolling
        public ParallaxBackground(Texture2D texture, float scrollSpeed, Vector2 initialPosition)
        {
            Texture = texture;
            ScrollSpeed = scrollSpeed;
            Position = initialPosition;
        }

        public void Update(float deltaTime, float cameraSpeed)
        {
            Position = new Vector2(Position.X - cameraSpeed * ScrollSpeed * deltaTime, Position.Y);

            if (Position.X < -Texture.Width)
            {
                Position = new Vector2(Position.X + Texture.Width, Position.Y);
            }
        }

        public void Draw(SpriteBatch sb, int placeholder)
        {
            sb.Draw(Texture, Position, Color.White);
            sb.Draw(Texture, new Vector2(Position.X + Texture.Width, Position.Y), Color.White);
        }
    }
}
