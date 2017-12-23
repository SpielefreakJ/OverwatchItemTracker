﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Code by Justin SpielefreakJ
 * (c) 2017
 */

namespace OverwatchLootBoxTracker
{
    public partial class Form1 : Form
    {

        #region Variablen

        IniStream inisSettings = null;
        IniStream inisHeroes = null;
        IniStream inisPI = null;
        CIniCreator inic;
        CCost Cost;
        //Languages
        Translate.L_Translate Lang;
        Translate.L_Ana Ana;
        Translate.L_Bastion Bastion;
        Translate.L_DVa DVa;
        Translate.L_Doomfist Doomfist;
        Translate.L_Genji Genji;
        Translate.L_Hanzo Hanzo;
        Translate.L_Junkrat Junkrat;
        Translate.L_Lúcio Lúcio;
        Translate.L_McCree McCree;
        Translate.L_Mei Mei;
        Translate.L_Mercy Mercy;
        Translate.L_Moira Moira;
        Translate.L_Orisa Orisa;
        Translate.L_Pharah Pharah;
        Translate.L_Reaper Reaper;
        Translate.L_Reinhardt Reinhardt;
        Translate.L_Roadhog Roadhog;
        Translate.L_Soldier_76 Soldier_76;
        Translate.L_Sombra Sombra;
        Translate.L_Symmetra Symmetra;
        Translate.L_Torbjörn Torbjörn;
        Translate.L_Tracer Tracer;
        Translate.L_Widowmaker Widowmaker;
        Translate.L_Winston Winston;
        Translate.L_Zarya Zarya;
        Translate.L_Zenyatta Zenyatta;
        //Images
        CHeroImage ItemImage;
        //
        //Others
        string Language = "EN";
        int newSave = 0;
        int gBAllWeited3, gBAllWeited3p1, gBAllWeited3p2;
        int gBAllWeited4, gBAllWeited4p1, gBAllWeited4p2, gBAllWeited4p3;
        //int gBAllWeited5, gBAllWeited5p1, gBAllWeited5p2, gBAllWeited5p3, gBAllWeited5p4;
        int p1 = 194; int p2 = 217; int p3 = 240; int p4 = 263; int p5 = 286; int p6 = 309; int p7 = 332; int p8 = 355; int p9 = 378; int p10 = 401;

        string BackSave, BackSave2;

        String appdata = System.Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        #endregion

        public Form1()
        {
            Lang = new Translate.L_Translate(Language);

            //Erstellen des Verzeichnisses "OWItemTracker" in C:\\User\[Username]\AppData\Local
            appdata += "\\OWItemTracker";
            Directory.CreateDirectory(appdata);
            inic = new CIniCreator(appdata);
            Lang.Path = appdata;

            //Auslesen der "Settings.ini" Datei und speichern in IniStream inisSettings
            inisSettings = new IniStream(appdata + "\\Settings.ini");

            //Absicherung, damit alle die die alten saves benutzt haben auch neue anlegen und alle, die das programm zum ersten mal starten diese nachricht nicht bekommen.
            try
            {
                if ("" == inisSettings.Read("NewStart") && "" == inisSettings.Read("Lang"))
                {
                    inisSettings.Write("NewStart", "1");
                    inisSettings.Write("NewSave", "true");
                }
                if (true == Convert.ToBoolean(inisSettings.Read("NewSave")) && "1" == inisSettings.Read("NewStart"))
                { }
                else
                {
                    bool i = false;
                    i = Convert.ToBoolean(inisSettings.Read("t"));
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show(Lang.DeleteSaves, "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    this.Close();
                }
                if (result == DialogResult.OK)
                {
                    Directory.Delete(appdata, true);
                    Directory.CreateDirectory(appdata);
                    newSave = 1;
                    MessageBox.Show(Lang.DeleteSavesS, "Deleting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Handle the ApplicationExit event to know when the application is exiting.
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);

            IniRead();
            InitializeComponent();
            KlassenInst();
            ChangePos();
            Texte();
            Tooltips();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //MessageBox.Show(Lang.AppClose);
            IniSave();
        }

        private void IniSave()
        {
            Directory.CreateDirectory(appdata);
            //Speichern der änderrung unter "Lang" in der Settings.ini
            if (Language == "")
            {
                Language = "EN";
            }
            inisSettings.Write("Lang", Language);
            if (newSave == 1)
            {
                inisSettings.Write("NewSave", "true");
            }
        }

        private void IniRead()
        {
            //Farbe auslesen und auf dem Hintergrund anwenden
            Language = inisSettings.Read("Lang");
            DisabledLangs();
            Lang.ChangeLang = Language;
        }
        private void DisabledLangs()
        {
            if (Language == "DE")
            {
                Language = "EN";
            }
        }

        private void KlassenInst()
        {
            ItemImage = new CHeroImage();
            Cost = new CCost();
            Ana = new Translate.L_Ana(Language);
            Bastion = new Translate.L_Bastion(Language);
            DVa = new Translate.L_DVa(Language);
            Doomfist = new Translate.L_Doomfist(Language);
            Genji = new Translate.L_Genji(Language);
            Hanzo = new Translate.L_Hanzo(Language);
            Junkrat = new Translate.L_Junkrat(Language);
            Lúcio = new Translate.L_Lúcio(Language);
            McCree = new Translate.L_McCree(Language);
            Mei = new Translate.L_Mei(Language);
            Mercy = new Translate.L_Mercy(Language);
            Moira = new Translate.L_Moira(Language);
            Orisa = new Translate.L_Orisa(Language);
            Pharah = new Translate.L_Pharah(Language);
            Reaper = new Translate.L_Reaper(Language);
            Reinhardt = new Translate.L_Reinhardt(Language);
            Roadhog = new Translate.L_Roadhog(Language);
            Soldier_76 = new Translate.L_Soldier_76(Language);
            Sombra = new Translate.L_Sombra(Language);
            Symmetra = new Translate.L_Symmetra(Language);
            Torbjörn = new Translate.L_Torbjörn(Language);
            Tracer = new Translate.L_Tracer(Language);
            Widowmaker = new Translate.L_Widowmaker(Language);
            Winston = new Translate.L_Winston(Language);
            Zarya = new Translate.L_Zarya(Language);
            Zenyatta = new Translate.L_Zenyatta(Language);
        }

        private void Texte()
        {
            //Erste mal ausrechnen, wieviel alles zusammen Kostet
            lblChanges.Text = Lang.ChangesText;

            gbAll.Visible = false;
            gBLang.Visible = false;
            gBWelcome.Text = Lang.Welcome;
            btnWelcomeClose.Text = Lang.Close + " (3)"; tmrWelcome.Enabled = true;
            lblCopyrightVersion.Text = Lang.CopyrightVersion;
            lblContributor.Text = "Contributor:\nProgramm: SpielefreakJ\n\nLanguages:\nEnglish: SpielefreakJ\nGerman: SpielefreakJ\n\nInstaller: @SnowBlinderP";
            //Settings
            btnSettings.Text = Lang.Settings;
            gBLang.Text = Lang.LangChange;
            //Itembuttons
            btnSkins.Text = Lang.Skins;
            btnEmotes.Text = Lang.Emotes;
            btnVictoryPoses.Text = Lang.VictoryPoses;
            btnVoiceLines.Text = Lang.VoiceLines;
            btnSprays.Text = Lang.Sprays;
            btnHighlightIntros.Text = Lang.HighlightIntros;
            btnWeapons.Text = Lang.Weapons;
            btnPlayerIcons.Text = Lang.PlayerIcons;
            //Eventbuttons
            btnSummer.Text = Lang.Summer;
            btnHalloween.Text = Lang.Halloween;
            btnWinter.Text = Lang.Winter;
            btnRooster.Text = Lang.Rooster;
            btnUprising.Text = Lang.Uprising;
            btnAnnyver.Text = Lang.Annyver;
            //Heroebuttons
            btnBackHero.Text = Lang.Back;
            //More info about remaining costs
            TextRemaining("All");
        }

        private void TextRemaining(string Heroe)
        {
            Lang.RemainingHeroe = Heroe;
            lblKosten.Text = Lang.Remaining;

            //More info about remaining costs
            btnMoreCost.Text = Lang.MoreCost;
            gBMoreCost.Text = "";
            lblMoreInfoCost.Text = Lang.RemMoreInfo1;
            lblMoreInfoCost2.Text = Lang.RemMoreInfo2;
        }

        private void ChangePos()
        {
            this.Width = 912; this.Height = 751;

            gBAllWeited3 = gbAll.Width;
            gBAllWeited3 /= 3;
            gBAllWeited3p1 = gBAllWeited3 - 57;
            gBAllWeited3p2 = gBAllWeited3 * 2 - 57;

            gBAllWeited4 = gbAll.Width;
            gBAllWeited4 /= 4;
            gBAllWeited4p1 = gBAllWeited4 - 57;
            gBAllWeited4p2 = gBAllWeited4 * 2 - 57;
            gBAllWeited4p3 = gBAllWeited4 * 3 - 57;


            gBWelcome.Location = new Point(12, 12);
            gBWelcome.Width = 872; gBWelcome.Height = 688;

            gBLang.Location = new Point(684, 600);
            gBLang.Width = 200; gBLang.Height = 100;

            gbAll.Location = new Point(16, 29);
            gbAll.Width = 868; gbAll.Height = 642;

            gBMoreCost.Location = new Point(16, 29);
            gBMoreCost.Width = 868; gBMoreCost.Height = 671;

            btnBackHero.Location = new Point(16, 677);

            HeroButton();

            //Farben der Checkboxen entfernen
            chB01.BackColor = Color.Transparent;
            chB02.BackColor = Color.Transparent;
            chB03.BackColor = Color.Transparent;
            chB04.BackColor = Color.Transparent;
        }

        private void HeroButton()
        {

            int Breite = this.Width / 10;
            int Breite5 = this.Width / 2 - 60 - 28;
            int Breite1 = Breite5 - 240, Breite2 = Breite5 - 180, Breite3 = Breite5 - 120, Breite4 = Breite5 - 60;
            int Breite6 = Breite5 + 60, Breite7 = Breite5 + 120, Breite8 = Breite5 + 180, Breite9 = Breite5 + 240, Breite10 = Breite5 + 300;
            int Zeile2 = this.Height / 2 - 50;
            int Zeile1 = Zeile2 - 100, Zeile3 = Zeile2 + 100;

            #region HeroesImageCreate
            //Ana
            Controls.Add(Ana);
            Ana.Location = new Point(Breite1, Zeile1);
            Ana.Click += Ana_Click;

            //Bastion
            Controls.Add(Bastion);
            Bastion.Location = new Point(Breite2, Zeile1);
            Bastion.Click += Bastion_Click;

            //D.Va
            Controls.Add(DVa);
            DVa.Location = new Point(Breite3, Zeile1);
            DVa.Click += DVa_Click;

            //Doomfist
            Controls.Add(Doomfist);
            Doomfist.Location = new Point(Breite4, Zeile1);
            Doomfist.Click += Doomfist_Click;

            //Genji
            Controls.Add(Genji);
            Genji.Location = new Point(Breite5, Zeile1);
            Genji.Click += Genji_Click;

            //Hanzo
            Controls.Add(Hanzo);
            Hanzo.Location = new Point(Breite6, Zeile1);
            Hanzo.Click += Hanzo_Click;

            //Junkrat
            Controls.Add(Junkrat);
            Junkrat.Location = new Point(Breite7, Zeile1);
            Junkrat.Click += Junkrat_Click;

            //Lúcio
            Controls.Add(Lúcio);
            Lúcio.Location = new Point(Breite8, Zeile1);
            Lúcio.Click += Lúcio_Click;

            //McCree
            Controls.Add(McCree);
            McCree.Location = new Point(Breite9, Zeile1);
            McCree.Click += McCree_Click;

            //Mei
            Controls.Add(Mei);
            Mei.Location = new Point(Breite10, Zeile1);
            Mei.Click += Mei_Click;

            ////////---------------

            //Mercy
            Controls.Add(Mercy);
            Mercy.Location = new Point(Breite1, Zeile2);
            Mercy.Click += Mercy_Click;

            //Moira
            Controls.Add(Moira);
            Moira.Location = new Point(Breite2, Zeile2);
            Moira.Click += Moira_Click;

            //Orisa
            Controls.Add(Orisa);
            Orisa.Location = new Point(Breite3, Zeile2);
            Orisa.Click += Orisa_Click;

            //Pharah
            Controls.Add(Pharah);
            Pharah.Location = new Point(Breite4, Zeile2);
            Pharah.Click += Pharah_Click;

            //Reaper
            Controls.Add(Reaper);
            Reaper.Location = new Point(Breite5, Zeile2);
            Reaper.Click += Reaper_Click;

            //Reinhardt
            Controls.Add(Reinhardt);
            Reinhardt.Location = new Point(Breite6, Zeile2);
            Reinhardt.Click += Reinhardt_Click;

            //Roadhog
            Controls.Add(Roadhog);
            Roadhog.Location = new Point(Breite7, Zeile2);
            Roadhog.Click += Roadhog_Click;

            //Soldier_76
            Controls.Add(Soldier_76);
            Soldier_76.Location = new Point(Breite8, Zeile2);
            Soldier_76.Click += Soldier_76_Click;

            //Sombra
            Controls.Add(Sombra);
            Sombra.Location = new Point(Breite9, Zeile2);
            Sombra.Click += Sombra_Click;

            //Symmetra
            Controls.Add(Symmetra);
            Symmetra.Location = new Point(Breite10, Zeile2);
            Symmetra.Click += Symmetra_Click;

            ////////---------------

            //Torbjörn
            Controls.Add(Torbjörn);
            Torbjörn.Location = new Point(Breite3, Zeile3);
            Torbjörn.Click += Torbjörn_Click;

            //Tracer
            Controls.Add(Tracer);
            Tracer.Location = new Point(Breite4, Zeile3);
            Tracer.Click += Tracer_Click;

            //Widowmaker
            Controls.Add(Widowmaker);
            Widowmaker.Location = new Point(Breite5, Zeile3);
            Widowmaker.Click += Widowmaker_Click;

            //Winston
            Controls.Add(Winston);
            Winston.Location = new Point(Breite6, Zeile3);
            Winston.Click += Winston_Click;

            //Zarya
            Controls.Add(Zarya);
            Zarya.Location = new Point(Breite7, Zeile3);
            Zarya.Click += Zarya_Click;

            //Zenyatta
            Controls.Add(Zenyatta);
            Zenyatta.Location = new Point(Breite8, Zeile3);
            Zenyatta.Click += Zenyatta_Click;
            #endregion
            ////////---------------

            //CHeroImage MenuImage = new CHeroImage(Language);
            //Controls.Add(MenuImage);
            //MenuImage.SetImage = Image.FromFile("Images\\MenuBackground\\Winter 16.png");

            Controls.Add(ItemImage);
            ItemImage.Location = new Point((this.Width / 2) - (ItemImage.Width / 2), (this.Height / 2) - (ItemImage.Height / 2) - 19);
            ItemImage.Visible = false;
            ItemImage.Click += ItemImage_Click;
        }

        private void ItemImage_Click(object sender, EventArgs e)
        {
            ItemImage.Visible = false;
            lblCloseImage.Visible = false;
            ImageChangeHintergrundButtons(true);
        }

        private void ChangeLang()
        {
            Lang.ChangeLang = Language;
            Ana.ChangeLang = Language;
            Bastion.ChangeLang = Language;
            DVa.ChangeLang = Language;
            Doomfist.ChangeLang = Language;
            Genji.ChangeLang = Language;
            Hanzo.ChangeLang = Language;
            Junkrat.ChangeLang = Language;
            Lúcio.ChangeLang = Language;
            McCree.ChangeLang = Language;
            Mei.ChangeLang = Language;
            Mercy.ChangeLang = Language;
            Moira.ChangeLang = Language;
            Orisa.ChangeLang = Language;
            Pharah.ChangeLang = Language;
            Reaper.ChangeLang = Language;
            Reinhardt.ChangeLang = Language;
            Roadhog.ChangeLang = Language;
            Soldier_76.ChangeLang = Language;
            Sombra.ChangeLang = Language;
            Symmetra.ChangeLang = Language;
            Torbjörn.ChangeLang = Language;
            Tracer.ChangeLang = Language;
            Widowmaker.ChangeLang = Language;
            Winston.ChangeLang = Language;
            Zarya.ChangeLang = Language;
            Zenyatta.ChangeLang = Language;

            Texte();
        }

        private void Tooltips()
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip tt = new ToolTip();

            // Set up the delays for the ToolTip.
            tt.AutoPopDelay = 10000;
            tt.InitialDelay = 100;
            tt.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            tt.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            tt.SetToolTip(this.btnLangGerman, "Currently disabled!");

            #region HeroesToolTips
            tt.SetToolTip(this.Ana, Ana.GetName());
            tt.SetToolTip(this.Bastion, Bastion.GetName());
            tt.SetToolTip(this.DVa, DVa.GetName());
            tt.SetToolTip(this.Doomfist, Doomfist.GetName());
            tt.SetToolTip(this.Genji, Genji.GetName());
            tt.SetToolTip(this.Hanzo, Hanzo.GetName());
            tt.SetToolTip(this.Junkrat, Junkrat.GetName());
            tt.SetToolTip(this.Lúcio, Lúcio.GetName());
            tt.SetToolTip(this.McCree, McCree.GetName());
            tt.SetToolTip(this.Mei, Mei.GetName());
            //
            tt.SetToolTip(this.Mercy, Mercy.GetName());
            tt.SetToolTip(this.Moira, Moira.GetName());
            tt.SetToolTip(this.Orisa, Orisa.GetName());
            tt.SetToolTip(this.Pharah, Pharah.GetName());
            tt.SetToolTip(this.Reaper, Reaper.GetName());
            tt.SetToolTip(this.Reinhardt, Reinhardt.GetName());
            tt.SetToolTip(this.Roadhog, Roadhog.GetName());
            tt.SetToolTip(this.Soldier_76, Soldier_76.GetName());
            tt.SetToolTip(this.Sombra, Sombra.GetName());
            tt.SetToolTip(this.Symmetra, Symmetra.GetName());
            //
            tt.SetToolTip(this.Torbjörn, Torbjörn.GetName());
            tt.SetToolTip(this.Tracer, Tracer.GetName());
            tt.SetToolTip(this.Widowmaker, Widowmaker.GetName());
            tt.SetToolTip(this.Winston, Winston.GetName());
            tt.SetToolTip(this.Zarya, Zarya.GetName());
            tt.SetToolTip(this.Zenyatta, Zenyatta.GetName());
            #endregion
        }

        /*
        // Ab hier beginnt der richtige Code
        */

        private void btnLangGerman_Click(object sender, EventArgs e)
        {/*
            Language = "DE";
            ChangeLang();
            IniSave();*/
        }

        private void btnLangEnglish_Click(object sender, EventArgs e)
        {
            Language = "EN";
            ChangeLang();
            IniSave();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            gBLang.Visible = !gBLang.Visible;
            gBLang.BringToFront();
        }

        private void btnSkins_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.Skins;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.Skins;
        }

        private void btnEmotes_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.Emotes;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.Emotes;
        }

