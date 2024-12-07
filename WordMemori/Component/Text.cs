using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemori.Component
{
    public class Text
    {
        public static SpriteFont Font = Game1.Font;

        /// <summary>
        /// Draw word on center of screen horizontally with scale of Setting.WORD_SCALE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="word">A string of the current word</param>
        public static void DrawWord(SpriteBatch spriteBatch, string word)
        {
            Vector2 size = Font.MeasureString(word);
            int x = (Setting.ScreenWidth - (int)size.X) / 2;
            int y = Setting.WordY;
            Vector2 textPosition = new Vector2(x * Setting.SCALE_RATIO, y * Setting.SCALE_RATIO);
            float scale = Setting.WORD_SCALE * Setting.SCALE_RATIO;

            spriteBatch.DrawString(Game1.Font, word, textPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Draw current score on top-left of screen using Setting position with scale of Setting.WORD_SCALE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="score"></param>
        public static void DrawScoreCurrent(SpriteBatch spriteBatch, int score)
        {
            string scoreStr = "SCORE: " + score;
            int x = Setting.ScoreCurrentX;
            int y = Setting.ScoreCurrentY;
            Vector2 textPosition = new Vector2(x * Setting.SCALE_RATIO, y * Setting.SCALE_RATIO);
            float scale = Setting.SCORE_SCALE * Setting.SCALE_RATIO;

            spriteBatch.DrawString(Game1.Font, scoreStr, textPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Draw result score on center of screen horizontally with scale of Setting.GRADE_SCALE
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="score"></param>
        public static void DrawScoreResult(SpriteBatch spriteBatch, int score)
        {
            string scoreStr = "Your Score: " + score;
            Vector2 size = Font.MeasureString(scoreStr);
            int x = (Setting.ScreenWidth - (int)size.X) / 2;
            int y = Setting.ScoreResultY;
            Vector2 textPosition = new Vector2(x * Setting.SCALE_RATIO, y * Setting.SCALE_RATIO);
            float scale = Setting.SCORE_SCALE * Setting.SCALE_RATIO * 2;

            spriteBatch.DrawString(Game1.Font, scoreStr, textPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
