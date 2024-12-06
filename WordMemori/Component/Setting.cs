﻿using System;
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
        public static int ScreenHeight = 275;
        public static int GroundLevelY = 300;
        public static int WordY = 10;
        public static int ScoreCurrentX = 10;
        public static int ScoreCurrentY = 10;
        public static int ScoreResultY = 150;
        public static int MenuBoardY;
        public static int ScoreBoardX;
        public static int MenuBtnY = 250;
        public static int GameOverBtnY = 200;

        // Gaming setting
        public static int ItemScrollSpeed = 10;
        public static int ItemGenerationInterval = 3000;

        public static string Instruction;
        public static string ContactInfo = 
            $"Cai, Huiwen: hcai2586@conestogac.on.ca \n" +
            $"Xiong, Elowynne: exiong5293@conestogac.on.ca";
    }
}
