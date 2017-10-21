﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchLootBoxTracker.Translate
{
    class L_Translate
    {
        string myLang;
        string Changes;
        CCost Cost;
        CGoldweapon GoldWeapon;

        //Langs
        Lang.L_DE DE;
        Lang.L_EN EN;

        public L_Translate(string Lang)
        {
            myLang = Lang;
            Cost = new CCost();
            GoldWeapon = new CGoldweapon();

            //Langs
            DE = new Lang.L_DE();
            EN = new Lang.L_EN();

            ChangesT();
        }

        private void ChangesT()
        {
            Changes = "\n\nNew Changes!";
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


        //Welcome Screen

        public string A
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.A;
                }
                else
                {
                    return EN.A;
                }
            }
        }

        public string ChangesText
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.A + Changes;
                }
                else
                {
                    return EN.A + Changes;
                }
            }
        }



        //All Settings


        public string Settings
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Settings;
                }
                else
                {
                    return EN.Settings;
                }
            }
        }

        public string LangChange
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.LangSettings;
                }
                else
                {
                    return EN.LangSettings;
                }
            }
        }


        public string MoreCost
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.MoreCost;
                }
                else
                {
                    return EN.MoreCost;
                }
            }
        }



        //On Close


        public string Close
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Close;
                }
                else
                {
                    return EN.Close;
                }
            }
        }


        public string AppClose
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.AppClose;
                }
                else
                {
                    return EN.AppClose;
                }
            }
        }


        //Overlay Text

        public string Skins
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Skin;
                }
                else
                {
                    return EN.Skin;
                }
            }
        }

        public string Emotes
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Emotes;
                }
                else
                {
                    return EN.Emotes;
                }
            }
        }

        public string VictoryPoses
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.VictoryPoses;
                }
                else
                {
                    return EN.VictoryPoses;
                }
            }
        }

        public string VoiceLines
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.VoiceLines;
                }
                else
                {
                    return EN.VoiceLines;
                }
            }
        }

        public string Sprays
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Sprays;
                }
                else
                {
                    return EN.Sprays;
                }
            }
        }

        public string HighlightIntros
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.HighlightIntros;
                }
                else
                {
                    return EN.HighlightIntros;
                }
            }
        }

        public string Weapons
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Weapons;
                }
                else
                {
                    return EN.Weapons;
                }
            }
        }

        public string PlayerIcons
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.PlayerIcons;
                }
                else
                {
                    return EN.PlayerIcons;
                }
            }
        }
        //Events
        public string Summer
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Summer;
                }
                else
                {
                    return EN.Summer;
                }
            }
        }

        public string Halloween
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Halloween;
                }
                else
                {
                    return EN.Halloween;
                }
            }
        }

        public string Winter
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Winter;
                }
                else
                {
                    return EN.Winter;
                }
            }
        }

        public string Rooster
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Rooster;
                }
                else
                {
                    return EN.Rooster;
                }
            }
        }

        public string Uprising
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Uprising;
                }
                else
                {
                    return EN.Uprising;
                }
            }
        }

        public string Annyver
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Annyver;
                }
                else
                {
                    return EN.Annyver;
                }
            }
        }



        //Remaining Text

        public string Remaining
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.remaining1 + " " + (Cost.KostenNormal + Cost.KostenFest) + " " + DE.remaining2 + " " + GoldWeapon.KostenGes + " SR";
                }
                else
                {
                    return EN.remaining1 + " " + (Cost.KostenNormal + Cost.KostenFest) + " " + EN.remaining2 + " " + GoldWeapon.KostenGes + " SR";
                }
            }
        }
        //For "More Infos about remaining Costs"
        public string RemMoreInfo1
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.remAll + "\n\n" + DE.remNonEvent + "\n\n" + DE.remEvent + "\n\n" + DE.remWeapons;
                }
                else
                {
                    return EN.remAll + "\n\n" + EN.remNonEvent + "\n\n" + EN.remEvent + "\n\n" + EN.remWeapons;
                }
            }
        }

        public string RemMoreInfo2
        {
            get
            {
                if (myLang == "DE")
                {
                    return (Cost.KostenNormal + Cost.KostenFest) + " " + DE.Credits + "\n\n" + Cost.KostenNormal + " " + DE.Credits + "\n\n" + Cost.KostenFest + " " + DE.Credits + "\n\n" + GoldWeapon.KostenGes + " SR";
                }
                else
                {
                    return (Cost.KostenNormal + Cost.KostenFest) + " " + EN.Credits + "\n\n" + Cost.KostenNormal + " " + EN.Credits + "\n\n" + Cost.KostenFest + " " + EN.Credits + "\n\n" + GoldWeapon.KostenGes + " SR";
                }
            }
        }
    }
}