using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemori.Component;
using WordMemori.GameObject;

namespace WordMemori.GameFramework
{
    public class GameScene : SceneBase
    {
        private Random _random;
        private int _timer;
        private bool _gameOver;

        // Gaming Objects
        Player _player;
        List<Item> _items;
        // Dictionary<string, Item>;

        // GameOver Objects
        Sprite _gameOverText;
        Sprite _scoreBoard;
        Button _retryBtn;
        Button _exitBtn;

        // Scoring data
        private int _score;

        // Methods
        private void GameOver()
        {
            // Game over logic
            _gameOver = true;
        }

        public GameScene() : base()
        {
            _random = new Random();
            _timer = 0;
            _gameOver = false;
            _score = 0;

            // Initialize all objects ("file_name", x, y)
            _player = new Player("shark", (Setting.ScreenWidth / 2 - Game1.Textures["shark"].Width / 2), 300);
            _items = new List<Item>();
            _gameOverText = new Sprite("gameover", (Setting.ScreenWidth / 2 - Game1.Textures["gameover"].Width / 2), 100);
        }

        public override void Update(GameTime gameTime, Game1 game, Input input)
        {
            base.Update(gameTime, game, input);

            /// Game is over: Update _retryBtn & _exitBtn-----------------
            if (_gameOver)
            {
              

                return;
            }

            /// Game is on going: Update moving game objects------------------
            _player.Update(gameTime, input);
            foreach(Item item in new List<Item>(_items))
            {
                item.Update(gameTime, input);
                if (item.IsRemoved)
                    _items.Remove(item);

                // Process matching result
                if (_player.CollideWith(item))
                {
                    //item.IsRemoved = true;
                    GameOver();
                }
            }

            // Generate items
            _timer += gameTime.ElapsedGameTime.Milliseconds;
            if(_timer >= Setting.ItemGenerationInterval)
            {
                _timer = 0;
                // use random item name
                Item newItem = new Item("item_name", Setting.ScreenWidth, 50);
                _items.Add(newItem);
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw foods, player
            _player.Draw(spriteBatch);
            foreach(Item item in _items)
                { item.Draw(spriteBatch); }


            // Game on drawing: current score


            // Game over drawing: gameoverText, scoreBoard, retryBtn, exiBtn, finalScore
            if( _gameOver)
            {
                _gameOverText.Draw(spriteBatch);
            }
            
        }

    }
}
