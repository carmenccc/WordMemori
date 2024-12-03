using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemori.Component
{
    public class Setting
    {
        // Styling
        public static int SCALE_RATIO = 2;
        public static float WORD_SCALE = 2f;
        public static float SCORE_SCALE = 2f;
        public static float MENU_FONT_SCALE = 1f;

        public static int ScreenWidth = 576;
        public static int ScreenHeight = 324;
        public static int GroundLevelY = 300;
        public static int WordY = 30;
        public static int CurrentScoreX = 10;
        public static int CurrentScoreY = 10;

        // Gaming setting
        public static int ItemScrollSpeed = 16;
        public static int ItemGenerationInterval = 3000;

        public static string Instruction;
        public static string ContactInfo;
    }
}
