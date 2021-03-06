﻿using KingOfPirates.Nassau;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingOfPirates.Mappa;
using KingOfPirates.Missioni.Navi;
using KingOfPirates.Missioni.ScontroCarte.Opponenti;
using KingOfPirates.Missioni.ScontroCarte.Carte;

namespace KingOfPirates.GUI.MenuNassau
{
    public partial class Negozio_form : Form
    {
        Negozio negozio = new Negozio();

        private int currentIndex;
        Panel componenteSelezionato;

        public Negozio_form()
        {
            InitializeComponent();
            
            LoadData();
        }

        private void back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gioco.nassauForm.Show();
        }

        private void Negozio_RiscattaTaglie_Button_Click(object sender, EventArgs e)
        {
            negozio.RiscattaTaglie();
            UpdateOutput();
        }

        private void Negozio_AcqBevDet_Button_Click(object sender, EventArgs e)
        {
            negozio.AcquistaBevandaDeterminazione();
            UpdateOutput();
        }

        private void Negozio_AcqRum_Button_Click(object sender, EventArgs e)
        {
            negozio.AcquistaRum();
            UpdateOutput();
        }

        private void Negozio_AcqBevAnt_Button_Click(object sender, EventArgs e)
        {
            negozio.AcquistaAntiubriachezza();
            UpdateOutput();
        }

        private void Negozio_AcqAssLeg_Button_Click(object sender, EventArgs e)
        {
            negozio.AcquistaAssiLegno();
            UpdateOutput();
        }

        private void Negozio_AcqCarte_Button_Click(object sender, EventArgs e)
        {
            Negozio_acqCarte_Panel.Show();

            LoadData();
        }

        private void backToNegozio_Button_Click(object sender, EventArgs e)
        {
            Negozio_acqCarte_Panel.Hide();
        }

        private void Seleziona()
        {
            Negozio_CarteInfo_Img.BackgroundImage = ListaCarte.GetCarta(currentIndex).Immagine;

            Negozio_CarteNome_Label.Text = ListaCarte.GetCarta(currentIndex).Nome;

            if (ListaCarte.GetCarta(currentIndex).Tipo == "attacco")
                Negozio_CarteAtk_Label.Text = "ATK: " + ((CartaBase)(ListaCarte.GetCarta(currentIndex))).Atk;
            else
                Negozio_CarteAtk_Label.Text = "ATK: -";

            if (ListaCarte.GetCarta(currentIndex).Tipo == "attacco")
                Negozio_CarteDef_Label.Text = "DEF: " + ((CartaBase)(ListaCarte.GetCarta(currentIndex))).Def;
            else
                Negozio_CarteDef_Label.Text = "DEF: -";

            if (ListaCarte.GetCarta(currentIndex).Tipo == "attacco")
            {
                if(((CartaBase)(ListaCarte.GetCarta(currentIndex))).Elemento == 'f')
                    Negozio_CarteElemento_Label.Text = "Elemento: FUOCO";
                else if(((CartaBase)(ListaCarte.GetCarta(currentIndex))).Elemento == 'g')
                    Negozio_CarteElemento_Label.Text = "Elemento: GHIACCIO";
                else if(((CartaBase)(ListaCarte.GetCarta(currentIndex))).Elemento == 's')
                    Negozio_CarteElemento_Label.Text = "Elemento: SASSO";
            }
            else
                Negozio_CarteElemento_Label.Text = "Elemento: - carta effetto -";

            Negozio_CarteDescrizione_Label.Text = "Descrizione: " + ListaCarte.GetCarta(currentIndex).Descrizione;
        }

        private void Negozio_CarteAcquista_Button_Click(object sender, EventArgs e)
        {
            negozio.AcquistaCarta(currentIndex);
            componenteSelezionato.Hide();
            UpdateOutput();
        }

