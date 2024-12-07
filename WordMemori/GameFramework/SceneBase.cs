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
        private float cameraSpeed = 200f;
        public static List<ParallaxLayer> parallaxLayers;

        public SceneBase()
        {
            parallaxLayers = new List<ParallaxLayer>
            {
                new ParallaxLayer(Game1.Textures["bg-purple"], 0f, new Vector2(0, 0)),
                new ParallaxLayer(Game1.Textures["cloud-1"], 0.2f, new Vector2(0, 0)),
                new ParallaxLayer(Game1.Textures["cloud-2"], 0.3f, new Vector2(0, 0)),
                new ParallaxLayer(Game1.Textures["cloud-3"], 0.5f, new Vector2(0, 0))
            };
        }

        public virtual void Update(GameTime gameTime, Game1 game, Input input)
        {
           
            //Constantly have the background scrolling
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var layer in parallaxLayers)
            {
                layer.Update(deltaTime, cameraSpeed);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //this._background.Draw(spriteBatch);
            //Continue to load scrolling background
            foreach (var item in parallaxLayers)
            {
                item.Draw(spriteBatch, 0);
            }
        }
    }
}
