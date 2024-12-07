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
    public class Player : Sprite
    {
        private const float JUMP = -13f;
        private const float ACCELERATION = 0.25f;
        private const float MAX_SPEED = 20f;

        private int _originY;
        private float _speedY = 0;
        private bool _jumping = false;

        public Player(string imgName, int x, int y) : base(imgName, x, y)
        {
            _originY = _destinationRec.Y;
        }

        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            // Stop dropping & reset if player touches the ground
            if(_destinationRec.Y > _originY)
            {
                _jumping = false;
                _speedY = 0;
                _destinationRec.Y = _originY;
            }

            // Jump
            if(input != null)
            {
                if (input.IsSpacePressed())
                {
                    _jumping = true;
                    _speedY = JUMP;
                }
            }
            // Speed decrease when going up, increase when dropping down
            if(_jumping)
            {
                if (_speedY < MAX_SPEED)
                    _speedY += ACCELERATION;
            }
            // Limit position within screen
            if (_destinationRec.Y + (int)_speedY > 0)
                _destinationRec.Y += (int)_speedY;
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
