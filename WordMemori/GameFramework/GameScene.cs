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
            _timer = Setting.ItemGenerationInterval;
            _gameOver = false;
            _score = 0;

            // Load word data
            _wordPool = new List<string> { "Bee Kite", "Dragonfly Kite", "Fish Kite", "Owl Kite", "Rainbow Kite" };
            _itemPool = new string[] { "Bee Kite", "Dragonfly Kite", "Fish Kite", "Owl Kite", "Rainbow Kite" };

            // Initialize all objects ("file_name", x, y)
            _player = new Player("Player Avatar", (Setting.ScreenWidth / 2 - Game1.Textures["Player Avatar"].Width / 2), Setting.PlayerOriginY);
            _items = new List<Item>();
            _gameOverText = new Sprite("btnGameOver", (Setting.ScreenWidth / 2 - Game1.Textures["btnGameOver"].Width / 2), Setting.ScreenHeight / 4);
            _scoreBoard = new Sprite("score-board", (Setting.ScreenWidth / 2 - Game1.Textures["score-board"].Width / 2), Setting.ScreenHeight / 3);
            _retryBtn = new Button("btnRetry", (Setting.ScreenWidth / 3 - Game1.Textures["btnRetry"].Width / 2), Setting.GameOverBtnY);
            _exitBtn = new Button("btnQuit", (Setting.ScreenWidth * 2 / 3 - Game1.Textures["btnQuit"].Width / 2), Setting.GameOverBtnY);
        }

        public override void Update(GameTime gameTime, Game1 game, Input input)
        {
            base.Update(gameTime, game, input);

            /// Game is over: Update _retryBtn & _exitBtn-----------------
            if (_gameOver)
            {
                _retryBtn.Update(gameTime, input);
                _exitBtn.Update(gameTime, input);

                if (_retryBtn.IsPressed) { game.SwitchToScene(Scene.MANU); }
                if (_exitBtn.IsPressed) { game.Exit(); }

                return;
            }

            /// Game is on going: Update moving game objects------------------
            _player.Update(gameTime, input);

            // Generate word
            if (_wordPool.Count == 0){
                GameOver();
            }
            else if (_wordPool.Count > 0)
            {
                _word = _wordPool[0];

                // Generate items
                _timer += gameTime.ElapsedGameTime.Milliseconds;
                if (_timer >= Setting.ItemGenerationInterval)
                {
                    _timer = 0;
                    // Random item
                    int index = _random.Next(0, _itemPool.Length);
                    string fileName = _itemPool[index];
                    if(_items.Count > 0 && fileName == _items[_items.Count - 1].Word)
                    {
                        fileName = _itemPool[index < (_itemPool.Length - 1) ? index + 1 : 0];
                    }
                    Item newItem = new Item($"{fileName}", Setting.ScreenWidth, Setting.ItemGenerationY);

                    _items.Add(newItem);
                }
            }

            // Update items
            foreach (Item item in new List<Item>(_items))
            {
                if (item.IsRemoved)
                {
                    _items.Remove(item);
                    continue;
                }
                item.Update(gameTime, input);

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
                        GameOver();
                        // ...play fail soundeffect...
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            // Draw items, player
            _player.Draw(spriteBatch);
            
            foreach(Item item in _items)
                { item.Draw(spriteBatch); }


            // Game on drawing: ...word, score...
            if (!_gameOver)
            {
                Text.DrawWord(spriteBatch, _word);
                Text.DrawScoreCurrent(spriteBatch, _score);
            }

            // Game over drawing: ...scoreBoard, retryBtn, exiBtn, finalScore...
            if( _gameOver)
            {
                //_scoreBoard.Draw(spriteBatch);
                _gameOverText.Draw(spriteBatch);
                Text.DrawScoreResult(spriteBatch, _score);
                _retryBtn.Draw(spriteBatch);
                _exitBtn.Draw(spriteBatch);
            }
            
        }

    }
}
