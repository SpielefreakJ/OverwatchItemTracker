﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverwatchLootBoxTracker.Translate
{
    class L_Doomfist
    {
        Languages.English.Heroes.EN_Doomfist EN;
        string myLang;

        public L_Doomfist(string Lang)
        {
            myLang = Lang;

            EN = new Languages.English.Heroes.EN_Doomfist();
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


        //Skin

        //Rare
        public string Daisy_SK
        {
            get
            {
                //else
                {
                    return EN.Daisy_SK;
                }
            }
        }

        public string Lake_SK
        {
            get
            {
                //else
                {
                    return EN.Lake_SK;
                }
            }
        }

        public string Plains_SK
        {
            get
            {
                //else
                {
                    return EN.Plains_SK;
                }
            }
        }

        public string Sunset_SK
        {
            get
            {
                //else
                {
                    return EN.Sunset_SK;
                }
            }
        }
        //Epic
        public string Leopard_SK
        {
            get
            {
                //else
                {
                    return EN.Leopard_SK;
                }
            }
        }

        public string Painted_SK
        {
            get
            {
                //else
                {
                    return EN.Painted_SK;
                }
            }
        }
        //Legendary
        public string Caution_SK
        {
            get
            {
                //else
                {
                    return EN.Caution_SK;
                }
            }
        }

        public string Irin_SK
        {
            get
            {
                //else
                {
                    return EN.Irin_SK;
                }
            }
        }

        public string Avatar_SK
        {
            get
            {
                //else
                {
                    return EN.Avatar_SK;
                }
            }
        }

        public string Spirit_SK
        {
            get
            {
                //else
                {
                    return EN.Spirit_SK;
                }
            }
        }


        //Emotes
    }
}