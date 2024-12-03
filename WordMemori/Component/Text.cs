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
            float scale = Setting.WORD_SCALE;

            spriteBatch.DrawString(Game1.Font, word, textPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public static void DrawScoreCurrent(SpriteBatch spriteBatch, int score)
        {
            int x = Setting.CurrentScoreY;
            int y = Setting.CurrentScoreY;
            Vector2 textPosition = new Vector2(x * Setting.SCALE_RATIO, y * Setting.SCALE_RATIO);
            float scale = Setting.SCORE_SCALE;

            spriteBatch.DrawString(Game1.Font, score.ToString(), textPosition, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}
