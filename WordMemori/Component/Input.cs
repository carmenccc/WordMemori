using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemori.Component
{
    public class Input
    {
        private MouseState _oldMouse;
        private MouseState _mouse;

        private KeyboardState _oldKeyboard;
        private KeyboardState _keyboard;

        public Input(MouseState oldMouse, MouseState mouse, KeyboardState oldKeyboard, KeyboardState keyboard)
        {
            _oldMouse = oldMouse;
            _mouse = mouse;
            _oldKeyboard = oldKeyboard;
            _keyboard = keyboard;
        }

        // Mouse input
        public Point GetMousePosition()
        {
            return new Point(_mouse.X, _mouse.Y);
        }

        public bool IsLeftMouseDown()
        {
            return _mouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftMousePressed()
        {
            return _oldMouse.LeftButton == ButtonState.Pressed
                && _mouse.LeftButton == ButtonState.Released;
        }

        // Keyboard input
        public bool IsSpacePressed()
        {
            return _oldKeyboard.IsKeyDown(Keys.Space)
                && _keyboard.IsKeyUp(Keys.Space);
        }
    }
}