        private void LoadData()
        {
            //nascondi tutto
            Negozio_CartePirata1_Button.Hide();
            Negozio_CartePirata2_Button.Hide();
            Negozio_CartePirata3_Button.Hide();
            Negozio_CartePirata4_Button.Hide();
            Negozio_CartePirata5_Button.Hide();
            Negozio_CartePirata6_Button.Hide();
            Negozio_CartePirata7_Button.Hide();
            Negozio_CartePirata8_Button.Hide();
            Negozio_CartePirata9_Button.Hide();
            Negozio_CartePirata10_Button.Hide();
            Negozio_CartePirata11_Button.Hide();
            Negozio_CartePirata12_Button.Hide();
            Negozio_CartePirata13_Button.Hide();
            Negozio_CartePirata14_Button.Hide();
            Negozio_CartePirata15_Button.Hide();
            Negozio_CartePirata16_Button.Hide();
            Negozio_CartePirata17_Button.Hide();
            Negozio_CartePirata18_Button.Hide();
            Negozio_CartePirata19_Button.Hide();
            Negozio_CartePirata20_Button.Hide();

            //
            //Negozio principale
            //

            Negozio_CostoBevDet_Label.Text = (negozio.getPrezziOggetti(0)).ToString() + " $";
            Negozio_CostoRum_Label.Text = (negozio.getPrezziOggetti(1)).ToString() + " $";
            Negozio_CostoBevAnt_Label.Text = (negozio.getPrezziOggetti(2)).ToString() + " $";
            Negozio_CostoAssLeg_Label.Text = (negozio.getPrezziOggetti(3)).ToString() + " $";
            
            //
            //Negozio carte
            //

            //Riga - nome
            Negozio_CartePirata1_Label.Text = ListaCarte.GetCarta(0).Nome;
            Negozio_CartePirata2_Label.Text = ListaCarte.GetCarta(1).Nome;
            Negozio_CartePirata3_Label.Text = ListaCarte.GetCarta(2).Nome;
            Negozio_CartePirata4_Label.Text = ListaCarte.GetCarta(3).Nome;
            Negozio_CartePirata5_Label.Text = ListaCarte.GetCarta(4).Nome;
            Negozio_CartePirata6_Label.Text = ListaCarte.GetCarta(5).Nome;
            Negozio_CartePirata7_Label.Text = ListaCarte.GetCarta(6).Nome;
            Negozio_CartePirata8_Label.Text = ListaCarte.GetCarta(7).Nome;
            Negozio_CartePirata9_Label.Text = ListaCarte.GetCarta(8).Nome;
            Negozio_CartePirata10_Label.Text = ListaCarte.GetCarta(9).Nome;
            Negozio_CartePirata11_Label.Text = ListaCarte.GetCarta(10).Nome;
            Negozio_CartePirata12_Label.Text = ListaCarte.GetCarta(11).Nome;
            Negozio_CartePirata13_Label.Text = ListaCarte.GetCarta(12).Nome;
            Negozio_CartePirata14_Label.Text = ListaCarte.GetCarta(13).Nome;
            Negozio_CartePirata15_Label.Text = ListaCarte.GetCarta(14).Nome;
            Negozio_CartePirata16_Label.Text = ListaCarte.GetCarta(15).Nome;
            Negozio_CartePirata17_Label.Text = ListaCarte.GetCarta(16).Nome;
            Negozio_CartePirata18_Label.Text = ListaCarte.GetCarta(17).Nome;
            Negozio_CartePirata19_Label.Text = ListaCarte.GetCarta(18).Nome;
            Negozio_CartePirata20_Label.Text = ListaCarte.GetCarta(19).Nome;

            //Riga - prezzo
            Negozio_CartePrezzo1_Label.Text = ListaCarte.GetCarta(0).Prezzo.ToString();
            Negozio_CartePrezzo2_Label.Text = ListaCarte.GetCarta(1).Prezzo.ToString();
            Negozio_CartePrezzo3_Label.Text = ListaCarte.GetCarta(2).Prezzo.ToString();
            Negozio_CartePrezzo4_Label.Text = ListaCarte.GetCarta(3).Prezzo.ToString();
            Negozio_CartePrezzo5_Label.Text = ListaCarte.GetCarta(4).Prezzo.ToString();
            Negozio_CartePrezzo6_Label.Text = ListaCarte.GetCarta(5).Prezzo.ToString();
            Negozio_CartePrezzo7_Label.Text = ListaCarte.GetCarta(6).Prezzo.ToString();
            Negozio_CartePrezzo8_Label.Text = ListaCarte.GetCarta(7).Prezzo.ToString();
            Negozio_CartePrezzo9_Label.Text = ListaCarte.GetCarta(8).Prezzo.ToString();
            Negozio_CartePrezzo10_Label.Text = ListaCarte.GetCarta(9).Prezzo.ToString();
            Negozio_CartePrezzo11_Label.Text = ListaCarte.GetCarta(10).Prezzo.ToString();
            Negozio_CartePrezzo12_Label.Text = ListaCarte.GetCarta(11).Prezzo.ToString();
            Negozio_CartePrezzo13_Label.Text = ListaCarte.GetCarta(12).Prezzo.ToString();
            Negozio_CartePrezzo14_Label.Text = ListaCarte.GetCarta(13).Prezzo.ToString();
            Negozio_CartePrezzo15_Label.Text = ListaCarte.GetCarta(14).Prezzo.ToString();
            Negozio_CartePrezzo16_Label.Text = ListaCarte.GetCarta(15).Prezzo.ToString();
            Negozio_CartePrezzo17_Label.Text = ListaCarte.GetCarta(16).Prezzo.ToString();
            Negozio_CartePrezzo18_Label.Text = ListaCarte.GetCarta(17).Prezzo.ToString();
            Negozio_CartePrezzo19_Label.Text = ListaCarte.GetCarta(18).Prezzo.ToString();
            Negozio_CartePrezzo20_Label.Text = ListaCarte.GetCarta(19).Prezzo.ToString();

            //Riga - immagineTipo
            Negozio_CartaPirata1_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata2_Img.BackgroundImage = Properties.Resources.ghiaccio;
            Negozio_CartaPirata3_Img.BackgroundImage = Properties.Resources.Sasso;
            Negozio_CartaPirata4_Img.BackgroundImage = Properties.Resources.Sasso;
            Negozio_CartaPirata5_Img.BackgroundImage = Properties.Resources.ghiaccio;
            Negozio_CartaPirata6_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata7_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata8_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata9_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata10_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata11_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata12_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata13_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata14_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata15_Img.BackgroundImage = Properties.Resources.fuoco;
            Negozio_CartaPirata16_Img.BackgroundImage = Properties.Resources.curaPozione;
            Negozio_CartaPirata17_Img.BackgroundImage = Properties.Resources.curaEstesa;
            Negozio_CartaPirata18_Img.BackgroundImage = Properties.Resources.pow_buff;
            Negozio_CartaPirata19_Img.BackgroundImage = Properties.Resources.depotenziamento;
            Negozio_CartaPirata20_Img.BackgroundImage = Properties.Resources.sangue;

            UpdateOutput();

            
            //visibilità componenti
            if (!ListaCarte.GetCarta(0).GetUtilizzabile())
                Negozio_CartePirata1_Button.Show();
            else
                Negozio_CartePirata1_Button.Hide();

            if (!ListaCarte.GetCarta(1).GetUtilizzabile())
                Negozio_CartePirata2_Button.Show();
            else
                Negozio_CartePirata2_Button.Hide();

            if (!ListaCarte.GetCarta(2).GetUtilizzabile())
                Negozio_CartePirata3_Button.Show();
            else
                Negozio_CartePirata3_Button.Hide();

            if (!ListaCarte.GetCarta(3).GetUtilizzabile())
                Negozio_CartePirata4_Button.Show();
            else
                Negozio_CartePirata4_Button.Hide();

            if (!ListaCarte.GetCarta(4).GetUtilizzabile())
                Negozio_CartePirata5_Button.Show();
            else
                Negozio_CartePirata5_Button.Hide();

            if (!ListaCarte.GetCarta(5).GetUtilizzabile())
                Negozio_CartePirata6_Button.Show();
            else
                Negozio_CartePirata6_Button.Hide();

            if (!ListaCarte.GetCarta(6).GetUtilizzabile())
                Negozio_CartePirata7_Button.Show();
            else
                Negozio_CartePirata7_Button.Hide();

            if (!ListaCarte.GetCarta(7).GetUtilizzabile())
                Negozio_CartePirata8_Button.Show();
            else
                Negozio_CartePirata8_Button.Hide();

            if (!ListaCarte.GetCarta(8).GetUtilizzabile())
                Negozio_CartePirata9_Button.Show();
            else
                Negozio_CartePirata9_Button.Hide();

            if (!ListaCarte.GetCarta(9).GetUtilizzabile())
                Negozio_CartePirata10_Button.Show();
            else
                Negozio_CartePirata10_Button.Hide();

            if (!ListaCarte.GetCarta(10).GetUtilizzabile())
                Negozio_CartePirata11_Button.Show();
            else
                Negozio_CartePirata11_Button.Hide();

            if (!ListaCarte.GetCarta(11).GetUtilizzabile())
                Negozio_CartePirata12_Button.Show();
            else
                Negozio_CartePirata12_Button.Hide();

            if (!ListaCarte.GetCarta(12).GetUtilizzabile())
                Negozio_CartePirata13_Button.Show();
            else
                Negozio_CartePirata13_Button.Hide();

            if (!ListaCarte.GetCarta(13).GetUtilizzabile())
                Negozio_CartePirata14_Button.Show();
            else
                Negozio_CartePirata14_Button.Hide();

            if (!ListaCarte.GetCarta(14).GetUtilizzabile())
                Negozio_CartePirata15_Button.Show();
            else
                Negozio_CartePirata15_Button.Hide();

            if (!ListaCarte.GetCarta(15).GetUtilizzabile())
                Negozio_CartePirata16_Button.Show();
            else
                Negozio_CartePirata16_Button.Hide();

            if (!ListaCarte.GetCarta(16).GetUtilizzabile())
                Negozio_CartePirata17_Button.Show();
            else
                Negozio_CartePirata17_Button.Hide();

            if (!ListaCarte.GetCarta(17).GetUtilizzabile())
                Negozio_CartePirata18_Button.Show();
            else
                Negozio_CartePirata18_Button.Hide();

            if (!ListaCarte.GetCarta(18).GetUtilizzabile())
                Negozio_CartePirata19_Button.Show();
            else
                Negozio_CartePirata19_Button.Hide();

            if (!ListaCarte.GetCarta(19).GetUtilizzabile())
                Negozio_CartePirata20_Button.Show();
            else
                Negozio_CartePirata20_Button.Hide();

        }

