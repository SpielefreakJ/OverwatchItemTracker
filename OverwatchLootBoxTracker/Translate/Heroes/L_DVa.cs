﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OverwatchLootBoxTracker.Translate
{
    class L_DVa : PictureBox
    {
        Languages.English.Heroes.DVa EN;
        Languages.German.Heroes.DVa DE;
        Translate.L_Translate Translate;
        CCost Costs;
        string myLang;
        string[] LangAndCost;

        public L_DVa(string Lang)
        {
            if (Lang != "")
            {
                myLang = Lang;
            }

            Costs = new CCost();
            EN = new Languages.English.Heroes.DVa();
            DE = new Languages.German.Heroes.DVa();
            Translate = new Translate.L_Translate(Lang);

            LangAndCost = new string[3];

            SizeMode = PictureBoxSizeMode.AutoSize;
            Image = Image.FromFile("Images\\D.Va_link.png");
        }

        public string ChangeLang
        {
            get
            {
                return myLang;
            }
            set
            {
                myLang = value;
            }
        }

        public string GetName()
        {
            if (myLang == "DE")
            {
                return DE.Name;
            }
            else
            {
                return EN.Name;
            }
        }


        //Skin
        //Rare
        public string[] Blueberry_SK//1
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Blueberry_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Blueberry_SK;
                }
                LangAndCost[1] = Costs.Rare.ToString();
                LangAndCost[2] = Translate.Rare;
                return LangAndCost;
            }
        }

        public string[] Lemon_Lime_SK//2
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Lemon_Lime_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Lemon_Lime_SK;
                }
                LangAndCost[1] = Costs.Rare.ToString();
                LangAndCost[2] = Translate.Rare;
                return LangAndCost;
            }
        }

        public string[] Tangerine_SK//3
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Tangerine_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Tangerine_SK;
                }
                LangAndCost[1] = Costs.Rare.ToString();
                LangAndCost[2] = Translate.Rare;
                return LangAndCost;
            }
        }

        public string[] Watermelon_SK//4
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Watermelon_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Watermelon_SK;
                }
                LangAndCost[1] = Costs.Rare.ToString();
                LangAndCost[2] = Translate.Rare;
                return LangAndCost;
            }
        }
        //Epic
        public string[] Carbon_Fiber_SK//5
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Carbon_Fiber_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Carbon_Fiber_SK;
                }
                LangAndCost[1] = Costs.Epic.ToString();
                LangAndCost[2] = Translate.Epic;
                return LangAndCost;
            }
        }

        public string[] White_Rabbit_SK//6
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.White_Rabbit_SK;
                }
                else
                {
                    LangAndCost[0] = EN.White_Rabbit_SK;
                }
                LangAndCost[1] = Costs.Epic.ToString();
                LangAndCost[2] = Translate.Epic;
                return LangAndCost;
            }
        }

        public string[] Taegeukgi_SK//7
        {//Summer 2016
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Taegeukgi_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Taegeukgi_SK;
                }
                LangAndCost[1] = Costs.Epic.ToString();
                LangAndCost[2] = Translate.Summer + " 2016";
                return LangAndCost;
            }
        }
        //Legendary
        public string[] Junker_SK//8
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Junker_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Junker_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] Scavenger_SK//9
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Scavenger_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Scavenger_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] BVa_SK//10
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.BVa_SK;
                }
                else
                {
                    LangAndCost[0] = EN.BVa_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] Junebug_SK//11
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Junebug_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Junebug_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] Black_Cat_SK//15
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Black_Cat_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Black_Cat_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] Officer_SK//12
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Officer_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Officer_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Legendary;
                return LangAndCost;
            }
        }

        public string[] Palanquin_SK//13
        {//Rooster 2017
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Palanquin_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Palanquin_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Rooster + " 2017";
                return LangAndCost;
            }
        }

        public string[] Cruiser_SK//14
        {//Annyver 2017
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Cruiser_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Cruiser_SK;
                }
                LangAndCost[1] = Costs.Legendary.ToString();
                LangAndCost[2] = Translate.Annyver + " 2017";
                return LangAndCost;
            }
        }

        public string[] Waveracer_SK//15
        {//Annyver 2017
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Waveracer_SK;
                }
                else
                {
                    LangAndCost[0] = EN.Waveracer_SK;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }


        //Emotes
        //Epic
        public string[] _O__EM//1
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE._O__EM;
                }
                else
                {
                    LangAndCost[0] = EN._O__EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Bunny_Hop_EM//2
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Bunny_Hop_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Bunny_Hop_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Heartbreaker_EM//3
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Heartbreaker_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Heartbreaker_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Party_Time_EM//4
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Party_Time_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Party_Time_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Bow_EM//5
        {//Rooster 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Bow_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Bow_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Dance_EM//6
        {//Annyver 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Dance_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Dance_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }
        //Legendary
        public string[] Game_On_EM
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Game_On_EM;
                }
                else
                {
                    LangAndCost[0] = EN.Game_On_EM;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }


        //Victory Poses
        //Rare
        public string[] I_Heart_You_VP//1
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.I_Heart_You_VP;
                }
                else
                {
                    LangAndCost[0] = EN.I_Heart_You_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Peace_VP//2
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Peace_VP;
                }
                else
                {
                    LangAndCost[0] = EN.Peace_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Sitting_VP//3
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Sitting_VP;
                }
                else
                {
                    LangAndCost[0] = EN.Sitting_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] RIP_VP//4
        {//Halloween 16
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.RIP_VP;
                }
                else
                {
                    LangAndCost[0] = EN.RIP_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Festive_VP//5
        {//Winter 16
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Festive_VP;
                }
                else
                {
                    LangAndCost[0] = EN.Festive_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Lucky_Pouch_VP//6
        {//Rooster 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Lucky_Pouch_VP;
                }
                else
                {
                    LangAndCost[0] = EN.Lucky_Pouch_VP;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }


        //Voice Lines
        //Common
        public string[] Love_DVa_VL//1
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Love_DVa_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Love_DVa_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Winkyface_VL//2
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Winkyface_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Winkyface_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] A_new_challenger_VL//3
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.A_new_challenger_VL;
                }
                else
                {
                    LangAndCost[0] = EN.A_new_challenger_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] AFK_VL//4
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.AFK_VL;
                }
                else
                {
                    LangAndCost[0] = EN.AFK_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Aw_Yeah_VL//5
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Aw_Yeah_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Aw_Yeah_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] DVa_1_Bad_Guys_0_VL//6
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.DVa_1_Bad_Guys_0_VL;
                }
                else
                {
                    LangAndCost[0] = EN.DVa_1_Bad_Guys_0_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] GG_VL//7
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.GG_VL;
                }
                else
                {
                    LangAndCost[0] = EN.GG_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] I_play_to_win_VL//8
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.I_play_to_win_VL;
                }
                else
                {
                    LangAndCost[0] = EN.I_play_to_win_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Is_this_Easy_Mode_VL//9
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Is_this_Easy_Mode_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Is_this_Easy_Mode_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] LOL_VL//10
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.LOL_VL;
                }
                else
                {
                    LangAndCost[0] = EN.LOL_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Nice_try_VL//22
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Nice_try_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Nice_try_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] No_hacks_required_VL//11
        {
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.No_hacks_required_VL;
                }
                else
                {
                    LangAndCost[0] = EN.No_hacks_required_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Im_N_1_VL//12
        {//Summer 16
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Im_N_1_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Im_N_1_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Scoreboard_VL//13
        {//Summer 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Scoreboard_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Scoreboard_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Happy_Halloween_VL//14
        {//Halloween 16
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Happy_Halloween_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Happy_Halloween_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Im_not_scared_VL//15
        {//Halloween 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Im_not_scared_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Im_not_scared_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Aw_you_shouldnt_have_VL//16
        {//Winter 16
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Aw_you_shouldnt_have_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Aw_you_shouldnt_have_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] The_best_things_in_life_VL//17
        {//Rooster 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.The_best_things_in_life_VL;
                }
                else
                {
                    LangAndCost[0] = EN.The_best_things_in_life_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Not_taking_me_seriously_VL//18
        {//Uprising 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Not_taking_me_seriously_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Not_taking_me_seriously_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Try_and_keep_up_VL//19
        {//Uprising 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Try_and_keep_up_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Try_and_keep_up_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Level_Up_VL//20
        {//Annyver 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Level_Up_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Level_Up_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] No_Way_VL//21
        {//Annyver 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.No_Way_VL;
                }
                else
                {
                    LangAndCost[0] = EN.No_Way_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }

        public string[] Happy_Holidays_VL//22
        {//Winter 17
            get
            {
                if (myLang == "DE")
                {
                    LangAndCost[0] = DE.Aw_you_shouldnt_have_VL;
                }
                else
                {
                    LangAndCost[0] = EN.Happy_Holidays_VL;
                }
                LangAndCost[1] = Costs.LegendaryEvent.ToString();
                LangAndCost[2] = Translate.Summer + " 2018";
                return LangAndCost;
            }
        }
    }
}
