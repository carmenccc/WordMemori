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
        public static float WORD_SCALE = 1f;
        public static float SCORE_SCALE = 0.5f;
        public static float MENU_FONT_SCALE = 1f;

        public static int ScreenWidth = 480;
        public static int ScreenHeight = 324;
        public static int PlayerOriginY = ScreenHeight / 3 * 2;
        public static int WordY = 30;
        public static int ScoreCurrentX = 10;
        public static int ScoreCurrentY = 10;
        public static int ScoreResultY = 150;
        public static int MenuBoardY;
        public static int ScoreBoardX;
        public static int MenuBtnY = 250;
        public static int GameOverBtnY = 200;

        // Gaming setting
        public static int ItemScrollSpeed = 1;
        public static int ItemGenerationInterval = 3000;
        public static int ItemGenerationY = 70;

        public static string Instruction;
        public static string ContactInfo1 = 
            $"Cai, Huiwen: hcai2586@conestogac.on.ca";
        public static string ContactInfo2 =
            $"Xiong, Elowynne: exiong5293@conestogac.on.ca";
    }
}