        private void UpdateOutput()
        {
            Negozio_Fondi_Label.Text = (Gioco.Dominio.CassaDobloni).ToString() + " $";
            Negozio_CarteFondi_Label.Text = (Gioco.Dominio.CassaDobloni).ToString() + " $";

            Negozio_nBevDet_Label.Text = (Gioco.Giocatore.Inventario.BevandaDeterminazione).ToString();
            Negozio_nRum_Label.Text = (Gioco.Giocatore.Inventario.Rum).ToString();
            Negozio_nBevAnt_Label.Text = (Gioco.Giocatore.Inventario.AntiUbriachezza).ToString();
            Negozio_nAssLeg_Label.Text = (Gioco.Giocatore.Inventario.AssiLegno).ToString();

            Negozio_nTaglieMerc_Label.Text = "Taglie mercantili: " + (Gioco.Dominio.TaglieMercantile).ToString();
            Negozio_nTaglieCara_Label.Text = "Taglie caravelle: " + (Gioco.Dominio.TaglieCaravella).ToString();
            Negozio_nTaglieFreg_Label.Text = "Taglie fregate: " + (Gioco.Dominio.TaglieFregata).ToString();
        }


        //SELEZIONE CARTA - richiamo alla funzione seleziona

        private void Pirata1_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            componenteSelezionato = Negozio_CartePirata1_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata1_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            componenteSelezionato = Negozio_CartePirata1_Button;
            Seleziona();
        }
        
        private void Negozio_CartaPirata1_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            componenteSelezionato = Negozio_CartePirata1_Button;
            Seleziona();
        }
        
        private void Negozio_CartePrezzo1_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 0;
            componenteSelezionato = Negozio_CartePirata1_Button;
            Seleziona();
        }
        
        ///////////////////////////

        private void Pirata2_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            componenteSelezionato = Negozio_CartePirata2_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata2_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            componenteSelezionato = Negozio_CartePirata2_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata2_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            componenteSelezionato = Negozio_CartePirata2_Button;
            Seleziona();
        }
        
        private void Negozio_CartePrezzo2_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 1;
            componenteSelezionato = Negozio_CartePirata2_Button;
            Seleziona();
        }

        ///////////////////////////
        
        private void Pirata3_Click(object sender, EventArgs e)
        {
            currentIndex = 2;
            componenteSelezionato = Negozio_CartePirata3_Button;
            Seleziona();
        }

        private void Negozio_CartePirata3_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 2;
            componenteSelezionato = Negozio_CartePirata3_Button;
            Seleziona();
        }
        
        private void Negozio_CartaPirata3_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 2;
            componenteSelezionato = Negozio_CartePirata3_Button;
            Seleziona();
        }
        
        private void Negozio_CartePrezzo3_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 2;
            componenteSelezionato = Negozio_CartePirata3_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata4_Click(object sender, EventArgs e)
        {
            currentIndex = 3;
            componenteSelezionato = Negozio_CartePirata4_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata4_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 3;
            componenteSelezionato = Negozio_CartePirata4_Button;
            Seleziona();
        }
        
        private void Negozio_CartaPirata4_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 3;
            componenteSelezionato = Negozio_CartePirata4_Button;
            Seleziona();
        }
        
        private void Negozio_CartePrezzo4_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 3;
            componenteSelezionato = Negozio_CartePirata4_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata5_Click(object sender, EventArgs e)
        {
            currentIndex = 4;
            componenteSelezionato = Negozio_CartePirata5_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata5_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 4;
            componenteSelezionato = Negozio_CartePirata5_Button;
            Seleziona();
        }
        
        private void Negozio_CartaPirata5_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 4;
            componenteSelezionato = Negozio_CartePirata5_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo5_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 4;
            componenteSelezionato = Negozio_CartePirata5_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata6_Click(object sender, EventArgs e)
        {
            currentIndex = 5;
            componenteSelezionato = Negozio_CartePirata6_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata6_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 5;
            componenteSelezionato = Negozio_CartePirata6_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata6_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 5;
            componenteSelezionato = Negozio_CartePirata6_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo6_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 5;
            componenteSelezionato = Negozio_CartePirata6_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata7_Click(object sender, EventArgs e)
        {
            currentIndex = 6;
            componenteSelezionato = Negozio_CartePirata7_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata7_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 6;
            componenteSelezionato = Negozio_CartePirata7_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata7_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 6;
            componenteSelezionato = Negozio_CartePirata7_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo7_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 6;
            componenteSelezionato = Negozio_CartePirata7_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata8_Click(object sender, EventArgs e)
        {
            currentIndex = 7;
            componenteSelezionato = Negozio_CartePirata8_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata8_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 7;
            componenteSelezionato = Negozio_CartePirata8_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata8_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 7;
            componenteSelezionato = Negozio_CartePirata8_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo8_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 7;
            componenteSelezionato = Negozio_CartePirata8_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata9_Click(object sender, EventArgs e)
        {
            currentIndex = 8;
            componenteSelezionato = Negozio_CartePirata9_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata9_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 8;
            componenteSelezionato = Negozio_CartePirata9_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata9_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 8;
            componenteSelezionato = Negozio_CartePirata9_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo9_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 8;
            componenteSelezionato = Negozio_CartePirata9_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata10_Click(object sender, EventArgs e)
        {
            currentIndex = 9;
            componenteSelezionato = Negozio_CartePirata10_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata10_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 9;
            componenteSelezionato = Negozio_CartePirata10_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata10_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 9;
            componenteSelezionato = Negozio_CartePirata10_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo10_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 9;
            componenteSelezionato = Negozio_CartePirata10_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata11_Click(object sender, EventArgs e)
        {
            currentIndex = 10;
            componenteSelezionato = Negozio_CartePirata11_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata11_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 10;
            componenteSelezionato = Negozio_CartePirata11_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata11_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 10;
            componenteSelezionato = Negozio_CartePirata11_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo11_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 10;
            componenteSelezionato = Negozio_CartePirata11_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata12_Click(object sender, EventArgs e)
        {
            currentIndex = 11;
            componenteSelezionato = Negozio_CartePirata12_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata12_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 11;
            componenteSelezionato = Negozio_CartePirata12_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata12_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 11;
            componenteSelezionato = Negozio_CartePirata12_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo12_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 11;
            componenteSelezionato = Negozio_CartePirata12_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata13_Click(object sender, EventArgs e)
        {
            currentIndex = 12;
            componenteSelezionato = Negozio_CartePirata13_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata13_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 12;
            componenteSelezionato = Negozio_CartePirata13_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata13_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 12;
            componenteSelezionato = Negozio_CartePirata13_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo13_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 12;
            componenteSelezionato = Negozio_CartePirata13_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata14_Click(object sender, EventArgs e)
        {
            currentIndex = 13;
            componenteSelezionato = Negozio_CartePirata14_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata14_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 13;
            componenteSelezionato = Negozio_CartePirata14_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata14_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 13;
            componenteSelezionato = Negozio_CartePirata14_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo14_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 13;
            componenteSelezionato = Negozio_CartePirata14_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata15_Click(object sender, EventArgs e)
        {
            currentIndex = 14;
            componenteSelezionato = Negozio_CartePirata15_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata15_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 14;
            componenteSelezionato = Negozio_CartePirata15_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata15_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 14;
            componenteSelezionato = Negozio_CartePirata15_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo15_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 14;
            componenteSelezionato = Negozio_CartePirata15_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata16_Click(object sender, EventArgs e)
        {
            currentIndex = 15;
            componenteSelezionato = Negozio_CartePirata16_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata16_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 15;
            componenteSelezionato = Negozio_CartePirata16_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata16_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 15;
            componenteSelezionato = Negozio_CartePirata16_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo16_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 15;
            componenteSelezionato = Negozio_CartePirata16_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata17_Click(object sender, EventArgs e)
        {
            currentIndex = 16;
            componenteSelezionato = Negozio_CartePirata17_Button;
            Seleziona();
        }

        private void Negozio_CartePirata17_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 16;
            componenteSelezionato = Negozio_CartePirata17_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata17_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 16;
            componenteSelezionato = Negozio_CartePirata17_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo17_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 16;
            componenteSelezionato = Negozio_CartePirata17_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata18_Click(object sender, EventArgs e)
        {
            currentIndex = 17;
            componenteSelezionato = Negozio_CartePirata18_Button;
            Seleziona();
        }

        private void Negozio_CartePirata18_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 17;
            componenteSelezionato = Negozio_CartePirata18_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata18_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 17;
            componenteSelezionato = Negozio_CartePirata18_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo18_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 17;
            componenteSelezionato = Negozio_CartePirata18_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata19_Click(object sender, EventArgs e)
        {
            currentIndex = 18;
            componenteSelezionato = Negozio_CartePirata19_Button;
            Seleziona();
        }
        private void Negozio_CartePirata19_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 18;
            componenteSelezionato = Negozio_CartePirata19_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata19_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 18;
            componenteSelezionato = Negozio_CartePirata19_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo19_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 18;
            componenteSelezionato = Negozio_CartePirata19_Button;
            Seleziona();
        }

        ///////////////////////////

        private void Pirata20_Click(object sender, EventArgs e)
        {
            currentIndex = 19;
            componenteSelezionato = Negozio_CartePirata20_Button;
            Seleziona();
        }
        
        private void Negozio_CartePirata20_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 19;
            componenteSelezionato = Negozio_CartePirata20_Button;
            Seleziona();
        }

        private void Negozio_CartaPirata20_Img_Click(object sender, EventArgs e)
        {
            currentIndex = 19;
            componenteSelezionato = Negozio_CartePirata20_Button;
            Seleziona();
        }

        private void Negozio_CartePrezzo20_Label_Click(object sender, EventArgs e)
        {
            currentIndex = 19;
            componenteSelezionato = Negozio_CartePirata20_Button;
            Seleziona();
        } 
    }
}