        private void btnVictoryPoses_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.VictoryPoses;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.VictoryPoses;
        }

        private void btnVoiceLines_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.VoiceLines;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.VoiceLines;
        }

        private void btnSprays_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.Sprays;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.Sprays;
        }

        private void btnHighlightIntros_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.HighlightIntros;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.HighlightIntros;
        }

        private void btnWeapons_Click(object sender, EventArgs e)
        {
            BackSave2 = Lang.Weapons;
            BtnSichtbar();

            gbAll.Text += " / " + Lang.Weapons;
        }

        private void BtnSichtbar()
        {
            btnSkins.Visible = false;
            btnEmotes.Visible = false;
            btnVictoryPoses.Visible = false;

            #region unwichtig
            //
            if (Heroe == "Ana")
            {
                btnAna();
            }
            if (Heroe == "Bastion")
            {
                btnBastion();
            }
            if (Heroe == "DVa")
            {
                btnDVa();
            }
            if (Heroe == "Doomfist")
            {
                btnDoomfist();
            }
            if (Heroe == "Genji")
            {
                btnGenji();
            }
            if (Heroe == "Hanzo")
            {
                btnHanzo();
            }
            if (Heroe == "Junkrat")
            {
                btnJunkrat();
            }
            if (Heroe == "Lúcio")
            {
                btnLúcio();
            }
            if (Heroe == "McCree")
            {
                btnMcCree();
            }
            if (Heroe == "Mei")
            {
                btnMei();
            }
            //
            if (Heroe == "Mercy")
            {
                btnMercy();
            }
            if (Heroe == "Moira")
            {
                btnMoira();
            }
            if (Heroe == "Orisa")
            {
                btnOrisa();
            }
            if (Heroe == "Pharah")
            {
                btnPharah();
            }
            if (Heroe == "Reaper")
            {
                btnReaper();
            }
            if (Heroe == "Reinhardt")
            {
                btnReinhardt();
            }
            if (Heroe == "Roadhog")
            {
                btnRoadhog();
            }
            if (Heroe == "Soldier 76")
            {
                btnSoldier_76();
            }
            if (Heroe == "Sombra")
            {
                btnSombra();
            }
            if (Heroe == "Symmetra")
            {
                btnSymmetra();
            }
            //
            if (Heroe == "Torbjörn")
            {
                btnTorbjörn();
            }
            if (Heroe == "Tracer")
            {
                btnTracer();
            }
            if (Heroe == "Widowmaker")
            {
                btnWidowmaker();
            }
            if (Heroe == "Winston")
            {
                btnWinston();
            }
            if (Heroe == "Zarya")
            {
                btnZarya();
            }
            if (Heroe == "Zenyatta")
            {
                btnZenyatta();
            }
            #endregion
        }

        private void btnPlayerIcons_Click(object sender, EventArgs e)
        {/*
            gbAll.Visible = true;
            gbAll.BringToFront();
            btnBackHeroe.Visible = true;
            btnBackHeroe.BringToFront();

            gBLang.Visible = false;
            btnMoreCost.Visible = false;

            gbAll.Text = Lang.PlayerIcons;
        */
        }

        private void btnMoreCost_Click(object sender, EventArgs e)
        {
            if (btnMoreCost.Text == Lang.Close)
            {
                gBMoreCost.Visible = false;
                btnMoreCost.Text = Lang.MoreCost;
                btnBackHero.Visible = false;
            }
            else
            {
                gbAll.Visible = false;
                gBMoreCost.Visible = true;
                gBMoreCost.BringToFront();
                btnMoreCost.Text = Lang.Close;
                gBLang.Visible = false;
            }
        }

        int i_timer = 3;
        private void tmrWelcome_Tick(object sender, EventArgs e)
        {
            if (i_timer == 1)
            {
                i_timer--;
                btnWelcomeClose.Text = Lang.Close;
                btnWelcomeClose.Enabled = true;
                tmrWelcome.Enabled = false;
            }
            if (i_timer == 2)
            {
                i_timer--;
                btnWelcomeClose.Text = Lang.Close + " (" + i_timer + ")";
            }
            if (i_timer >= 3)
            {
                i_timer--;
                btnWelcomeClose.Text = Lang.Close + " (" + i_timer + ")";
            }
        }

        private void btnWelcomeClose_Click(object sender, EventArgs e)
        {
            gBWelcome.Visible = false;
            btnMoreCost.Visible = true;//Da der Button sonst sichtbar und klickbar ist :/
        }

        //Für hier benötigte Variablen
        int chBSave; string Heroe = "PI"; ToolTip HeroTT;

        private void btnBackHeroe_Click(object sender, EventArgs e)
        {
            if (gbAll.Text == BackSave)
            {
                Ana.Visible = true;
                Bastion.Visible = true;
                DVa.Visible = true;
                Doomfist.Visible = true;
                Genji.Visible = true;
                Hanzo.Visible = true;
                Junkrat.Visible = true;
                Lúcio.Visible = true;
                McCree.Visible = true;
                Mei.Visible = true;
                Mercy.Visible = true;
                Moira.Visible = true;
                Orisa.Visible = true;
                Pharah.Visible = true;
                Reaper.Visible = true;
                Reinhardt.Visible = true;
                Roadhog.Visible = true;
                Soldier_76.Visible = true;
                Sombra.Visible = true;
                Symmetra.Visible = true;
                Torbjörn.Visible = true;
                Tracer.Visible = true;
                Widowmaker.Visible = true;
                Winston.Visible = true;
                Zarya.Visible = true;
                Zenyatta.Visible = true;

                gbAll.Visible = false;
                btnBackHero.Visible = false;
                btnMoreCost.Visible = true;
            }
            else if (gbAll.Text == BackSave + " / " + BackSave2)
            {
                btnSkins.Visible = true;
                btnEmotes.Visible = true;
                btnVictoryPoses.Visible = true;

                gbAll.Text = BackSave;

                //Rest Ausblenden
                //Erst sagen, dass die Checkboxen nicht speichern sollen
                chBSave = 0;
                //Resetten aller Checkboxen und Ausblenden
                chB00.Visible = false; chB00.BackColor = Color.Transparent;
                chB01.Checked = false; /*chB01.Visible = false;*/ chB01.BackColor = Color.Transparent;
                chB02.Checked = false; chB02.Visible = false; chB02.BackColor = Color.Transparent;
                chB03.Checked = false; chB03.Visible = false; chB03.BackColor = Color.Transparent;
                chB04.Checked = false; chB04.Visible = false; chB04.BackColor = Color.Transparent;
                chB05.Checked = false; chB05.Visible = false; chB05.BackColor = Color.Transparent;
                chB06.Checked = false; chB06.Visible = false; chB06.BackColor = Color.Transparent;
                chB07.Checked = false; chB07.Visible = false; chB07.BackColor = Color.Transparent;
                chB08.Checked = false; chB08.Visible = false; chB08.BackColor = Color.Transparent;
                chB09.Checked = false; chB09.Visible = false; chB09.BackColor = Color.Transparent;
                chB10.Checked = false; chB10.Visible = false; chB10.BackColor = Color.Transparent;
                chB11.Checked = false; chB11.Visible = false; chB11.BackColor = Color.Transparent;
                chB12.Checked = false; chB12.Visible = false; chB12.BackColor = Color.Transparent;
                chB13.Checked = false; chB13.Visible = false; chB13.BackColor = Color.Transparent;
                chB14.Checked = false; chB14.Visible = false; chB14.BackColor = Color.Transparent;
                chB15.Checked = false; chB15.Visible = false; chB15.BackColor = Color.Transparent;
                chB16.Checked = false; chB16.Visible = false; chB16.BackColor = Color.Transparent;
                chB17.Checked = false; chB17.Visible = false; chB17.BackColor = Color.Transparent;
                chB18.Checked = false; chB18.Visible = false; chB18.BackColor = Color.Transparent;
                chB19.Checked = false; chB19.Visible = false; chB19.BackColor = Color.Transparent;
                chB20.Checked = false; chB20.Visible = false; chB20.BackColor = Color.Transparent;

                chB21.Checked = false; chB21.Visible = false; chB21.BackColor = Color.Transparent;
                chB22.Checked = false; chB22.Visible = false; chB22.BackColor = Color.Transparent;
                chB23.Checked = false; chB23.Visible = false; chB23.BackColor = Color.Transparent;
                chB24.Checked = false; chB24.Visible = false; chB24.BackColor = Color.Transparent;
                chB25.Checked = false; chB25.Visible = false; chB25.BackColor = Color.Transparent;
                chB26.Checked = false; chB26.Visible = false; chB26.BackColor = Color.Transparent;
                chB27.Checked = false; chB27.Visible = false; chB27.BackColor = Color.Transparent;
                chB28.Checked = false; chB28.Visible = false; chB28.BackColor = Color.Transparent;
                chB29.Checked = false; chB29.Visible = false; chB29.BackColor = Color.Transparent;
                chB30.Checked = false; chB30.Visible = false; chB30.BackColor = Color.Transparent;
                chB31.Checked = false; chB31.Visible = false; chB31.BackColor = Color.Transparent;
                chB32.Checked = false; chB32.Visible = false; chB32.BackColor = Color.Transparent;
                chB33.Checked = false; chB33.Visible = false; chB33.BackColor = Color.Transparent;
                chB34.Checked = false; chB34.Visible = false; chB34.BackColor = Color.Transparent;
                chB35.Checked = false; chB35.Visible = false; chB35.BackColor = Color.Transparent;
                chB36.Checked = false; chB36.Visible = false; chB36.BackColor = Color.Transparent;
                chB37.Checked = false; chB37.Visible = false; chB37.BackColor = Color.Transparent;
                chB38.Checked = false; chB38.Visible = false; chB38.BackColor = Color.Transparent;
                chB39.Checked = false; chB39.Visible = false; chB39.BackColor = Color.Transparent;

                btn00.Visible = false;
                btn01.Visible = false;
                btn02.Visible = false;
                btn03.Visible = false;
                btn04.Visible = false;
                btn05.Visible = false;
                btn06.Visible = false;
                btn07.Visible = false;
                btn08.Visible = false;
                btn09.Visible = false;
                btn10.Visible = false;
                btn11.Visible = false;
                btn12.Visible = false;
                btn13.Visible = false;
                btn14.Visible = false;
                btn15.Visible = false;
                btn16.Visible = false;
                btn17.Visible = false;

                HeroTT.RemoveAll();

                chB01.Text = "Gold Weapon";
                chB01.Location = new Point(gBAllWeited4p1, p2);
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));

                //Nun sagen, dass die Checkboxen speichern sollen
                chBSave = 1;
            }
        }

        private void btnHeroeinvisible(string H, int SK, int EM, int VP/*, VL*/)
        {
            if (inisSettings.Read(H) == "Y")
            {
                inisSettings.Write(H, "1");
            }
            if (inisSettings.Read(H) != "1" && inisSettings.Read(H) != "2" && inisSettings.Read(H) != "3" && inisSettings.Read(H) != "4" && inisSettings.Read(H) != "5")
            {
                inic.Heroe(H, SK, EM);
                inisSettings.Write(H, "1");
            }
            if (inisSettings.Read(H) == "1")
            {
                inic.VP(H, VP);
                inisSettings.Write(H, "2");
            }
            if (inisSettings.Read(H) == "2")
            {
                inic.create3(H);
                inisSettings.Write(H, "3");
            }
            if (inisSettings.Read(H) == "3")
            {
                inic.create4(H);
                inisSettings.Write(H, "4");
            }
            if (inisSettings.Read(H) == "4")
            {
                inic.create5(H);
                inisSettings.Write(H, "5");
            }

            gBLang.Visible = false;
            btnMoreCost.Visible = false;
            btnBackHero.Visible = true;

            Ana.Visible = false;
            Bastion.Visible = false;
            DVa.Visible = false;
            Doomfist.Visible = false;
            Genji.Visible = false;
            Hanzo.Visible = false;
            Junkrat.Visible = false;
            Lúcio.Visible = false;
            McCree.Visible = false;
            Mei.Visible = false;
            Mercy.Visible = false;
            Moira.Visible = false;
            Orisa.Visible = false;
            Pharah.Visible = false;
            Reaper.Visible = false;
            Reinhardt.Visible = false;
            Roadhog.Visible = false;
            Soldier_76.Visible = false;
            Sombra.Visible = false;
            Symmetra.Visible = false;
            Torbjörn.Visible = false;
            Tracer.Visible = false;
            Widowmaker.Visible = false;
            Winston.Visible = false;
            Zarya.Visible = false;
            Zenyatta.Visible = false;

            gbAll.Visible = true;
            BackSave = gbAll.Text;
            chBSave = 1;

            //Create of Tooltips (if needed)
            HeroTT = new ToolTip();

            // Set up the delays for the ToolTip.
            HeroTT.AutoPopDelay = 10000;
            HeroTT.InitialDelay = 100;
        }

        #region Heroes

        private void Ana_Click(object sender, EventArgs e)
        {
            Heroe = "Ana";
            btnHeroeinvisible(Heroe, 13, 8, 6);
            gbAll.Text = Ana.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Ana.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnAna()
        {
            inisHeroes = new IniStream(appdata + "\\Ana.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3); chB07.Text = "(" + Cost.Epic + ")";
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4); chB08.Text = "(" + Cost.EpicEvent + ")";
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1); chB09.Text = "(" + Cost.Legendary + ")";
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2); chB10.Text = "(" + Cost.Legendary + ")";
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3); chB11.Text = "(" + Cost.Legendary + ")";
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4); chB12.Text = "(" + Cost.Legendary + ")";
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5); chB13.Text = "(" + Cost.LegendaryEvent + ")";
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6); chB14.Text = "(" + Cost.LegendaryEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited4p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited4p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited4p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited4p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited4p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited4p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited4p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited4p2 + chB07.Width, p3 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited4p2 + chB08.Width, p4 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p3 + chB09.Width, p1 - 5);
                btn10.Visible = true; btn10.Location = new Point(gBAllWeited4p3 + chB10.Width, p2 - 5);
                btn11.Visible = true; btn11.Location = new Point(gBAllWeited4p3 + chB11.Width, p3 - 5);
                btn12.Visible = true; btn12.Location = new Point(gBAllWeited4p3 + chB12.Width, p4 - 5);
                btn13.Visible = true; btn13.Location = new Point(gBAllWeited4p3 + chB13.Width, p5 - 5);
                btn14.Visible = true; btn14.Location = new Point(gBAllWeited4p3 + chB14.Width, p6 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Classic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Ana.Citrine_SK;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Ana.Garnet_SK;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Ana.Peridot_SK;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Ana.Turquoise_SK;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Ana.Merciful_SK;//Epic
                btn06.BackColor = Color.DarkViolet; btn06.Text = Ana.Shrike_SK;
                btn07.BackColor = Color.DarkViolet; btn07.Text = Ana.Ghoul_SK;//Halloween 16
                btn08.BackColor = Color.DarkViolet; btn08.Text = Ana.Tal_SK;//Rooster 17
                btn09.BackColor = Color.Gold; btn09.Text = Ana.Wadjet_SK;//Legendary
                btn10.BackColor = Color.Gold; btn10.Text = Ana.Wasteland_SK;
                btn11.BackColor = Color.Gold; btn11.Text = Ana.Captain_Amari_SK;
                btn12.BackColor = Color.Gold; btn12.Text = Ana.Horus_SK;
                btn13.BackColor = Color.Gold; btn13.Text = Ana.Corsair_SK;//Halloween 17
                btn14.BackColor = Color.Gold; btn14.Text = Ana.Snow_Owl_SK;//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Epic + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Epic + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p1, p5); chB04.Text = "(" + Cost.Epic + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p2); chB06.Text = "(" + Cost.EpicEvent + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3); chB07.Text = "(" + Cost.Epic + ")";
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited3p2, p4); chB08.Text = "(" + Cost.EpicEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited3p2 + chB07.Width, p3 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited3p2 + chB08.Width, p4 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//DEfault
                btn01.BackColor = Color.DarkViolet; btn01.Text = Ana.Not_Impressed_EM;//Epic
                btn02.BackColor = Color.DarkViolet; btn02.Text = Ana.Disapproving_EM;
                btn03.BackColor = Color.DarkViolet; btn03.Text = Ana.Protector_EM;
                btn04.BackColor = Color.DarkViolet; btn04.Text = Ana.Take_A_Knee_EM;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Ana.Tea_Time_EM;
                btn06.BackColor = Color.DarkViolet; btn06.Text = Ana.Beach_Ball_EM;//Summer 17
                btn07.BackColor = Color.DarkViolet; btn07.Text = Ana.Candy_EM;//Halloween 16
                btn08.BackColor = Color.DarkViolet; btn08.Text = Ana.Dance_EM;//Annyver 17

                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("EM08"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = "(" + Cost.Rare + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3); chB06.Text = "(" + Cost.RareEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p3 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Ana.Mission_Complete_VP;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Ana.Protector_VP;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Ana.Seated_VP;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Ana.RIP_VP;//Halloween 16
                btn05.BackColor = Color.DeepSkyBlue; btn05.Text = Ana.Toast_VP;//Winter 16
                btn06.BackColor = Color.DeepSkyBlue; btn06.Text = Ana.Folded_Hands_VP;//Rooster 17

                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            if (BackSave2 == Lang.VoiceLines)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p1, p6);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p1, p7);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p1, p8);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p2, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p2, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p2, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p2, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p2, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p2, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p1);
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p2);
                chB17.Visible = true; chB17.Location = new Point(gBAllWeited4p3, p3);
                chB18.Visible = true; chB18.Location = new Point(gBAllWeited4p3, p4);
                chB19.Visible = true; chB19.Location = new Point(gBAllWeited4p3, p5);
                chB20.Visible = true; chB20.Location = new Point(gBAllWeited4p3, p6);
                chB21.Visible = true; chB21.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Ana.Justice_Delivered_VL;//Default
                chB01.BackColor = Color.Gainsboro; chB01.Text = Ana.Children_behave_VL + " (" + Cost.Common + ")";//Common
                chB02.BackColor = Color.Gainsboro; chB02.Text = Ana.Everyone_dies_VL + " (" + Cost.Common + ")";
                chB03.BackColor = Color.Gainsboro; chB03.Text = Ana.It_takes_a_woman_to_know_VL + " (" + Cost.Common + ")";
                chB04.BackColor = Color.Gainsboro; chB04.Text = Ana.Justice_rains_from_above_VL + " (" + Cost.Common + ")";
                chB05.BackColor = Color.Gainsboro; chB05.Text = Ana.Mother_knows_best_VL + " (" + Cost.Common + ")";
                chB06.BackColor = Color.Gainsboro; chB06.Text = Ana.No_scope_needed_VL + " (" + Cost.Common + ")";
                chB07.BackColor = Color.Gainsboro; chB07.Text = Ana.What_are_you_thinking_VL + " (" + Cost.Common + ")";
                chB08.BackColor = Color.Gainsboro; chB08.Text = Ana.Witness_me_VL + " (" + Cost.Common + ")";
                chB09.BackColor = Color.Gainsboro; chB09.Text = Ana.You_know_nothing_VL + " (" + Cost.Common + ")";
                chB10.BackColor = Color.Gainsboro; chB10.Text = Ana.Someone_to_tuck_you_in_VL + " (" + Cost.Common + ")";
                chB11.BackColor = Color.Gainsboro; chB11.Text = Ana.Better_than_retirement_VL + " (" + Cost.CommonEvent + ")";//Summer 17
                chB12.BackColor = Color.Gainsboro; chB12.Text = Ana.Learn_from_the_pain_VL + " (" + Cost.Common + ")";//Summer 16
                chB13.BackColor = Color.Gainsboro; chB13.Text = Ana.Are_you_scared_VL + " (" + Cost.Common + ")";//Halloween 16
                chB14.BackColor = Color.Gainsboro; chB14.Text = Ana.Dont_be_scared_VL + " (" + Cost.CommonEvent + ")";//Halloween 17
                chB21.BackColor = Color.Gainsboro; chB21.Text = Ana.Im_too_old_for_surprises_VL + " (" + Cost.CommonEvent + ")";//Winter 17
                chB15.BackColor = Color.Gainsboro; chB15.Text = Ana.Im_watching_out_for_you_VL + " (" + Cost.CommonEvent + ")";//Winter 16
                chB16.BackColor = Color.Gainsboro; chB16.Text = Ana.The_Moon_in_Winter_VL + " (" + Cost.CommonEvent + ")";//Rooster 17
                chB17.BackColor = Color.Gainsboro; chB17.Text = Ana.Damn_VL + " (" + Cost.CommonEvent + ")";//Uprising 17
                chB18.BackColor = Color.Gainsboro; chB18.Text = Ana.The_Ghost_watches_VL + " (" + Cost.CommonEvent + ")";//Uprising 17
                chB19.BackColor = Color.Gainsboro; chB19.Text = Ana.Follow_me_VL + " (" + Cost.CommonEvent + ")";//Annyver 17
                chB20.BackColor = Color.Gainsboro; chB20.Text = Ana.The_adults_are_talking_VL + " (" + Cost.CommonEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VL01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VL02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VL03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VL04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VL05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VL06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VL07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("VL08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("VL09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("VL10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("VL11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("VL12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("VL13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("VL14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("VL15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("VL16"));
                chB17.Checked = Convert.ToBoolean(inisHeroes.Read("VL17"));
                chB18.Checked = Convert.ToBoolean(inisHeroes.Read("VL18"));
                chB19.Checked = Convert.ToBoolean(inisHeroes.Read("VL19"));
                chB20.Checked = Convert.ToBoolean(inisHeroes.Read("VL20"));
                chB21.Checked = Convert.ToBoolean(inisHeroes.Read("VL21"));
            }
            if (BackSave2 == Lang.Sprays)
            {
                chB01.Visible = true; chB01.Text = Ana.Action_SP + " (" + Cost.Common + ")";//Common
                chB02.Visible = true; chB02.Text = Ana.Ana_SP + " (" + Cost.Common + ")";
                chB03.Visible = true; chB03.Text = Ana.Bearer_SP + " (" + Cost.Common + ")";
                chB04.Visible = true; chB04.Text = Ana.Cheer_SP + " (" + Cost.Common + ")";
                chB05.Visible = true; chB05.Text = Ana.Cracked_SP + " (" + Cost.Common + ")";
                chB06.Visible = true; chB06.Text = Ana.Cute_SP + " (" + Cost.Common + ")";
                chB07.Visible = true; chB07.Text = Ana.Eyepatch_SP + " (" + Cost.Common + ")";
                chB08.Visible = true; chB08.Text = Ana.Fareeha_SP + " (" + Cost.Common + ")";
                chB09.Visible = true; chB09.Text = Ana.Gaze_SP + " (" + Cost.Common + ")";
                chB10.Visible = true; chB10.Text = Ana.Grenade_SP + " (" + Cost.Common + ")";
                chB11.Visible = true; chB11.Text = Ana.Guardian_SP + " (" + Cost.Common + ")";
                chB12.Visible = true; chB12.Text = Ana.Hesitation_SP + " (" + Cost.Common + ")";
                chB13.Visible = true; chB13.Text = Ana.Icon_SP + " (" + Cost.Common + ")";
                chB14.Visible = true; chB14.Text = Ana.Letter_SP + " (" + Cost.Common + ")";
                chB15.Visible = true; chB15.Text = Ana.Old_Soldier_SP + " (" + Cost.Common + ")";
                chB16.Visible = true; chB16.Text = Ana.Overhead_SP + " (" + Cost.Common + ")";
                chB17.Visible = true; chB17.Text = Ana.Pillow_SP + " (" + Cost.Common + ")";
                chB18.Visible = true; chB18.Text = Ana.Photograph_SP + " (" + Cost.Common + ")";
                chB19.Visible = true; chB19.Text = Ana.Pixel_SP + " (" + Cost.Common + ")";
                chB20.Visible = true; chB20.Text = Ana.Rifle_SP + " (" + Cost.Common + ")";
                chB21.Visible = true; chB21.Text = Ana.Shadow_SP + " (" + Cost.Common + ")";
                chB22.Visible = true; chB22.Text = Ana.Shhh_SP + " (" + Cost.Common + ")";
                chB23.Visible = true; chB23.Text = Ana.Sidearm_SP + " (" + Cost.Common + ")";
                chB24.Visible = true; chB24.Text = Ana.Wedjat_SP + " (" + Cost.Common + ")";
                chB25.Visible = true; chB25.Text = Ana.Wrist_Launcher_SP + " (" + Cost.Common + ")";
                chB26.Visible = true; chB26.Text = Ana.Zzz_SP + " (" + Cost.Common + ")";
                chB27.Visible = true; chB27.Text = Ana.Shooting_SP + " (" + Cost.Common + ")";//Summer 16
                chB28.Visible = true; chB28.Text = Ana.Trick_or_Treat_SP + " (" + Cost.Common + ")";//Halloween 16
                chB29.Visible = true; chB29.Text = Ana.Ornament_SP + " (" + Cost.RareEvent + ")";//Winter 16
                chB30.Visible = true; chB30.Text = Ana.Warm_SP + " (" + Cost.RareEvent + ")";//Winter 16
                chB31.Visible = true; chB31.Text = Ana.Dance_SP + " (" + Cost.RareEvent + ")";//Rooster 17
                chB32.Visible = true; chB32.Text = Ana.Dragon_Dance_SP + " (" + Cost.RareEvent + ")";//Rooster 17
                chB33.Visible = true; chB33.Text = Ana.Newborn_SP + " (" + Cost.RareEvent + ")";//Uprising 17
                chB34.Visible = true; chB34.Text = Ana.Ace_of_Hearts_SP + " (" + Cost.RareEvent + ")";//Annyver 17
                if (inisHeroes.Read("SP01") == "1")
                {
                    chB01.Checked = true;
                }
                if (inisHeroes.Read("SP02") == "1")
                {
                    chB02.Checked = true;
                }
                if (inisHeroes.Read("SP03") == "1")
                {
                    chB03.Checked = true;
                }
                if (inisHeroes.Read("SP04") == "1")
                {
                    chB04.Checked = true;
                }
                if (inisHeroes.Read("SP05") == "1")
                {
                    chB05.Checked = true;
                }
                if (inisHeroes.Read("SP06") == "1")
                {
                    chB06.Checked = true;
                }
                if (inisHeroes.Read("SP07") == "1")
                {
                    chB07.Checked = true;
                }
                if (inisHeroes.Read("SP08") == "1")
                {
                    chB08.Checked = true;
                }
                if (inisHeroes.Read("SP09") == "1")
                {
                    chB09.Checked = true;
                }
                if (inisHeroes.Read("SP10") == "1")
                {
                    chB10.Checked = true;
                }
                if (inisHeroes.Read("SP11") == "1")
                {
                    chB11.Checked = true;
                }
                if (inisHeroes.Read("SP12") == "1")
                {
                    chB12.Checked = true;
                }
                if (inisHeroes.Read("SP13") == "1")
                {
                    chB13.Checked = true;
                }
                if (inisHeroes.Read("SP14") == "1")
                {
                    chB14.Checked = true;
                }
                if (inisHeroes.Read("SP15") == "1")
                {
                    chB15.Checked = true;
                }
                if (inisHeroes.Read("SP16") == "1")
                {
                    chB16.Checked = true;
                }
                if (inisHeroes.Read("SP17") == "1")
                {
                    chB17.Checked = true;
                }
                if (inisHeroes.Read("SP18") == "1")
                {
                    chB18.Checked = true;
                }
                if (inisHeroes.Read("SP19") == "1")
                {
                    chB19.Checked = true;
                }
                if (inisHeroes.Read("SP20") == "1")
                {
                    chB20.Checked = true;
                }
                if (inisHeroes.Read("SP21") == "1")
                {
                    chB21.Checked = true;
                }
                if (inisHeroes.Read("SP22") == "1")
                {
                    chB22.Checked = true;
                }
                if (inisHeroes.Read("SP23") == "1")
                {
                    chB23.Checked = true;
                }
                if (inisHeroes.Read("SP24") == "1")
                {
                    chB24.Checked = true;
                }
                if (inisHeroes.Read("SP25") == "1")
                {
                    chB25.Checked = true;
                }
                if (inisHeroes.Read("SP26") == "1")
                {
                    chB26.Checked = true;
                }
                if (inisHeroes.Read("SP27") == "1")
                {
                    chB27.Checked = true;
                }
                if (inisHeroes.Read("SP28") == "1")
                {
                    chB28.Checked = true;
                }
                if (inisHeroes.Read("SP29") == "1")
                {
                    chB29.Checked = true;
                }
                if (inisHeroes.Read("SP30") == "1")
                {
                    chB30.Checked = true;
                }
                if (inisHeroes.Read("SP31") == "1")
                {
                    chB31.Checked = true;
                }
                if (inisHeroes.Read("SP32") == "1")
                {
                    chB32.Checked = true;
                }
                if (inisHeroes.Read("SP33") == "1")
                {
                    chB33.Checked = true;
                }
                if (inisHeroes.Read("SP34") == "1")
                {
                    chB34.Checked = true;
                }
            }
            if (BackSave2 == Lang.HighlightIntros)
            {
                chB01.Visible = true; chB01.Text = Ana.Guardian_HI + " (" + Cost.Epic + ")";//Epic
                chB02.Visible = true; chB02.Text = Ana.Locked_on_HI + " (" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Text = Ana.Shh_HI + " (" + Cost.Epic + ")";
                if (inisHeroes.Read("HI01") == "1")
                {
                    chB01.Checked = true;
                }
                if (inisHeroes.Read("HI02") == "1")
                {
                    chB02.Checked = true;
                }
                if (inisHeroes.Read("HI03") == "1")
                {
                    chB03.Checked = true;
                }
            }
            if (BackSave2 == Lang.PlayerIcons)
            {
                chB01.Visible = true; chB01.Text = Ana.Ana_PI;//Rare
                chB02.Visible = true; chB02.Text = Ana.Watcher_PI;
                chB03.Visible = true; chB03.Text = Ana.Wedjat_PI;
                chB04.Visible = true; chB04.Text = Ana.Shooting_PI;//Summer 16
                chB04.Visible = true; chB04.Text = Ana.Corsair_PI;//Halloween 17
                chB04.Visible = true; chB04.Text = Ana.Anaversary_PI;//Annyver 17
                if (inisHeroes.Read("PI01") == "1")
                {
                    chB01.Checked = true;
                }
                if (inisHeroes.Read("PI02") == "1")
                {
                    chB02.Checked = true;
                }
                if (inisHeroes.Read("PI03") == "1")
                {
                    chB03.Checked = true;
                }
                if (inisHeroes.Read("PI04") == "1")
                {
                    chB04.Checked = true;
                }
                if (inisHeroes.Read("PI05") == "1")
                {
                    chB05.Checked = true;
                }
                if (inisHeroes.Read("PI06") == "1")
                {
                    chB06.Checked = true;
                }
            }
            chBSave = 1;
        }


        private void Bastion_Click(object sender, EventArgs e)
        {
            Heroe = "Bastion";
            btnHeroeinvisible(Heroe, 16, 7, 6);
            gbAll.Text = Bastion.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Bastion.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnBastion()
        {
            inisHeroes = new IniStream(appdata + "\\Bastion.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                Lang.BlizzCon2 = "2016";
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3); chB07.Text = "(" + Lang.BlizzCon + ")"; HeroTT.SetToolTip(chB07, Lang.BlizzCon2);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4); chB08.Text = "(" + Cost.Epic + ")";
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p2, p5); chB09.Text = "(" + Cost.EpicEvent + ")";
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p2, p6); chB10.Text = "(" + Cost.EpicEvent + ")";
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p1); chB11.Text = "(" + Cost.Legendary + ")";
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p2); chB12.Text = "(" + Cost.Legendary + ")";
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p3); chB13.Text = "(" + Cost.Legendary + ")";
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p4); chB14.Text = "(" + Cost.Legendary + ")";
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p5); chB15.Text = "(" + Lang.OriginGotY + ")"; HeroTT.SetToolTip(chB15, Lang.OriginGotY2);
                chB17.Visible = true; chB17.Location = new Point(gBAllWeited4p3, p6); chB17.Text = "(" + Cost.LegendaryEvent + ")";
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p7); chB16.Text = "(" + Cost.LegendaryEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited4p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited4p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited4p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited4p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited4p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited4p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited4p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited4p2 + chB07.Width, p3 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited4p2 + chB08.Width, p4 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p2 + chB09.Width, p5 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p2 + chB09.Width, p5 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p2 + chB09.Width, p5 - 5);
                btn10.Visible = true; btn10.Location = new Point(gBAllWeited4p2 + chB10.Width, p6 - 5);
                btn11.Visible = true; btn11.Location = new Point(gBAllWeited4p3 + chB11.Width, p1 - 5);
                btn12.Visible = true; btn12.Location = new Point(gBAllWeited4p3 + chB12.Width, p2 - 5);
                btn13.Visible = true; btn13.Location = new Point(gBAllWeited4p3 + chB13.Width, p3 - 5);
                btn14.Visible = true; btn14.Location = new Point(gBAllWeited4p3 + chB14.Width, p4 - 5);
                btn15.Visible = true; btn15.Location = new Point(gBAllWeited4p3 + chB15.Width, p5 - 5);
                btn17.Visible = true; btn17.Location = new Point(gBAllWeited4p3 + chB17.Width, p6 - 5);
                btn16.Visible = true; btn16.Location = new Point(gBAllWeited4p3 + chB16.Width, p7 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Classic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Bastion.Dawn_SK;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Bastion.Meadow_SK;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Bastion.Sky_SK;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Bastion.Soot_SK;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Bastion.Defense_Matrix_SK;//Epic
                btn06.BackColor = Color.DarkViolet; btn06.Text = Bastion.Omnic_Crisis_SK;
                btn07.BackColor = Color.DarkViolet; btn07.Text = Bastion.BlizzCon_2016_SK;//BlizzCon 16
                btn08.BackColor = Color.DarkViolet; btn08.Text = Bastion.Tombstone_SK;//Halloween 16
                btn09.BackColor = Color.DarkViolet; btn09.Text = Bastion.Rooster_SK;//Rooster 17
                btn10.BackColor = Color.DarkViolet; btn10.Text = Bastion.Null_Sector_SK;//Uprising 17
                btn11.BackColor = Color.Gold; btn11.Text = Bastion.Antique_SK;//Legendary
                btn12.BackColor = Color.Gold; btn12.Text = Bastion.Woodbot_SK;
                btn13.BackColor = Color.Gold; btn13.Text = Bastion.Gearbot_SK;
                btn14.BackColor = Color.Gold; btn14.Text = Bastion.Steambot_SK;
                btn15.BackColor = Color.Gold; btn15.Text = Bastion.Overgrown_SK;//Origin
                btn17.BackColor = Color.Gold; btn17.Text = Bastion.Avalanche_SK;//Winter 17
                btn16.BackColor = Color.Gold; btn16.Text = Bastion.Dune_Buggy_SK;//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("SK16"));
                chB17.Checked = Convert.ToBoolean(inisHeroes.Read("SK17"));

            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Epic + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Epic + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Epic + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4); chB07.Text = "(" + Cost.EpicEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p3 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited3p2 + chB07.Width, p4 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DarkViolet; btn01.Text = Bastion.Alert_Alert_EM;//Epic
                btn02.BackColor = Color.DarkViolet; btn02.Text = Bastion.Chortle_EM;
                btn03.BackColor = Color.DarkViolet; btn03.Text = Bastion.Dizzy_EM;
                btn04.BackColor = Color.DarkViolet; btn04.Text = Bastion.Rest_Mode_EM;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Bastion.Robot_EM;
                btn06.BackColor = Color.DarkViolet; btn06.Text = Bastion.Boxing_EM;//Summer 16
                btn07.BackColor = Color.DarkViolet; btn07.Text = Bastion.Robo_Boogie_EM;//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = " (" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = " (" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = " (" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = " (" + Cost.RareEvent + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = " (" + Cost.Rare + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3); chB07.Text = " (" + Cost.RareEvent + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p4); chB06.Text = " (" + Cost.RareEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited3p2 + chB07.Width, p3 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p4 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Bastion.Birdwatching_VP;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Bastion.Pop_up_VP;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Bastion.Tank_EM;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Bastion.Medal_VP;//Summer 17
                btn05.BackColor = Color.DeepSkyBlue; btn05.Text = Bastion.RIP_VP;//Halloween 16
                btn07.BackColor = Color.DeepSkyBlue; btn07.Text = Bastion.Toast_VP;//Winter 17
                btn06.BackColor = Color.DeepSkyBlue; btn06.Text = Bastion.Firework_VP;//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VP07"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            if (BackSave2 == Lang.VoiceLines)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p1, p6);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p1, p7);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p1, p8);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p2, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p2, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p2, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p2, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p2, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p2, p7);
                chB21.Visible = true; chB21.Location = new Point(gBAllWeited4p3, p1);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p2);
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p3);
                chB17.Visible = true; chB17.Location = new Point(gBAllWeited4p3, p4);
                chB18.Visible = true; chB18.Location = new Point(gBAllWeited4p3, p5);
                chB19.Visible = true; chB19.Location = new Point(gBAllWeited4p3, p6);
                chB20.Visible = true; chB20.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Bastion.Beeple_VL;//Default
                chB01.BackColor = Color.Gainsboro; chB01.Text = Bastion.Doo_Woo_VL + " (" + Cost.Common + ")";
                chB02.BackColor = Color.Gainsboro; chB02.Text = Bastion.Boo_Boo_Doo_De_Doo_VL + " (" + Cost.Common + ")";
                chB03.BackColor = Color.Gainsboro; chB03.Text = Bastion.Bweeeeeeeeeee_VL + " (" + Cost.Common + ")";
                chB04.BackColor = Color.Gainsboro; chB04.Text = Bastion.Chirr_Chirr_Chirr_VL + " (" + Cost.Common + ")";
                chB05.BackColor = Color.Gainsboro; chB05.Text = Bastion.Dah_Dah_Weeeee_VL + " (" + Cost.Common + ")";
                chB06.BackColor = Color.Gainsboro; chB06.Text = Bastion.Dun_Dun_Boop_Boop_VL + " (" + Cost.Common + ")";
                chB07.BackColor = Color.Gainsboro; chB07.Text = Bastion.Dweet_Dweet_Dweet_VL + " (" + Cost.Common + ")";
                chB08.BackColor = Color.Gainsboro; chB08.Text = Bastion.Hee_Hoo_Hoo_VL + " (" + Cost.Common + ")";
                chB09.BackColor = Color.Gainsboro; chB09.Text = Bastion.Sh_Sh_Sh_VL + " (" + Cost.Common + ")";
                chB10.BackColor = Color.Gainsboro; chB10.Text = Bastion.Zwee_VL + " (" + Cost.Common + ")";
                chB11.BackColor = Color.Gainsboro; chB11.Text = Bastion.Doo_Do_Doo_Dee_VL + " (" + Cost.RareEvent + ")";//Summer 17
                chB12.BackColor = Color.Gainsboro; chB12.Text = Bastion.Whoo_Vweeeeee_VL + " (" + Cost.Common + ")";//Summer 16
                chB13.BackColor = Color.Gainsboro; chB13.Text = Bastion.Oooooooooooo_VL + " (" + Cost.RareEvent + ")";//Halloween 17
                chB14.BackColor = Color.Gainsboro; chB14.Text = Bastion.W_W_Wooooo_VL + " (" + Cost.Common + ")";//Halloween 16
                chB21.BackColor = Color.Gainsboro; chB21.Text = Bastion.Bwoo_Bwoo_Bwoo_VL + " (" + Cost.RareEvent + ")";//Winter 17
                chB15.BackColor = Color.Gainsboro; chB15.Text = Bastion.Dwee_Doo_Hoo_VL + " (" + Cost.Rare + ")";//Winter 16
                chB16.BackColor = Color.Gainsboro; chB16.Text = Bastion.Woop_Doo_Woo_Dun_Woop_VL + " (" + Cost.RareEvent + ")";//Rooster 17
                chB17.BackColor = Color.Gainsboro; chB17.Text = Bastion.Dwee_Wee_Woh_VL + " (" + Cost.RareEvent + ")";//Uprising 17
                chB18.BackColor = Color.Gainsboro; chB18.Text = Bastion.Zwee_Ah_Wheee_Doo_Woo_VL + " (" + Cost.RareEvent + ")";//Uprising 17
                chB19.BackColor = Color.Gainsboro; chB19.Text = Bastion.Bew_Woo_Bew_Woo_VL + " (" + Cost.RareEvent + ")";//Annyver 17
                chB20.BackColor = Color.Gainsboro; chB20.Text = Bastion.Doo_Dun_Dun_Woo_VL + " (" + Cost.RareEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VL01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VL02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VL03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VL04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VL05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VL06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VL07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("VL08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("VL09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("VL10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("VL11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("VL12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("VL13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("VL14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("VL15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("VL16"));
                chB17.Checked = Convert.ToBoolean(inisHeroes.Read("VL17"));
                chB18.Checked = Convert.ToBoolean(inisHeroes.Read("VL18"));
                chB19.Checked = Convert.ToBoolean(inisHeroes.Read("VL19"));
                chB20.Checked = Convert.ToBoolean(inisHeroes.Read("VL20"));
                chB21.Checked = Convert.ToBoolean(inisHeroes.Read("VL21"));
            }
            chBSave = 1;
        }


        private void DVa_Click(object sender, EventArgs e)
        {
            Heroe = "DVa";
            btnHeroeinvisible("D.Va", 14, 7, 6);
            gbAll.Text = DVa.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\D.Va.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnDVa()
        {
            inisHeroes = new IniStream(appdata + "\\D.Va.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3); chB07.Text = "(" + Cost.Epic + ")";
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1); chB08.Text = "(" + Cost.Legendary + ")";
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2); chB09.Text = "(" + Cost.Legendary + ")";
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3); chB10.Text = "(" + Cost.Legendary + ")";
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4); chB11.Text = "(" + Cost.Legendary + ")";
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5); chB12.Text = "(" + Cost.Legendary + ")";
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6); chB13.Text = "(" + Cost.LegendaryEvent + ")";
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7); chB14.Text = "(" + Cost.LegendaryEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited4p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited4p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited4p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited4p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited4p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited4p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited4p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited4p2 + chB07.Width, p3 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited4p3 + chB08.Width, p1 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p3 + chB09.Width, p2 - 5);
                btn10.Visible = true; btn10.Location = new Point(gBAllWeited4p3 + chB10.Width, p3 - 5);
                btn11.Visible = true; btn11.Location = new Point(gBAllWeited4p3 + chB11.Width, p4 - 5);
                btn12.Visible = true; btn12.Location = new Point(gBAllWeited4p3 + chB12.Width, p5 - 5);
                btn13.Visible = true; btn13.Location = new Point(gBAllWeited4p3 + chB13.Width, p6 - 5);
                btn14.Visible = true; btn14.Location = new Point(gBAllWeited4p3 + chB14.Width, p7 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Classic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = DVa.Blueberry_SK;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = DVa.Lemon_Lime_SK;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = DVa.Tangerine_SK;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = DVa.Watermelon_SK;
                btn05.BackColor = Color.DarkViolet; btn05.Text = DVa.Carbon_Fiber_SK;//Epic
                btn06.BackColor = Color.DarkViolet; btn06.Text = DVa.White_Rabbit_SK;
                btn07.BackColor = Color.DarkViolet; btn07.Text = DVa.Taegeukgi_SK;//Summer 16
                btn08.BackColor = Color.Gold; btn08.Text = DVa.Junker_SK;//Legendary
                btn09.BackColor = Color.Gold; btn09.Text = DVa.Scavenger_SK;
                btn10.BackColor = Color.Gold; btn10.Text = DVa.BVa_SK;
                btn11.BackColor = Color.Gold; btn11.Text = DVa.Junebug_SK;
                btn12.BackColor = Color.Gold; btn12.Text = DVa.Officer_SK;
                btn13.BackColor = Color.Gold; btn13.Text = DVa.Palanquin_SK;//Rooster 17
                btn14.BackColor = Color.Gold; btn14.Text = DVa.Cruiser_SK;//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));

            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Epic + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Epic + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Epic + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3); chB06.Text = "(" + Cost.EpicEvent + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4); chB07.Text = "(" + Cost.Legendary + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p3 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited3p2 + chB07.Width, p4 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DarkViolet; btn01.Text = DVa._O__EM;//Epic
                btn02.BackColor = Color.DarkViolet; btn02.Text = DVa.Bunny_Hop_EM;
                btn03.BackColor = Color.DarkViolet; btn03.Text = DVa.Heartbreaker_EM;
                btn04.BackColor = Color.DarkViolet; btn04.Text = DVa.Party_Time_EM;
                btn05.BackColor = Color.DarkViolet; btn05.Text = DVa.Bow_EM;//Rooster 17
                btn06.BackColor = Color.DarkViolet; btn06.Text = DVa.Dance_EM;//Annyver 17
                btn07.BackColor = Color.Gold; btn07.Text = DVa.Game_On_EM;//Legendary

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = "(" + Cost.Rare + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3); chB06.Text = "(" + Cost.RareEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p3 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = DVa.I_Heart_You_VP;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = DVa.Peace_VP;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = DVa.Sitting_VP;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = DVa.RIP_VP;//Halloween 16
                btn05.BackColor = Color.DeepSkyBlue; btn05.Text = DVa.Festive_VP;//Winter 16
                btn06.BackColor = Color.DeepSkyBlue; btn06.Text = DVa.Lucky_Pouch_VP;//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            if (BackSave2 == Lang.VoiceLines)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p1, p6);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p1, p7);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p1, p8);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p2, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p2, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p2, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p2, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p2, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p1, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p1);
                chB21.Visible = true; chB21.Location = new Point(gBAllWeited4p3, p2);
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p3);
                chB17.Visible = true; chB17.Location = new Point(gBAllWeited4p3, p4);
                chB18.Visible = true; chB18.Location = new Point(gBAllWeited4p3, p5);
                chB19.Visible = true; chB19.Location = new Point(gBAllWeited4p3, p6);
                chB20.Visible = true; chB20.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = DVa.Love_DVa_VL;//Default
                chB01.BackColor = Color.Gainsboro; chB01.Text = DVa.Winkyface_VL + " (" + Cost.Common + ")";//Common
                chB02.BackColor = Color.Gainsboro; chB02.Text = DVa.A_new_challenger_VL + " (" + Cost.Common + ")";
                chB03.BackColor = Color.Gainsboro; chB03.Text = DVa.AFK_VL + " (" + Cost.Common + ")";
                chB04.BackColor = Color.Gainsboro; chB04.Text = DVa.Aw_Yeah_VL + " (" + Cost.Common + ")";
                chB05.BackColor = Color.Gainsboro; chB05.Text = DVa.DVa_1_Bad_Guys_0_VL + " (" + Cost.Common + ")";
                chB06.BackColor = Color.Gainsboro; chB06.Text = DVa.GG_VL + " (" + Cost.Common + ")";
                chB07.BackColor = Color.Gainsboro; chB07.Text = DVa.I_play_to_win_VL + " (" + Cost.Common + ")";
                chB08.BackColor = Color.Gainsboro; chB08.Text = DVa.Is_this_Easy_Mode_VL + " (" + Cost.Common + ")";
                chB09.BackColor = Color.Gainsboro; chB09.Text = DVa.LOL_VL + " (" + Cost.Common + ")";
                chB10.BackColor = Color.Gainsboro; chB10.Text = DVa.No_hacks_required_VL + " (" + Cost.Common + ")";
                chB11.BackColor = Color.Gainsboro; chB11.Text = DVa.Im_N_1_VL + " (" + Cost.Common + ")";//Summer 16
                chB12.BackColor = Color.Gainsboro; chB12.Text = DVa.Scoreboard_VL + " (" + Cost.CommonEvent + ")";//Summer 17
                chB13.BackColor = Color.Gainsboro; chB13.Text = DVa.Happy_Halloween_VL + " (" + Cost.Common + ")";//Halloween 16
                chB14.BackColor = Color.Gainsboro; chB14.Text = DVa.Im_not_scared_VL + " (" + Cost.CommonEvent + ")";//Halloween 17
                chB21.BackColor = Color.Gainsboro; chB21.Text = DVa.Happy_Holidays_VL + " (" + Cost.Common + ")";//Winter 16
                chB15.BackColor = Color.Gainsboro; chB15.Text = DVa.Aw_you_shouldnt_have_VL + " (" + Cost.CommonEvent + ")";//Winter 17
                chB16.BackColor = Color.Gainsboro; chB16.Text = DVa.The_best_things_in_life_VL + " (" + Cost.CommonEvent + ")";//Rooster 17
                chB17.BackColor = Color.Gainsboro; chB17.Text = DVa.Not_taking_me_seriously_VL + " (" + Cost.CommonEvent + ")";//Uprising 17
                chB18.BackColor = Color.Gainsboro; chB18.Text = DVa.Try_and_keep_up_VL + " (" + Cost.CommonEvent + ")";//Uprising 17
                chB19.BackColor = Color.Gainsboro; chB19.Text = DVa.Level_Up_VL + " (" + Cost.CommonEvent + ")";//Annyver 17
                chB20.BackColor = Color.Gainsboro; chB20.Text = DVa.No_Way_VL + " (" + Cost.CommonEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VL01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VL02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VL03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VL04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VL05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VL06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VL07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("VL08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("VL09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("VL10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("VL11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("VL12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("VL13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("VL14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("VL15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("VL16"));
                chB17.Checked = Convert.ToBoolean(inisHeroes.Read("VL17"));
                chB18.Checked = Convert.ToBoolean(inisHeroes.Read("VL18"));
                chB19.Checked = Convert.ToBoolean(inisHeroes.Read("VL19"));
                chB20.Checked = Convert.ToBoolean(inisHeroes.Read("VL20"));
                chB21.Checked = Convert.ToBoolean(inisHeroes.Read("VL21"));
            }
            chBSave = 1;
        }

        private void Doomfist_Click(object sender, EventArgs e)
        {
            Heroe = "Doomfist";
            btnHeroeinvisible(Heroe, 10, 5, 3);
            gbAll.Text = Doomfist.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Doomfist.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnDoomfist()
        {
            inisHeroes = new IniStream(appdata + "\\Doomfist.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p3, p1); chB07.Text = "(" + Cost.Legendary + ")";
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p2); chB08.Text = "(" + Cost.Legendary + ")";
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p3); chB09.Text = "(" + Cost.Legendary + ")";
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p4); chB10.Text = "(" + Cost.Legendary + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited4p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited4p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited4p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited4p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited4p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited4p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited4p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited4p3 + chB07.Width, p1 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited4p3 + chB08.Width, p2 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p3 + chB09.Width, p3 - 5);
                btn10.Visible = true; btn10.Location = new Point(gBAllWeited4p3 + chB10.Width, p4 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Classic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Doomfist.Daisy_SK;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Doomfist.Lake_SK;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Doomfist.Plains_SK;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Doomfist.Sunset_SK;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Doomfist.Leopard_SK;//Epic
                btn06.BackColor = Color.DarkViolet; btn06.Text = Doomfist.Painted_SK;
                btn07.BackColor = Color.Gold; btn07.Text = Doomfist.Caution_SK;//Legendary
                btn08.BackColor = Color.Gold; btn08.Text = Doomfist.Irin_SK;
                btn09.BackColor = Color.Gold; btn09.Text = Doomfist.Avatar_SK;
                btn10.BackColor = Color.Gold; btn10.Text = Doomfist.Spirit_SK;

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Epic + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p1); chB03.Text = "(" + Cost.Epic + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p2); chB04.Text = "(" + Cost.Epic + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3); chB05.Text = "(" + Cost.Epic + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p2 + chB03.Width, p1 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p2 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p3 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DarkViolet; btn01.Text = Doomfist.Fake_Out_EM;//Epic
                btn02.BackColor = Color.DarkViolet; btn02.Text = Doomfist.Intimidate_EM;
                btn03.BackColor = Color.DarkViolet; btn03.Text = Doomfist.Ready_for_Battle_EM;
                btn04.BackColor = Color.DarkViolet; btn04.Text = Doomfist.Take_a_knee_EM;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Doomfist.Thumbs_Down_EM;

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p2, p1); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p2); chB03.Text = "(" + Cost.Rare + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p2 + chB02.Width, p1 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p2 + chB03.Width, p2 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Doomfist.Intense_VP;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Doomfist.Seismic_Slam_VP;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Doomfist.Superior_VP;

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
            }
            if (BackSave2 == Lang.VoiceLines)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p1, p6);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p1);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p2);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p3);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p2, p4);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p2, p5);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p2, p6);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p1);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p2);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p3);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p4);
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p5);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Doomfist.Try_me_VL;//Default
                chB01.BackColor = Color.Gainsboro; chB01.Text = Doomfist.Combo_Breakere_VL + " (" + Cost.Common + ")";//Common
                chB02.BackColor = Color.Gainsboro; chB02.Text = Doomfist.Dont_get_back_up_VL + " (" + Cost.Common + ")";
                chB03.BackColor = Color.Gainsboro; chB03.Text = Doomfist.Go_and_sit_down_VL + " (" + Cost.Common + ")";
                chB04.BackColor = Color.Gainsboro; chB04.Text = Doomfist.I_havent_even_started_VL + " (" + Cost.Common + ")";
                chB05.BackColor = Color.Gainsboro; chB05.Text = Doomfist.K_O_VL + " (" + Cost.Common + ")";
                chB06.BackColor = Color.Gainsboro; chB06.Text = Doomfist.One_punch_is_all_i_need_VL + " (" + Cost.Common + ")";
                chB07.BackColor = Color.Gainsboro; chB07.Text = Doomfist.Spare_me_the_commentary_VL + " (" + Cost.Common + ")";
                chB08.BackColor = Color.Gainsboro; chB08.Text = Doomfist.Talk_to_the_fist_VL + " (" + Cost.Common + ")";
                chB09.BackColor = Color.Gainsboro; chB09.Text = Doomfist.Youre_not_bad_VL + " (" + Cost.Common + ")";
                chB10.BackColor = Color.Gainsboro; chB10.Text = Doomfist.You_must_be_joking_VL + " (" + Cost.Common + ")";
                chB11.BackColor = Color.Gainsboro; chB11.Text = Doomfist.I_make_medicine_sick_VL + " (" + Cost.CommonEvent + ")";//Summer 17
                chB12.BackColor = Color.Gainsboro; chB12.Text = Doomfist.Make_you_punch_drunk_VL + " (" + Cost.CommonEvent + ")";//Summer 17
                chB13.BackColor = Color.Gainsboro; chB13.Text = Doomfist.I_have_something_for_you_VL + " (" + Cost.CommonEvent + ")";//Halloween 17
                chB14.BackColor = Color.Gainsboro; chB14.Text = Doomfist.You_should_be_scared_VL + " (" + Cost.CommonEvent + ")";//Halloween 17
                chB15.BackColor = Color.Gainsboro; chB15.Text = Doomfist.And_they_sais_chivalry_is_dead_VL + " (" + Cost.CommonEvent + ")";//Winter 17
                chB16.BackColor = Color.Gainsboro; chB16.Text = Doomfist.Did_you_bring_me_a_present_VL + " (" + Cost.CommonEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VL01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VL02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VL03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VL04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VL05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VL06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VL07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("VL08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("VL09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("VL10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("VL11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("VL12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("VL13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("VL14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("VL15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("VL16"));
            }
            chBSave = 1;
        }

        private void Genji_Click(object sender, EventArgs e)
        {
            Heroe = "Genji";
            btnHeroeinvisible(Heroe, 14, 6, 5);
            gbAll.Text = Genji.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Genji.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnGenji()
        {
            inisHeroes = new IniStream(appdata + "\\Genji.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5); chB04.Text = "(" + Cost.Rare + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2); chB06.Text = "(" + Cost.Epic + ")";
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3); chB07.Text = "(" + Cost.Epic + ")";
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1); chB08.Text = "(" + Cost.Legendary + ")";
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2); chB09.Text = "(" + Cost.Legendary + ")";
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3); chB10.Text = "(" + Cost.Legendary + ")";
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4); chB11.Text = "(" + Cost.Legendary + ")";
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5); chB12.Text = "(" + Cost.Legendary + ")";
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6); chB13.Text = "(" + Cost.LegendaryEvent + ")";
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7); chB14.Text = "(" + Cost.LegendaryEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited4p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited4p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited4p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited4p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited4p1 + chB04.Width, p5 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited4p2 + chB05.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited4p2 + chB06.Width, p2 - 5);
                btn07.Visible = true; btn07.Location = new Point(gBAllWeited4p2 + chB07.Width, p3 - 5);
                btn08.Visible = true; btn08.Location = new Point(gBAllWeited4p3 + chB08.Width, p1 - 5);
                btn09.Visible = true; btn09.Location = new Point(gBAllWeited4p3 + chB09.Width, p2 - 5);
                btn10.Visible = true; btn10.Location = new Point(gBAllWeited4p3 + chB10.Width, p3 - 5);
                btn11.Visible = true; btn11.Location = new Point(gBAllWeited4p3 + chB11.Width, p4 - 5);
                btn12.Visible = true; btn12.Location = new Point(gBAllWeited4p3 + chB12.Width, p5 - 5);
                btn13.Visible = true; btn13.Location = new Point(gBAllWeited4p3 + chB13.Width, p6 - 5);
                btn14.Visible = true; btn14.Location = new Point(gBAllWeited4p3 + chB14.Width, p7 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Classic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Genji.Azurite_SK;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Genji.Cinnabar_SK;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Genji.Malachite_SK;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Genji.Ochre_SK;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Genji.Carbon_Fiber_SK;//Epic
                btn06.BackColor = Color.DarkViolet; btn06.Text = Genji.Chrome_SK;
                btn07.BackColor = Color.DarkViolet; btn07.Text = Genji.Nihon_SK;//Summer 16
                btn08.BackColor = Color.Gold; btn08.Text = Genji.Sparrow_SK;//Legendary
                btn09.BackColor = Color.Gold; btn09.Text = Genji.Young_Genji_SK;
                btn10.BackColor = Color.Gold; btn10.Text = Genji.Bedouin_SK;
                btn11.BackColor = Color.Gold; btn11.Text = Genji.Nomad_SK;
                btn12.BackColor = Color.Gold; btn12.Text = Genji.Oni_SK;
                btn13.BackColor = Color.Gold; btn13.Text = Genji.Blackwatch_SK;//Uprising 17
                btn14.BackColor = Color.Gold; btn14.Text = Genji.Sentai_SK;//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Epic + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Epic + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Epic + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Epic + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2); chB05.Text = "(" + Cost.Epic + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3); chB06.Text = "(" + Cost.EpicEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p2 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p3 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DarkViolet; btn01.Text = Genji.Amusing_EM;//Rare
                btn02.BackColor = Color.DarkViolet; btn02.Text = Genji.Challenge_EM;
                btn03.BackColor = Color.DarkViolet; btn03.Text = Genji.Cutting_Edge_EM;
                btn04.BackColor = Color.DarkViolet; btn04.Text = Genji.Meditate_EM;
                btn05.BackColor = Color.DarkViolet; btn05.Text = Genji.Salute_EM;
                btn06.BackColor = Color.DarkViolet; btn06.Text = Genji.Dance_EM;//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1); chB00.Text = "(" + Cost.Classic + ")";
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2); chB01.Text = "(" + Cost.Rare + ")";
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3); chB02.Text = "(" + Cost.Rare + ")";
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4); chB03.Text = "(" + Cost.Rare + ")";
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1); chB04.Text = "(" + Cost.Rare + ")";
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p2); chB06.Text = "(" + Cost.RareEvent + ")";
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3); chB05.Text = "(" + Cost.RareEvent + ")";

                btn00.Visible = true; btn00.Location = new Point(gBAllWeited3p1 + chB00.Width, p1 - 5);
                btn01.Visible = true; btn01.Location = new Point(gBAllWeited3p1 + chB01.Width, p2 - 5);
                btn02.Visible = true; btn02.Location = new Point(gBAllWeited3p1 + chB02.Width, p3 - 5);
                btn03.Visible = true; btn03.Location = new Point(gBAllWeited3p1 + chB03.Width, p4 - 5);
                btn04.Visible = true; btn04.Location = new Point(gBAllWeited3p2 + chB04.Width, p1 - 5);
                btn06.Visible = true; btn06.Location = new Point(gBAllWeited3p2 + chB06.Width, p2 - 5);
                btn05.Visible = true; btn05.Location = new Point(gBAllWeited3p2 + chB05.Width, p3 - 5);

                btn00.BackColor = Color.Gainsboro; btn00.Text = Lang.Heroic;//Default
                btn01.BackColor = Color.DeepSkyBlue; btn01.Text = Genji.Kneeling_VP;//Rare
                btn02.BackColor = Color.DeepSkyBlue; btn02.Text = Genji.Shuriken_VP;
                btn03.BackColor = Color.DeepSkyBlue; btn03.Text = Genji.Sword_Stance_VP;
                btn04.BackColor = Color.DeepSkyBlue; btn04.Text = Genji.RIP_VP;//Halloween 16
                btn06.BackColor = Color.DeepSkyBlue; btn06.Text = Genji.Toast_VP;//Winter 17
                btn05.BackColor = Color.DeepSkyBlue; btn05.Text = Genji.Meditate_EM;//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }//////////////

        private void Hanzo_Click(object sender, EventArgs e)
        {
            Heroe = "Hanzo";
            btnHeroeinvisible(Heroe, 12, 7, 6);
            gbAll.Text = Hanzo.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Hanzo.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnHanzo()
        {
            inisHeroes = new IniStream(appdata + "\\Hanzo.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p6);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Hanzo.Azuki_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Hanzo.Kinoko_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Hanzo.Midori_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Hanzo.Sora_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Hanzo.Cloud_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Hanzo.Dragon_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Hanzo.Demon_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.Gold; chB08.Text = Hanzo.Young_Hanzo_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Hanzo.Young_Master_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Hanzo.Lone_Wolf_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Hanzo.Okami_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = Hanzo.Casual_SK + " (" + Cost.LegendaryEvent + ")";//Winter 17
                chB12.BackColor = Color.Gold; chB12.Text = Hanzo.Cyberninja_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Hanzo.Beckon_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Hanzo.Brush_Shoulder_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Hanzo.Chuckle_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Hanzo.Meditate_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Hanzo.Victory_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Hanzo.Training_EM + " (" + Cost.EpicEvent + ")";//Uprising 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Hanzo.Fisherman_Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Hanzo.Confident_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Hanzo.Kneeling_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Hanzo.Over_the_shoulder_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Hanzo.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Hanzo.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Hanzo.Skewered_VP + " (" + Cost.RareEvent + ")";//Halloween 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Junkrat_Click(object sender, EventArgs e)
        {
            Heroe = "Junkrat";
            btnHeroeinvisible(Heroe, 13, 7, 7);
            gbAll.Text = Junkrat.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Junkrat.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnJunkrat()
        {
            inisHeroes = new IniStream(appdata + "\\Junkrat.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Junkrat.Bleached_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Junkrat.Drowned_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Junkrat.Irradiated_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Junkrat.Rusted_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Junkrat.Jailbird_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Junkrat.Toasted_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Junkrat.Firework_SK + " (" + Cost.EpicEvent + ")";//Rooster 17
                chB08.BackColor = Color.Gold; chB08.Text = Junkrat.Fool_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Junkrat.Jester_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Junkrat.Hayseed_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Junkrat.Scarecrow_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Junkrat.Dr_Junkenstein_SK + " (" + Cost.Legendary + ")";//Halloween 16
                chB13.BackColor = Color.Gold; chB13.Text = Junkrat.Cricket_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB14.BackColor = Color.Gold; chB14.Text = Junkrat.Beachrat_SK + " (" + Cost.LegendaryEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Junkrat.Cant_Deal_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Junkrat.Juggling_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Junkrat.Lounging_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Junkrat.Puppet_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Junkrat.Vaudeville_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Junkrat.Dud_EM + " (" + Cost.EpicEvent + ")";//Uprising 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Junkrat.Running_Rat_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Junkrat.Itll_freeze_that_way_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Junkrat.Kneeling_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Junkrat.Nyah_Nyah_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Junkrat.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Junkrat.Pumpkin_VP + " (" + Cost.RareEvent + ")";//Halloween 17
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Junkrat.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB07.BackColor = Color.DeepSkyBlue; chB07.Text = Junkrat.Bad_for_your_health_VP + " (" + Cost.RareEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VP07"));
            }
            chBSave = 1;
        }

        private void Lúcio_Click(object sender, EventArgs e)
        {
            Heroe = "Lúcio";
            btnHeroeinvisible(Heroe, 14, 7, 6);
            gbAll.Text = Lúcio.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Lúcio.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnLúcio()
        {
            inisHeroes = new IniStream(appdata + "\\Lúcio.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Lúcio.Azul_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Lúcio.Laranja_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Lúcio.Roxo_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Lúcio.Vermelho_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Lúcio.Auditiva_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Lúcio.Synaesthesia_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Lúcio.Andes_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB08.BackColor = Color.Gold; chB08.Text = Lúcio.Hippityhop_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Lúcio.Ribbit_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Lúcio.Breakaway_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Lúcio.Slapshot_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Lúcio.Seleção_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB13.BackColor = Color.Gold; chB13.Text = Lúcio.Striker_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB14.BackColor = Color.Gold; chB14.Text = Lúcio.Jazzy_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Lúcio.Capoeira_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Lúcio.Chilling_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Lúcio.In_the_Groove_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Lúcio.Knee_Slapper_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Lúcio.Nah_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Lúcio.Juggle_EM + " (" + Cost.Epic + ")";//Summer 16
                chB07.BackColor = Color.DarkViolet; chB07.Text = Lúcio.Smooth_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Lúcio.Configent_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Lúcio.Grooving_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Lúcio.Ready_for_action_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Lúcio.Pumpkin_Control_VP + " (" + Cost.RareEvent + ")";//Halloween 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Lúcio.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Lúcio.Handstand_VP + " (" + Cost.RareEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void McCree_Click(object sender, EventArgs e)
        {
            Heroe = "McCree";
            btnHeroeinvisible(Heroe, 15, 7, 5);
            gbAll.Text = McCree.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\McCree.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnMcCree()
        {
            inisHeroes = new IniStream(appdata + "\\McCree.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = McCree.Ebony_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = McCree.Lake_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = McCree.Sage_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = McCree.Wheat_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = McCree.On_The_Range_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = McCree.White_Hat_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = McCree.American_SK + " (" + Cost.Epic + ")";//Summer 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = McCree.Scrooge_SK + " (" + Cost.Epic + ")";//Winter 16
                chB09.BackColor = Color.Gold; chB09.Text = McCree.Gambler_SK + " (" + Cost.Legendary + ")";//Legendary
                chB10.BackColor = Color.Gold; chB10.Text = McCree.Riverboat_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = McCree.Mystery_Man_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = McCree.Vigilante_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = McCree.Lifeguard_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB14.BackColor = Color.Gold; chB14.Text = McCree.Van_Helsing_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB15.BackColor = Color.Gold; chB15.Text = McCree.Blackwatch_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = McCree.Gunspinning_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = McCree.Hat_Tip_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = McCree.Joker_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = McCree.Spit_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = McCree.Take_a_load_off_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = McCree.Hat_Trick_EM + " (" + Cost.Epic + ")";//Winter 16
                chB07.BackColor = Color.DarkViolet; chB07.Text = McCree.Line_Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p1);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p2);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = McCree.Contemplative_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = McCree.Over_the_shoulder_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = McCree.Take_it_easy_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = McCree.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = McCree.Showdown_VP + " (" + Cost.RareEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
            }
            chBSave = 1;
        }

        private void Mei_Click(object sender, EventArgs e)
        {
            Heroe = "Mei";
            btnHeroeinvisible(Heroe, 15, 9, 6);
            gbAll.Text = Mei.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Mei.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnMei()
        {
            inisHeroes = new IniStream(appdata + "\\Mei.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p3, p1);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p2);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p3);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p4);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p5);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p6);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p7);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p8);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p9);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Mei.Chrysanthemum_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Mei.Heliotrope_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Mei.Jade_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Mei.Persimmon_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Mei.Earthen_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Mei.Snow_Plum_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.Gold; chB07.Text = Mei.Firefighter_SK + " (" + Cost.Legendary + ")";//Legendary
                chB08.BackColor = Color.Gold; chB08.Text = Mei.Rescue_Mei_SK + " (" + Cost.Legendary + ")";
                chB09.BackColor = Color.Gold; chB09.Text = Mei.Abominable_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Mei.Yeti_Hunter_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Mei.Jiangshi_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB12.BackColor = Color.Gold; chB12.Text = Mei.Mei_rry_SK + " (" + Cost.LegendaryEvent + ")";//Winter 16
                chB13.BackColor = Color.Gold; chB13.Text = Mei.Chang_e_SK + " (" + Cost.LegendaryEvent + ")";//Rooster 17
                chB14.BackColor = Color.Gold; chB14.Text = Mei.Luna_SK + " (" + Cost.LegendaryEvent + ")";//Rooster 17
                chB15.BackColor = Color.Gold; chB15.Text = Mei.Beekeeper_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited3p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited3p2, p5);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Mei.Companion_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Mei.Gigle_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Mei.Kneel_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Mei.Spray_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Mei.Yaaaaaaaaay_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Mei.Hopping_EM + " (" + Cost.EpicEvent + ")";//Halloween 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Mei.Snowman_EM + " (" + Cost.Epic + ")";//Winter 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = Mei.So_excited_EM + " (" + Cost.EpicEvent + ")";//Rooster 17
                chB09.BackColor = Color.DarkViolet; chB09.Text = Mei.Sunny_Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("EM08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("EM09"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Mei.Casual_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Mei.Hands_on_hips_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Mei.Kneeling_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Mei.Medal_VP + " (" + Cost.Epic + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Mei.RIP_VP + " (" + Cost.Epic + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Mei.Lucky_VP + " (" + Cost.EpicEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }
        //

        private void Mercy_Click(object sender, EventArgs e)
        {
            Heroe = "Mercy";
            btnHeroeinvisible(Heroe, 15, 6, 6);
            gbAll.Text = Mercy.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Mercy.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnMercy()
        {
            inisHeroes = new IniStream(appdata + "\\Mercy.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Mercy.Celestial_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Mercy.Mist_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Mercy.Orchid_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Mercy.Verdant_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Mercy.Amber_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Mercy.Cobalt_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Mercy.Eidgenossin_SK + " (" + Cost.Epic + ")";//Summer 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = Mercy.Fortune_SK + " (" + Cost.EpicEvent + ")";//Rooster 17
                chB09.BackColor = Color.Gold; chB09.Text = Mercy.Sigrun_SK + " (" + Cost.Legendary + ")";//Legendary
                chB10.BackColor = Color.Gold; chB10.Text = Mercy.Valkyrie_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Mercy.Devil_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Mercy.IMP_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = Mercy.Winged_Victory_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB14.BackColor = Color.Gold; chB14.Text = Mercy.Witch_SK + " (" + Cost.Legendary + ")";//Halloween 16
                chB15.BackColor = Color.Gold; chB15.Text = Mercy.Combat_Medic_Ziegler_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Mercy.Applause_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Mercy.Caduceus_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Mercy.No_Pulse_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Mercy.Relax_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Mercy.The_best_Medicine_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Mercy.Hustle_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Mercy.Angelic_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Mercy.Carefree_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Mercy.Ready_for_Battle_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Mercy.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Mercy.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Mercy.Mistletoe_VP + " (" + Cost.Rare + ")";//Winter 16
                chB07.BackColor = Color.DeepSkyBlue; chB07.Text = Mercy.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VP07"));
            }
            chBSave = 1;
        }

        private void Moira_Click(object sender, EventArgs e)
        {
            Heroe = "Moira";
            btnHeroeinvisible(Heroe, 10, 5, 3);
            gbAll.Text = Moira.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Moira.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnMoira()
        {
            inisHeroes = new IniStream(appdata + "\\Moira.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p3, p1);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p2);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p3);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Moira.Fiery_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Moira.Royal_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Moira.Selkie_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Moira.Whiskey_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Moira.Ornate_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Moira.Pale_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.Gold; chB07.Text = Moira.Minister_SK + " (" + Cost.Legendary + ")";//Legendary
                chB08.BackColor = Color.Gold; chB08.Text = Moira.Oasis_SK + " (" + Cost.Legendary + ")";
                chB09.BackColor = Color.Gold; chB09.Text = Moira.Glam_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Moira.Moon_SK + " (" + Cost.Legendary + ")";

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p1);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p2);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Moira.A_your_service_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Moira.Come_here_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Moira.Give_and_take_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Moira.How_amusing_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Moira.Waiting_EM + " (" + Cost.Epic + ")";

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p2, p1);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p2);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Moira.Orbs_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Moira.Prim_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Moira.Steepling_VP + " (" + Cost.Rare + ")";

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
            }
            chBSave = 1;
        }

        private void Orisa_Click(object sender, EventArgs e)
        {
            Heroe = "Orisa";
            btnHeroeinvisible(Heroe, 11, 6, 4);
            gbAll.Text = Orisa.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Orisa.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnOrisa()
        {
            inisHeroes = new IniStream(appdata + "\\Orisa.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p3, p1);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p2);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p3);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p4);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p5);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Orisa.Dawn_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Orisa.Plains_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Orisa.Sunrise_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Orisa.Twilight_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Orisa.Camouflage_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Orisa.OR15_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.Gold; chB07.Text = Orisa.Dynastinae_SK + " (" + Cost.Legendary + ")";//Legendary
                chB08.BackColor = Color.Gold; chB08.Text = Orisa.Megasoma_SK + " (" + Cost.Legendary + ")";
                chB09.BackColor = Color.Gold; chB09.Text = Orisa.Carbon_Fiber_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Orisa.Protector_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Orisa.Null_Sector_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Orisa.Cheer_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Orisa.Halt_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Orisa.Kicking_Dirt_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Orisa.Laugh_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Orisa.Sit_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Orisa.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17
                chB07.BackColor = Color.Gold; chB07.Text = Orisa.Puppy_EM + " (" + Cost.LegendaryEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p1);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p2);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Orisa.Confident_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Orisa.Flex_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Orisa.Halt_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Orisa.Pumpkin_Head_VP + " (" + Cost.RareEvent + ")";//Halloween 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
            }
            chBSave = 1;
        }

        private void Pharah_Click(object sender, EventArgs e)
        {
            Heroe = "Pharah";
            btnHeroeinvisible(Heroe, 14, 7, 6);
            gbAll.Text = Pharah.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Pharah.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnPharah()
        {
            inisHeroes = new IniStream(appdata + "\\Pharah.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Pharah.Amethyst_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Pharah.Copper_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Pharah.Emerald_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Pharah.Titanium_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Pharah.Anubis_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Pharah.Jackal_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Pharah.Possessed_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = Pharah.Frostbite_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB09.BackColor = Color.Gold; chB09.Text = Pharah.Mechaqueen_SK + " (" + Cost.Legendary + ")";//Legendary
                chB10.BackColor = Color.Gold; chB10.Text = Pharah.Raptorion_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Pharah.Raindancer_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Pharah.Thunderbird_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = Pharah.Security_Chief_SK + " (" + Lang.OriginGotY + ")";//Origin
                chB14.BackColor = Color.Gold; chB14.Text = Pharah.Bedouin_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Pharah.Cheer_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Pharah.Chuckle_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Pharah.Flourish_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Pharah.Knuckles_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Pharah.Take_a_knee_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Pharah.Flair_EM + " (" + Cost.EpicEvent + ")";//Uprising 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Pharah.Rocket_Guitar_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Pharah.Guardian_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Pharah.Kneeling_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Pharah.Jump_Jet_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Pharah.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Pharah.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Pharah.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Reaper_Click(object sender, EventArgs e)
        {
            Heroe = "Reaper";
            btnHeroeinvisible(Heroe, 15, 7, 6);
            gbAll.Text = Reaper.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Reaper.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnReaper()
        {
            inisHeroes = new IniStream(appdata + "\\Reaper.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p8);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Reaper.Blood_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Reaper.Midnight_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Reaper.Moss_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Reaper.Royal_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Reaper.Desert_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Reaper.Wight_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Reaper.Shiver_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB08.BackColor = Color.Gold; chB08.Text = Reaper.Nevermore_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Reaper.Plague_Doctor_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Reaper.El_Blanco_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Reaper.Mariachi_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Reaper.Blackwatch_Reyes_SK + " (" + Lang.OriginGotY + ")";//Origin
                chB13.BackColor = Color.Gold; chB13.Text = Reaper.Biker_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB14.BackColor = Color.Gold; chB14.Text = Reaper.Dracula_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB15.BackColor = Color.Gold; chB15.Text = Reaper.Pumpkin_SK + " (" + Cost.Legendary + ")";//Halloween 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Reaper.Cackle_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Reaper.Not_Impressed_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Reaper.Shrug_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Reaper.Slice_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Reaper.Slow_Clap_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Reaper.Take_a_knee_EM + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Reaper.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Reaper.Casual_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Reaper.Enigmatic_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Reaper.Menacing_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Reaper.Shrug_EM + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Reaper.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Reaper.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Reinhardt_Click(object sender, EventArgs e)
        {
            Heroe = "Reinhardt";
            btnHeroeinvisible(Heroe, 15, 7, 5);
            gbAll.Text = Reinhardt.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Reinhardt.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnReinhardt()
        {
            inisHeroes = new IniStream(appdata + "\\Reinhardt.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Reinhardt.Brass_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Reinhardt.Cobalt_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Reinhardt.Copper_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Reinhardt.Viridian_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Reinhardt.Bundeswehr_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Reinhardt.Paragon_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Reinhardt.Coldhardt_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = Reinhardt.Lieutenant_Wilhelm_SK + " (" + Cost.EpicEvent + ")";//Uprising 17
                chB09.BackColor = Color.Gold; chB09.Text = Reinhardt.Blackhardt_SK + " (" + Cost.Legendary + ")";//Legendary
                chB10.BackColor = Color.Gold; chB10.Text = Reinhardt.Bloodhardt_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Reinhardt.Lionhardt_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Reinhardt.Stonehardt_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = Reinhardt.Balderich_SK + " (" + Cost.Legendary + ")";
                chB14.BackColor = Color.Gold; chB14.Text = Reinhardt.Greifhardt_SK + " (" + Cost.Legendary + ")";
                chB15.BackColor = Color.Gold; chB15.Text = Reinhardt.Wujing_SK + " (" + Cost.LegendaryEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Reinhardt.Flex_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Reinhardt.Knee_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Reinhardt.Taunt_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Reinhardt.Uproarious_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Reinhardt.Warriors_Salute_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Reinhardt.Punpkin_Smash_EM + " (" + Cost.Epic + ")";//Halloween 16
                chB07.BackColor = Color.DarkViolet; chB07.Text = Reinhardt.Sweethardt_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p2, p1);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p2);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Reinhardt.Confident_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Reinhardt.Flex_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Reinhardt.Legendary_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Reinhardt.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Reinhardt.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
            }
            chBSave = 1;
        }


        private void Roadhog_Click(object sender, EventArgs e)
        {
            Heroe = "Roadhog";
            btnHeroeinvisible(Heroe, 13, 6, 6);
            gbAll.Text = Roadhog.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Roadhog.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnRoadhog()
        {
            inisHeroes = new IniStream(appdata + "\\Roadhog.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Roadhog.Kiwi_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Roadhog.Mud_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Roadhog.Sand_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Roadhog.Thistle_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Roadhog.Pigpen_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Roadhog.Stitched_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Roadhog.Rudolph_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB08.BackColor = Color.Gold; chB08.Text = Roadhog.Islander_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Roadhog.Toa_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Roadhog.Mako_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Roadhog.Sharkbait_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Roadhog.Junkensteins_Monster_SK + " (" + Cost.Legendary + ")";//Halloween 16
                chB14.BackColor = Color.Gold; chB14.Text = Roadhog.Ice_Fisherman_SK + " (" + Cost.LegendaryEvent + ")";//Winter 17
                chB13.BackColor = Color.Gold; chB13.Text = Roadhog.Bajie_SK + " (" + Cost.LegendaryEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Roadhog.Belly_Laugh_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Roadhog.Boo_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Roadhog.Can_Crusher_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Roadhog.Headbanging_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Roadhog.Tuckered_Out_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Roadhog.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Roadhog.Pointing_to_the_sky_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Roadhog.Thumbs_Up_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Roadhog.Tuckered_out_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Roadhog.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Roadhog.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB07.BackColor = Color.DeepSkyBlue; chB07.Text = Roadhog.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 17
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Roadhog.Whats_mine_is_mine_VP + " (" + Cost.RareEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VP07"));
            }
            chBSave = 1;
        }

        private void Soldier_76_Click(object sender, EventArgs e)
        {
            Heroe = "Soldier 76";
            btnHeroeinvisible("Soldier_76", 15, 7, 6);
            gbAll.Text = Soldier_76.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Soldier_76.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnSoldier_76()
        {
            inisHeroes = new IniStream(appdata + "\\Soldier_76.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p7);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p8);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Soldier_76.Jet_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Soldier_76.Olive_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Soldier_76.Russet_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Soldier_76.Smoke_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Soldier_76.Bone_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Soldier_76.Golden_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Soldier_76.Immortal_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.Gold; chB08.Text = Soldier_76.Commando_76_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Soldier_76.Night_Ops_76_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Soldier_76.Daredevil_76_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Soldier_76.Stunt_Rider_76_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Soldier_76.Strike_Commander_Morrison_SK + " (" + Lang.OriginGotY + ")";//Origin
                chB13.BackColor = Color.Gold; chB13.Text = Soldier_76.Grillmaster_76_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB15.BackColor = Color.Gold; chB15.Text = Soldier_76.Alpine_76_SK + " (" + Cost.LegendaryEvent + ")";//Winter 17
                chB14.BackColor = Color.Gold; chB14.Text = Soldier_76.Cyborg_76_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Soldier_76.Amused_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Soldier_76.Fist_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Soldier_76.I_see_you_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Soldier_76.Locked_and_Loaded_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Soldier_76.Take_a_knee_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Soldier_76.Push_Ups_EM + " (" + Cost.EpicEvent + ")";//Uprising 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Soldier_76.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Soldier_76.Fist_Pump_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Soldier_76.Locked_and_Loaded_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Soldier_76.Soldier_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Soldier_76.Golf_Swing_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Soldier_76.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Soldier_76.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Sombra_Click(object sender, EventArgs e)
        {
            Heroe = "Sombra";
            btnHeroeinvisible(Heroe, 12, 6, 6);
            gbAll.Text = Sombra.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Sombra.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnSombra()
        {
            inisHeroes = new IniStream(appdata + "\\Sombra.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Sombra.Cidro_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Sombra.Incendio_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Sombra.Mar_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Sombra.Noche_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Sombra.Glitch_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Sombra.Virus_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Sombra.Peppermint_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB08.BackColor = Color.Gold; chB08.Text = Sombra.Azúcar_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Sombra.Los_Muertos_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Sombra.Augmented_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Sombra.Cyberspace_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Sombra.Tulum_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB13.BackColor = Color.Gold; chB13.Text = Sombra.Rime_SK + " (" + Cost.LegendaryEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Sombra.Amused_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Sombra.Boop_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Sombra.Hold_on_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Sombra.Masterpiece_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Sombra.Sit_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Sombra.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Sombra.Hacked_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Sombra.Kneeling_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Sombra.Rising_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Sombra.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Sombra.Pumpkinette_VP + " (" + Cost.RareEvent + ")";//Halloween 17
                chB07.BackColor = Color.DeepSkyBlue; chB07.Text = Sombra.Toast_VP + " (" + Cost.RareEvent + ")";//Halloween 17
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Sombra.Sparklers_VP + " (" + Cost.RareEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("VP07"));
            }
            chBSave = 1;
        }

        private void Symmetra_Click(object sender, EventArgs e)
        {
            Heroe = "Symmetra";
            btnHeroeinvisible(Heroe, 14, 7, 6);
            gbAll.Text = Symmetra.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Symmetra.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnSymmetra()
        {
            inisHeroes = new IniStream(appdata + "\\Symmetra.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p2, p4);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p1);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p2);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p3);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p4);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p5);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p6);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Symmetra.Cardamom_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Symmetra.Hyacinth_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Symmetra.Saffron_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Symmetra.Technomancer_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Symmetra.Regal_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Symmetra.Utopaea_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Symmetra.Vampire_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.DarkViolet; chB08.Text = Symmetra.Qipao_SK + " (" + Cost.EpicEvent + ")";//Rooster 17
                chB09.BackColor = Color.Gold; chB09.Text = Symmetra.Architech_SK + " (" + Cost.Legendary + ")";//Legendary
                chB10.BackColor = Color.Gold; chB10.Text = Symmetra.Vishkar_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Symmetra.Devi_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Symmetra.Goddess_SK + " (" + Cost.Legendary + ")";
                chB13.BackColor = Color.Gold; chB13.Text = Symmetra.Dragon_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB14.BackColor = Color.Gold; chB14.Text = Symmetra.Oasis_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Symmetra.Clap_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Symmetra.Flow_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Symmetra.Have_a_seat_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Symmetra.Insignificant_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Symmetra.Snicker_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Symmetra.Ribbon_EM + " (" + Cost.Epic + ")";//Summer 16
                chB07.BackColor = Color.DarkViolet; chB07.Text = Symmetra.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Symmetra.Balance_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Symmetra.Creation_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Symmetra.Dance_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Symmetra.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Symmetra.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Symmetra.Light_Reading_VP + " (" + Cost.RareEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }
        //

        private void Torbjörn_Click(object sender, EventArgs e)
        {
            Heroe = "Torbjörn";
            btnHeroeinvisible(Heroe, 15, 7, 6);
            gbAll.Text = Torbjörn.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Torbjörn.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnTorbjörn()
        {
            inisHeroes = new IniStream(appdata + "\\Torbjörn.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p8);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Torbjörn.Blå_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Torbjörn.Citron_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Torbjörn.Grön_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Torbjörn.Plommon_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Torbjörn.Cathode_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Torbjörn.Woodclad_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Torbjörn.Tre_Kronor_SK + " (" + Cost.Epic + ")";//Summer 16
                chB08.BackColor = Color.Gold; chB08.Text = Torbjörn.Chopper_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Torbjörn.Deadlock_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Torbjörn.Barbarossa_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Torbjörn.Blackbeard_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Torbjörn.Viking_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB13.BackColor = Color.Gold; chB13.Text = Torbjörn.Santaclad_SK + " (" + Cost.LegendaryEvent + ")";//Winter 16
                chB14.BackColor = Color.Gold; chB14.Text = Torbjörn.Chief_Engineer_Lindholm_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17
                chB15.BackColor = Color.Gold; chB15.Text = Torbjörn.Ironclad_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Torbjörn.Clicking_heels_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Torbjörn.Fisticuffs_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Torbjörn.Guffaw_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Torbjörn.Overload_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Torbjörn.Taking_a_break_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Torbjörn.Batter_Up_EM + " (" + Cost.EpicEvent + ")";//Halloween 17
                chB07.BackColor = Color.DarkViolet; chB07.Text = Torbjörn.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Torbjörn.Hammer_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Torbjörn.Sitting_pretty_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Torbjörn.Take_Five_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Torbjörn.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Torbjörn.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Torbjörn.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Tracer_Click(object sender, EventArgs e)
        {
            Heroe = "Tracer";
            btnHeroeinvisible(Heroe, 17, 6, 6);
            gbAll.Text = Tracer.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Tracer.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnTracer()
        {
            inisHeroes = new IniStream(appdata + "\\Tracer.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p8);
                chB16.Visible = true; chB16.Location = new Point(gBAllWeited4p3, p9);
                chB17.Visible = true; chB17.Location = new Point(gBAllWeited4p3, p10);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Tracer.Electric_Purple_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Tracer.Hot_Pink_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Tracer.Neon_Green_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Tracer.Royal_Blue_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Tracer.Posh_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Tracer.Sporty_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Tracer.Rose_SK + " (" + Cost.EpicEvent + ")";//Rooster 17
                chB08.BackColor = Color.Gold; chB08.Text = Tracer.Punk_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Tracer.Ultraviolet_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Tracer.Mach_T_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Tracer.T_Racer_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Tracer.Slipstream_SK + " (" + Lang.OriginGotY + ")";//Origin
                chB13.BackColor = Color.Gold; chB13.Text = Tracer.Sprinter_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB14.BackColor = Color.Gold; chB14.Text = Tracer.Track_and_Field_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB15.BackColor = Color.Gold; chB15.Text = Tracer.Jingle_SK + " (" + Cost.LegendaryEvent + ")";//Winter 16
                chB16.BackColor = Color.Gold; chB16.Text = Tracer.Cadet_Oxton_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17
                chB17.BackColor = Color.Gold; chB17.Text = Tracer.Graffiti_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
                chB16.Checked = Convert.ToBoolean(inisHeroes.Read("SK16"));
                chB17.Checked = Convert.ToBoolean(inisHeroes.Read("SK17"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Tracer.Cheer_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Tracer.Finger_guns_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Tracer.Having_a_laugh_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Tracer.Sitting_arround_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Tracer.Spin_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Tracer.Charleston_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Tracer.Over_the_shoulder_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Tracer.Salute_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Tracer.Sitting_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Tracer.Medal_VP + " (" + Cost.RareEvent + ")";//Summer 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Tracer.Pumpkin_VP + " (" + Cost.RareEvent + ")";//Halloween 17
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Tracer.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Widowmaker_Click(object sender, EventArgs e)
        {
            Heroe = "Widowmaker";
            btnHeroeinvisible(Heroe, 14, 6, 5);
            gbAll.Text = Widowmaker.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Widowmaker.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnWidowmaker()
        {
            inisHeroes = new IniStream(appdata + "\\Widowmaker.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Widowmaker.Ciel_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Widowmaker.Nuit_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Widowmaker.Rose_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Widowmaker.Vert_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Widowmaker.Patina_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Widowmaker.Winter_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Widowmaker.Tricolore_SK + " (" + Cost.Epic + ")";//Summer 16
                chB08.BackColor = Color.Gold; chB08.Text = Widowmaker.Odette_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Widowmaker.Odile_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Widowmaker.Comtesse_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Widowmaker.Huntress_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Widowmaker.Noire_SK + " (" + Lang.Prepurchase + ")";//Prepurchase
                chB13.BackColor = Color.Gold; chB13.Text = Widowmaker.Côte_DAzur_SK + " (" + Cost.LegendaryEvent + ")";//Summer 17
                chB14.BackColor = Color.Gold; chB14.Text = Widowmaker.Talon_SK + " (" + Cost.LegendaryEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Widowmaker.A_rest_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Widowmaker.Curtain_Call_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Widowmaker.Delighted_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Widowmaker.Shot_Dead_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Widowmaker.Widows_Kiss_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Widowmaker.Ballet_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Widowmaker.Activating_Visor_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Widowmaker.Gaze_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Widowmaker.Over_the_shoulder_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Widowmaker.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Widowmaker.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Widowmaker.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Winston_Click(object sender, EventArgs e)
        {
            Heroe = "Winston";
            btnHeroeinvisible(Heroe, 13, 7, 6);
            gbAll.Text = Winston.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Winston.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnWinston()
        {
            inisHeroes = new IniStream(appdata + "\\Winston.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Winston.Atmosphere_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Winston.Banana_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Winston.Forest_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Winston.Red_Planet_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Winston.Desert_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Winston.Horizon_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Winston.Blizzcon_2017_SK + " (" + Lang.BlizzCon + ")";//BlizzCon 17
                chB08.BackColor = Color.Gold; chB08.Text = Winston.Frogston_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Winston.Undersea_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Winston.Explorer_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Winston.Safari_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Winston.Yeti_SK + " (" + Cost.LegendaryEvent + ")";//Winter 16
                chB13.BackColor = Color.Gold; chB13.Text = Winston.Wukong_SK + " (" + Cost.LegendaryEvent + ")";//Rooster 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Winston.Laugh_matter_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Winston.Monkey_Buisness_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Winston.Peanut_Butter_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Winston.Roar_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Winston.Sitting_around_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Winston.Shadow_Puppets_EM + " (" + Cost.Epic + ")";//Halloween 16
                chB07.BackColor = Color.DarkViolet; chB07.Text = Winston.Twist_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Winston.Beast_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Winston.Glasses_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Winston.The_Thinker_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Winston.Medal_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Winston.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Winston.Peanut_Butter_VP + " (" + Cost.RareEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Zarya_Click(object sender, EventArgs e)
        {
            Heroe = "Zarya";
            btnHeroeinvisible(Heroe, 15, 7, 5);
            gbAll.Text = Zarya.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Zarya.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnZarya()
        {
            inisHeroes = new IniStream(appdata + "\\Zarya.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);
                chB15.Visible = true; chB15.Location = new Point(gBAllWeited4p3, p8);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Zarya.Brick_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Zarya.Goldenrod_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Zarya.Taiga_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Zarya.Violet_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Zarya.Dawn_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Zarya.Midnight_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Zarya.Frosted_SK + " (" + Cost.EpicEvent + ")";//Winter 16
                chB08.BackColor = Color.Gold; chB08.Text = Zarya.Arctic_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Zarya.Siberian_Front_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Zarya.Cybergoth_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Zarya.Industrial_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Zarya.Champion_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB13.BackColor = Color.Gold; chB13.Text = Zarya.Weightlifter_SK + " (" + Cost.Legendary + ")";//Summer 16
                chB14.BackColor = Color.Gold; chB14.Text = Zarya.Totally_80s_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB15.BackColor = Color.Gold; chB15.Text = Zarya.Cyberian_SK + " (" + Cost.LegendaryEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
                chB15.Checked = Convert.ToBoolean(inisHeroes.Read("SK15"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Zarya.Bring_it_on_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Zarya.Comedy_Gold_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Zarya.Chush_you_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Zarya.Pumping_Iron_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Zarya.Take_a_knee_EM + " (" + Cost.Epic + ")";
                chB06.BackColor = Color.DarkViolet; chB06.Text = Zarya.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17
                chB07.BackColor = Color.Gold; chB07.Text = Zarya.Mystery_Gift_EM + " (" + Cost.LegendaryEvent + ")";//Legendary //Winter 16

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p2);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Zarya.Casual_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Zarya.Check_out_this_gun_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Zarya.Flexing_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Zarya.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Zarya.Toast_VP + " (" + Cost.RareEvent + ")";//Winter 17
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Zarya.This_is_strength_VP + " (" + Cost.RareEvent + ")";//Uprising 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }

        private void Zenyatta_Click(object sender, EventArgs e)
        {
            Heroe = "Zenyatta";
            btnHeroeinvisible(Heroe, 14, 6, 5);
            gbAll.Text = Zenyatta.GetName();
            BackSave = gbAll.Text;
            inisHeroes = new IniStream(appdata + "\\Zenyatta.ini");

            chBSave = 0;
            chB01.Text = "Gold Weapon"; chB01.Visible = true;
            chB01.Location = new Point(gBAllWeited4p1, p2);
            chB01.Checked = Convert.ToBoolean(inisHeroes.Read("GW01"));
            chBSave = 1;
        }

        private void btnZenyatta()
        {
            inisHeroes = new IniStream(appdata + "\\Zenyatta.ini");
            chBSave = 0;

            //Anzeigen, Auslesen und anwenden der chB
            if (BackSave2 == Lang.Skins)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited4p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited4p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited4p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited4p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited4p1, p5);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited4p2, p1);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited4p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited4p2, p3);
                chB08.Visible = true; chB08.Location = new Point(gBAllWeited4p3, p1);
                chB09.Visible = true; chB09.Location = new Point(gBAllWeited4p3, p2);
                chB10.Visible = true; chB10.Location = new Point(gBAllWeited4p3, p3);
                chB11.Visible = true; chB11.Location = new Point(gBAllWeited4p3, p4);
                chB12.Visible = true; chB12.Location = new Point(gBAllWeited4p3, p5);
                chB13.Visible = true; chB13.Location = new Point(gBAllWeited4p3, p6);
                chB14.Visible = true; chB14.Location = new Point(gBAllWeited4p3, p7);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Classic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Zenyatta.Air_SK + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Zenyatta.Earth_SK + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Zenyatta.Leaf_SK + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Zenyatta.Water_SK + " (" + Cost.Rare + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Zenyatta.Ascendant_SK + " (" + Cost.Epic + ")";//Epic
                chB06.BackColor = Color.DarkViolet; chB06.Text = Zenyatta.Harmonious_SK + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Zenyatta.Skullyatta_SK + " (" + Cost.Epic + ")";//Halloween 16
                chB08.BackColor = Color.Gold; chB08.Text = Zenyatta.Djinnyatta_SK + " (" + Cost.Legendary + ")";//Legendary
                chB09.BackColor = Color.Gold; chB09.Text = Zenyatta.Ifrit_SK + " (" + Cost.Legendary + ")";
                chB10.BackColor = Color.Gold; chB10.Text = Zenyatta.Ra_SK + " (" + Cost.Legendary + ")";
                chB11.BackColor = Color.Gold; chB11.Text = Zenyatta.Sunyatta_SK + " (" + Cost.Legendary + ")";
                chB12.BackColor = Color.Gold; chB12.Text = Zenyatta.Cultist_SK + " (" + Cost.LegendaryEvent + ")";//Halloween 17
                chB13.BackColor = Color.Gold; chB13.Text = Zenyatta.Nutcracker_SK + " (" + Cost.LegendaryEvent + ")";//Winter 16
                chB14.BackColor = Color.Gold; chB14.Text = Zenyatta.Sanzang_SK + " (" + Cost.LegendaryEvent + ")";//Rooser 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("SK01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("SK02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("SK03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("SK04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("SK05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("SK06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("SK07"));
                chB08.Checked = Convert.ToBoolean(inisHeroes.Read("SK08"));
                chB09.Checked = Convert.ToBoolean(inisHeroes.Read("SK09"));
                chB10.Checked = Convert.ToBoolean(inisHeroes.Read("SK10"));
                chB11.Checked = Convert.ToBoolean(inisHeroes.Read("SK11"));
                chB12.Checked = Convert.ToBoolean(inisHeroes.Read("SK12"));
                chB13.Checked = Convert.ToBoolean(inisHeroes.Read("SK13"));
                chB14.Checked = Convert.ToBoolean(inisHeroes.Read("SK14"));
            }
            if (BackSave2 == Lang.Emotes)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB07.Visible = true; chB07.Location = new Point(gBAllWeited3p2, p3);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p4);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DarkViolet; chB01.Text = Zenyatta.Focusing_EM + " (" + Cost.Epic + ")";//Epic
                chB02.BackColor = Color.DarkViolet; chB02.Text = Zenyatta.Meditate_EM + " (" + Cost.Epic + ")";
                chB03.BackColor = Color.DarkViolet; chB03.Text = Zenyatta.Round_of_Applause_EM + " (" + Cost.Epic + ")";
                chB04.BackColor = Color.DarkViolet; chB04.Text = Zenyatta.Taunt_EM + " (" + Cost.Epic + ")";
                chB05.BackColor = Color.DarkViolet; chB05.Text = Zenyatta.Tickled_EM + " (" + Cost.Epic + ")";
                chB07.BackColor = Color.DarkViolet; chB07.Text = Zenyatta.Snowflake_EM + " (" + Cost.EpicEvent + ")";//Winter 17
                chB06.BackColor = Color.DarkViolet; chB06.Text = Zenyatta.Dance_EM + " (" + Cost.EpicEvent + ")";//Annyver 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("EM01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("EM02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("EM03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("EM04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("EM05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("EM06"));
                chB07.Checked = Convert.ToBoolean(inisHeroes.Read("EM07"));
            }
            if (BackSave2 == Lang.VictoryPoses)
            {
                chB00.Visible = true; chB00.Location = new Point(gBAllWeited3p1, p1);
                chB01.Visible = true; chB01.Location = new Point(gBAllWeited3p1, p2);
                chB02.Visible = true; chB02.Location = new Point(gBAllWeited3p1, p3);
                chB03.Visible = true; chB03.Location = new Point(gBAllWeited3p1, p4);
                chB04.Visible = true; chB04.Location = new Point(gBAllWeited3p2, p1);
                chB05.Visible = true; chB05.Location = new Point(gBAllWeited3p2, p2);
                chB06.Visible = true; chB06.Location = new Point(gBAllWeited3p2, p3);

                chB00.BackColor = Color.Gainsboro; chB00.Text = Lang.Heroic;//Default
                chB01.BackColor = Color.DeepSkyBlue; chB01.Text = Zenyatta.Balance_VP + " (" + Cost.Rare + ")";//Rare
                chB02.BackColor = Color.DeepSkyBlue; chB02.Text = Zenyatta.Harmony_VP + " (" + Cost.Rare + ")";
                chB03.BackColor = Color.DeepSkyBlue; chB03.Text = Zenyatta.Peace_VP + " (" + Cost.Rare + ")";
                chB04.BackColor = Color.DeepSkyBlue; chB04.Text = Zenyatta.Medals_VP + " (" + Cost.Rare + ")";//Summer 16
                chB05.BackColor = Color.DeepSkyBlue; chB05.Text = Zenyatta.RIP_VP + " (" + Cost.Rare + ")";//Halloween 16
                chB06.BackColor = Color.DeepSkyBlue; chB06.Text = Zenyatta.Toast_VP + " (" + Cost.Rare + ")";//Winter 17

                chB00.Checked = true;
                chB01.Checked = Convert.ToBoolean(inisHeroes.Read("VP01"));
                chB02.Checked = Convert.ToBoolean(inisHeroes.Read("VP02"));
                chB03.Checked = Convert.ToBoolean(inisHeroes.Read("VP03"));
                chB04.Checked = Convert.ToBoolean(inisHeroes.Read("VP04"));
                chB05.Checked = Convert.ToBoolean(inisHeroes.Read("VP05"));
                chB06.Checked = Convert.ToBoolean(inisHeroes.Read("VP06"));
            }
            chBSave = 1;
        }
        //
        #endregion

        private void HeroeRead()
        {

        }

        #region Checkboxen

        private void chB01_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("01", chB01.Checked);
        }

        private void chB02_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("02", chB02.Checked);
        }

        private void chB03_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("03", chB03.Checked);
        }

        private void chB04_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("04", chB04.Checked);
        }

        private void chB05_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("05", chB05.Checked);
        }

        private void chB06_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("06", chB06.Checked);
        }

        private void chB07_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("07", chB07.Checked);
        }

        private void chB08_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("08", chB08.Checked);
        }

        private void chB09_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("09", chB09.Checked);
        }

        private void chB10_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("10", chB10.Checked);
        }

        private void chB11_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("11", chB11.Checked);
        }

        private void chB12_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("12", chB12.Checked);
        }

        private void chB13_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("13", chB13.Checked);
        }

        private void chB14_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("14", chB14.Checked);
        }

        private void chB15_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("15", chB15.Checked);
        }

        private void chB16_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("16", chB16.Checked);
        }

        private void chB17_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("17", chB17.Checked);
        }

        private void chB18_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("18", chB18.Checked);
        }

        private void chB19_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("19", chB19.Checked);
        }

        private void chB20_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("20", chB20.Checked);
        }

        private void chB21_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("21", chB21.Checked);
        }

        private void chB22_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("22", chB22.Checked);
        }

        private void chB23_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("23", chB23.Checked);
        }

        private void chB24_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("24", chB24.Checked);
        }

        private void chB25_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("25", chB25.Checked);
        }

        private void chB26_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("26", chB26.Checked);
        }

        private void chB27_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("27", chB27.Checked);
        }

        private void chB28_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("28", chB28.Checked);
        }

        private void chB29_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("29", chB29.Checked);
        }

        private void chB30_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("30", chB30.Checked);
        }

        private void chB31_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("31", chB31.Checked);
        }

        private void chB32_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("32", chB32.Checked);
        }

        private void chB33_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("33", chB33.Checked);
        }

        private void chB34_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("34", chB34.Checked);
        }

        private void chB35_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("35", chB35.Checked);
        }

        private void chB36_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("36", chB36.Checked);
        }

        private void chB37_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("37", chB37.Checked);
        }

        private void chB38_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("38", chB38.Checked);
        }

        private void chB39_CheckedChanged(object sender, EventArgs e)
        {
            chBChange("39", chB39.Checked);
        }

        private void chB00_CheckedChanged(object sender, EventArgs e)
        {
            if (chBSave == 1)
            {
                MessageBox.Show("Something went wrong.\nPlease create an Issue on Github with the Title 'Error 0' and\n describe, what you have done.", "Error 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Buttons

        private void btn00_Click(object sender, EventArgs e)
        {
            ImageChange(0);
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            ImageChange(1);
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            ImageChange(2);
        }

        private void btn03_Click(object sender, EventArgs e)
        {
            ImageChange(3);
        }

        private void btn04_Click(object sender, EventArgs e)
        {
            ImageChange(4);
        }

        private void btn05_Click(object sender, EventArgs e)
        {
            ImageChange(5);
        }

        private void btn06_Click(object sender, EventArgs e)
        {
            ImageChange(6);
        }

        private void btn07_Click(object sender, EventArgs e)
        {
            ImageChange(7);
        }

        private void btn08_Click(object sender, EventArgs e)
        {
            ImageChange(8);
        }

        private void btn09_Click(object sender, EventArgs e)
        {
            ImageChange(9);
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            ImageChange(10);
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            ImageChange(11);
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            ImageChange(12);
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            ImageChange(13);
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            ImageChange(14);
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            ImageChange(15);
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            ImageChange(16);
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            ImageChange(17);
        }

        #endregion

        private void ImageChange(int buttonnumber)
        {
            ItemImage.ChangeImage(BackSave, BackSave2, buttonnumber);
            ItemImage.Location = new Point((this.Width / 2) - (ItemImage.Width / 2), (this.Height / 2) - (ItemImage.Height / 2) - 19);
            ItemImage.Visible = true;
            lblCloseImage.Visible = true;
            lblCloseImage.Location = ItemImage.Location;
            lblCloseImage.Text = "Close Image by clicking on it";
            ItemImage.BringToFront();
            lblCloseImage.BringToFront();
            ImageChangeHintergrundButtons(false);
        }

        private void chBChange(string Nummer, bool Checkbox)
        {
            //Speichern
            if (chBSave == 1)
            {
                if (BackSave2 == Lang.Skins && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("SK" + Nummer, Checkbox.ToString());
                }
                if (BackSave2 == Lang.Emotes && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("EM" + Nummer, Checkbox.ToString());
                }
                if (BackSave2 == Lang.VictoryPoses && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("VP" + Nummer, Checkbox.ToString());
                }/*
                if (BackSave2 == Lang.VoiceLines && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("VL" + Nummer, Checkbox.ToString());
                }
                if (BackSave2 == Lang.Sprays && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("SP" + Nummer, Checkbox.ToString());
                }
                if (BackSave2 == Lang.HighlightIntros && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("HI" + Nummer, Checkbox.ToString() && chB01.Text != "Gold Weapon");
                }
                if (BackSave2 == Lang.PlayerIcons && Heroe != "PI" && chB01.Text != "Gold Weapon")
                {
                    inisHeroes.Write("PI" + Nummer, Checkbox.ToString());
                }
                if (BackSave2 == Lang.PlayerIcons && Heroe == "PI" && chB01.Text != "Gold Weapon")
                {
                    inisPI.Write(Nummer, Checkbox.ToString());
                }*/
                if (chB01.Text == "Gold Weapon")
                {
                    inisHeroes.Write("GW" + Nummer, Checkbox.ToString());
                }

                TextRemaining(Heroe);
            }
        }

        private void ImageChangeHintergrundButtons(bool b)
        {
            btnBackHero.Visible = b;
            btnSettings.Visible = b;
            gbAll.Visible = b;
            lblKosten.Visible = b;
        }
    }
}
