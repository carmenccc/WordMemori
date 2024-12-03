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
        // State Properties
        private Random _random;
        private int _timer;
        private bool _gameOver;
        string _word = "";
        bool _matched;

        // Gaming Objects
        Player _player;
        List<Item> _items;
        List<string> _wordPool;
        String[] _itemPool;

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

            // Load word data
            _wordPool = new List<string> { "word1", "word2", "word3" };
            _itemPool = new string[] { "word1", "word2", "word3" };

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

            // Generate word
            if (_wordPool.Count == 0){
                GameOver();
                return;
            }
            else if (_wordPool.Count > 0)
            {
                _word = _wordPool[0];
            }

            // Update items
            foreach (Item item in new List<Item>(_items))
            {
                item.Update(gameTime, input);
                if (item.IsRemoved)
                    _items.Remove(item);
                
                if (_player.CollideWith(item))
                {
                    item.IsRemoved = true;
                    // Process matching result
                    if (item.Word == _word)
                    {
                        _score++;
                        _wordPool.RemoveAt(0);
                    }
                    else
                    {
                        _score--;
                        //GameOver();
                        // ...play fail soundeffect...
                    }
                }
            }

            // Generate items
            _timer += gameTime.ElapsedGameTime.Milliseconds;
            if(_timer >= Setting.ItemGenerationInterval)
            {
                _timer = 0;
                // random item
                string fileName = _itemPool[_random.Next(0, _itemPool.Length)];
                Item newItem = new Item($"{fileName}", Setting.ScreenWidth, 50);
                _items.Add(newItem);
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw items, player, word
            _player.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.Font, _word, new Vector2(20, 20), Color.White);
            foreach(Item item in _items)
                { item.Draw(spriteBatch); }


            // Game on drawing: ...score...


            // Game over drawing: ...scoreBoard, retryBtn, exiBtn, finalScore...
            if( _gameOver)
            {
                _gameOverText.Draw(spriteBatch);
                
            }
            
        }

    }
}
