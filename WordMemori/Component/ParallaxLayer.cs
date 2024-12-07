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
    public class ParallaxLayer
    {
        public Texture2D Texture { get; }
        public float ScrollSpeed { get; }
        public Vector2 Position { get; set; }
        
        public Rectangle DestinationRec
        {
            get
            {
                return new Rectangle((int)Position.X * Setting.SCALE_RATIO, (int)Position.Y * Setting.SCALE_RATIO, Texture.Width * Setting.SCALE_RATIO, Texture.Height * Setting.SCALE_RATIO);
            }
        }


        //Used for the scrolling
        public ParallaxLayer(Texture2D texture, float scrollSpeed, Vector2 initialPosition)
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
            // Draw seamless texture for looping
            sb.Draw(Texture, DestinationRec, Color.White);

            Rectangle nextRec = new Rectangle((int)(Position.X + Texture.Width) * Setting.SCALE_RATIO, (int)Position.Y * Setting.SCALE_RATIO, Texture.Width * Setting.SCALE_RATIO, Texture.Height * Setting.SCALE_RATIO);
            sb.Draw(Texture, nextRec, Color.White);
        }
    }
}
