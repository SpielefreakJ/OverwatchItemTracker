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
        string myPath=null;
        CCost Cost;

        //Langs
        Lang.L_DE DE;
        Lang.L_EN EN;

        public L_Translate(string Lang)
        {
            if (Lang != "")
            {
                myLang = Lang;
            }

            Cost = new CCost();

            //Langs
            DE = new Lang.L_DE();
            EN = new Lang.L_EN();
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

        public string Path
        {
            get
            {
                return myPath;
            }
            set
            {
                myPath = value;
            }
        }


        //Welcome Screen

        public string Welcome
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Welcome;
                }
                else
                {
                    return EN.Welcome;
                }
            }
        }

        public string ChangesText
        {
            get
            {/*
                if (myLang == "DE")
                {
                    return DE.ChangesTitle + EN.ChangesText;
                }
                else*/
                {
                    return EN.ChangesTitle + EN.ChangesText;
                }
            }
        }

        public string CopyrightVersion
        {
            get
            {
                //if (myLang == "DE")
                //{
                //    return DE.ChangesTitle + EN.ChangesText;
                //}
                //else
                {
                    return "© 2017-2018 SpielefreakJ | OWItemTracker Version: 0.2.7.0 Beta | Overwatch Version: 1.21.0 | This Program is not affiliated with Blizzard Entertainment.\n© 2016-2018 Blizzard Entertainment, Inc. All rights reserved. | All trademarks referenced herein are the properties of their respective owners.";
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


        public string Back
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Back;
                }
                else
                {
                    return EN.Back;
                }
            }
        }

        public string DeleteSaves
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.DeleteSaves;
                }
                else
                {
                    return EN.DeleteSaves;
                }
            }
        }

        public string DeleteSavesS
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.DeleteSavesS;
                }
                else
                {
                    return EN.DeleteSavesS;
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

        public string Common
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Common;
                }
                else
                {
                    return EN.Common;
                }
            }
        }

        public string Rare
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Rare;
                }
                else
                {
                    return EN.Rare;
                }
            }
        }

        public string Epic
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Epic;
                }
                else
                {
                    return EN.Epic;
                }
            }
        }

        public string Legendary
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Legendary;
                }
                else
                {
                    return EN.Legendary;
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

        public string Dog
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Dog;
                }
                else
                {
                    return EN.Dog;
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
        // Overwatch League
        public string OWLeague
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWLeague;
                }
                else
                {
                    return EN.OWLeague;
                }
            }
        }
        #region OWLeague
        public string OWL_Boston_Uprising
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Boston_Uprising;
                }
                else
                {
                    return EN.OWL_Boston_Uprising;
                }
            }
        }

        public string OWL_Dallas_Fuel
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Dallas_Fuel;
                }
                else
                {
                    return EN.OWL_Dallas_Fuel;
                }
            }
        }

        public string OWL_Florida_Mayhem
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Florida_Mayhem;
                }
                else
                {
                    return EN.OWL_Florida_Mayhem;
                }
            }
        }

        public string OWL_Houston_Outlaws
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Houston_Outlaws;
                }
                else
                {
                    return EN.OWL_Houston_Outlaws;
                }
            }
        }

        public string OWL_London_Spitfire
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_London_Spitfire;
                }
                else
                {
                    return EN.OWL_London_Spitfire;
                }
            }
        }

        public string OWL_Los_Angeles_Gladiators
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Los_Angeles_Gladiators;
                }
                else
                {
                    return EN.OWL_Los_Angeles_Gladiators;
                }
            }
        }

        public string OWL_Los_Angeles_Valiant
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Los_Angeles_Valiant;
                }
                else
                {
                    return EN.OWL_Los_Angeles_Valiant;
                }
            }
        }

        public string OWL_New_York_Excelsior
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_New_York_Excelsior;
                }
                else
                {
                    return EN.OWL_New_York_Excelsior;
                }
            }
        }

        public string OWL_Philadelphia_Fusion
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Philadelphia_Fusion;
                }
                else
                {
                    return EN.OWL_Philadelphia_Fusion;
                }
            }
        }

        public string OWL_San_Francisco_Shock
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_San_Francisco_Shock;
                }
                else
                {
                    return EN.OWL_San_Francisco_Shock;
                }
            }
        }

        public string OWL_Seoul_Dynasty
{
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Seoul_Dynasty;
                }
                else
                {
                    return EN.OWL_Seoul_Dynasty;
                }
            }
        }

        public string OWL_Shanghai_Dragons
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.OWL_Shanghai_Dragons;
                }
                else
                {
                    return EN.OWL_Shanghai_Dragons;
                }
            }
        }

        #endregion


        //Not Obtainable Skins

        public string Unknown
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Unknown;
                }
                else
                {
                    return EN.Unknown;
                }
            }
        }

        public string OriginGotY
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.OriginGotY;
                }
                else
                {
                    return EN.OriginGotY;
                }
            }
        }
        public string OriginGotY2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.OriginGotY2;
                }
                else
                {
                    return EN.OriginGotY2;
                }
            }
        }

        public string BlizzCon
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.BlizzCon;
                }
                else
                {
                    return EN.BlizzCon;
                }
            }
        }

        public string BlizzCon2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.BlizzCon2;
                }
                else
                {
                    return EN.BlizzCon2;
                }
            }
            set
            {
                EN.BlizzCon2 = value;
                DE.BlizzCon2 = value;
            }
        }

        public string Prepurchase
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Prepurchase;
                }
                else
                {
                    return EN.Prepurchase;
                }
            }
        }
        public string Prepurchase2
        {
            get
            {
                if (myLang == "DE")
                {
                    return DE.Prepurchase2;
                }
                else
                {
                    return EN.Prepurchase2;
                }
            }
        }


        //Remaining Text
        string myRemainingHeroe = "All";
        public string Remaining
        {
            get
            {
                Cost.Calculate(myPath, myRemainingHeroe);
                if (myLang == "DE")
                {
                    return DE.remaining1 + " " + (Cost.RemCostsNonEvent + Cost.RemCostsEvent) + " " + DE.remaining2 + " " + Cost.RemCostsWeapon + " SR";
                }
                else
                {
                    return EN.remaining1 + " " + (Cost.RemCostsNonEvent + Cost.RemCostsEvent) + " " + EN.remaining2 + " " + Cost.RemCostsWeapon + " SR";
                }
            }
            set
            {

            }
        }

        public string RemainingHeroe
        {
            get
            {
                return myRemainingHeroe;
            }
            set
            {
                myRemainingHeroe = value;
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
                    return (Cost.RemCostsNonEvent + Cost.RemCostsEvent) + " " + DE.Credits + "\n\n" + Cost.RemCostsNonEvent + " " + DE.Credits + "\n\n" + Cost.RemCostsEvent + " " + DE.Credits + "\n\n" + Cost.RemCostsWeapon + " SR";
                }
                else
                {
                    return (Cost.RemCostsNonEvent + Cost.RemCostsEvent) + " " + EN.Credits + "\n\n" + Cost.RemCostsNonEvent + " " + EN.Credits + "\n\n" + Cost.RemCostsEvent + " " + EN.Credits + "\n\n" + Cost.RemCostsWeapon + " SR";
                }
            }
        }


#region Default Items
        public string Classic
        {//Skin
            get
            {
                if (myLang=="DE")
                {
                    return DE.Classic;
                }
                else
                {
                    return EN.Classic;
                }
            }
        }

        public string Heroic
        {//Emote, Victory Pose, Highlight Intro
            get
            {
                if (myLang == "DE")
                {
                    return DE.Heroic;
                }
                else
                {
                    return EN.Heroic;
                }
            }
        }

        public string Default
        {//Weapon
            get
            {
                if (myLang == "DE")
                {
                    return DE.Default;
                }
                else
                {
                    return EN.Default;
                }
            }
        }

        public string GoldWeapon
        {//GoldWeapon
            get
            {
                if (myLang == "DE")
                {
                    return DE.GoldWeapon;
                }
                else
                {
                    return EN.GoldWeapon;
                }
            }
        }
#endregion
    }
}
