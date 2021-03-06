﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace OverwatchLootBoxTracker.Translate
{
    class L_Hanzo : PictureBox
    {
        Languages.English.Heroes.Hanzo EN;
        Languages.German.Heroes.Hanzo DE;
        string myLang;

        public L_Hanzo(string Lang)
        {
            if (Lang != "")
            {
                myLang = Lang;
            }

            EN = new Languages.English.Heroes.Hanzo();
            DE = new Languages.German.Heroes.Hanzo();

            SizeMode = PictureBoxSizeMode.AutoSize;
            Image = Image.FromFile("Images\\Hanzo_link.png");
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
        public string Azuki_SK//1
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Azuki_SK;
                }
                else
                {
                    return EN.Azuki_SK;
                }
            }
        }

        public string Kinoko_SK//2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Kinoko_SK;
                }
                else
                {
                    return EN.Kinoko_SK;
                }
            }
        }

        public string Midori_SK//3
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Midori_SK;
                }
                else
                {
                    return EN.Midori_SK;
                }
            }
        }

        public string Sora_SK//4
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Sora_SK;
                }
                else
                {
                    return EN.Sora_SK;
                }
            }
        }
        //Epic
        public string Cloud_SK//5
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Cloud_SK;
                }
                else
                {
                    return EN.Cloud_SK;
                }
            }
        }

        public string Dragon_SK//6
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Dragon_SK;
                }
                else
                {
                    return EN.Dragon_SK;
                }
            }
        }

        public string Demon_SK//7
        {//Halloween 2016
            get
            {
                if (myLang == "DE")
                {
                    return DE.Demon_SK;
                }
                else
                {
                    return EN.Demon_SK;
                }
            }
        }
        //Legendary
        public string Young_Hanzo_SK//8
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Young_Hanzo_SK;
                }
                else
                {
                    return EN.Young_Hanzo_SK;
                }
            }
        }

        public string Young_Master_SK//9
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Young_Master_SK;
                }
                else
                {
                    return EN.Young_Master_SK;
                }
            }
        }

        public string Lone_Wolf_SK//10
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Lone_Wolf_SK;
                }
                else
                {
                    return EN.Lone_Wolf_SK;
                }
            }
        }

        public string Okami_SK//11
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Okami_SK;
                }
                else
                {
                    return EN.Okami_SK;
                }
            }
        }

        public string Cyberninja_SK//12
        {//Annyver 2017
            get
            {
                if (myLang == "DE")
                {
                    return DE.Cyberninja_SK;
                }
                else
                {
                    return EN.Cyberninja_SK;
                }
            }
        }

        public string Casual_SK//13
        {//Winter 2017
            get
            {
                if (myLang == "DE")
                {
                    return DE.Cyberninja_SK;
                }
                else
                {
                    return EN.Casual_SK;
                }
            }
        }

        public string Kabuki_SK//14
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Kabuki_SK;
                }
                else
                {
                    return EN.Kabuki_SK;
                }
            }
        }


        //Emotes
        //Epic
        public string Beckon_EM//1
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Beckon_EM;
                }
                else
                {
                    return EN.Beckon_EM;
                }
            }
        }

        public string Brush_Shoulder_EM//2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Brush_Shoulder_EM;
                }
                else
                {
                    return EN.Brush_Shoulder_EM;
                }
            }
        }

        public string Chuckle_EM//3
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Chuckle_EM;
                }
                else
                {
                    return EN.Chuckle_EM;
                }
            }
        }

        public string Meditate_EM//4
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Meditate_EM;
                }
                else
                {
                    return EN.Meditate_EM;
                }
            }
        }

        public string Victory_EM//5
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Victory_EM;
                }
                else
                {
                    return EN.Victory_EM;
                }
            }
        }

        public string Training_EM//6
        {//Uprising 17
            get
            {
                if (myLang == "DE")
                {
                    return DE.Training_EM;
                }
                else
                {
                    return EN.Training_EM;
                }
            }
        }

        public string Fisherman_Dance_EM//7
        {//Annyver 17
            get
            {
                if (myLang == "DE")
                {
                    return DE.Fisherman_Dance_EM;
                }
                else
                {
                    return EN.Fisherman_Dance_EM;
                }
            }
        }


        //Victory Poses
        //Rare
        public string Confident_VP//1
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Confident_VP;
                }
                else
                {
                    return EN.Confident_VP;
                }
            }
        }

        public string Kneeling_VP//2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Kneeling_VP;
                }
                else
                {
                    return EN.Kneeling_VP;
                }
            }
        }

        public string Over_the_shoulder_VP//3
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Over_the_shoulder_VP;
                }
                else
                {
                    return EN.Over_the_shoulder_VP;
                }
            }
        }

        public string Medal_VP//4
        {//Summer 17
            get
            {
                if (myLang == "DE")
                {
                    return DE.Medal_VP;
                }
                else
                {
                    return EN.Medal_VP;
                }
            }
        }

        public string RIP_VP//5
        {//Halloween 16
            get
            {
                if (myLang == "DE")
                {
                    return DE.RIP_VP;
                }
                else
                {
                    return EN.RIP_VP;
                }
            }
        }

        public string Skewered_VP//6
        {//Halloween 17
            get
            {
                if (myLang == "DE")
                {
                    return DE.Skewered_VP;
                }
                else
                {
                    return EN.Skewered_VP;
                }
            }
        }
    }
}
