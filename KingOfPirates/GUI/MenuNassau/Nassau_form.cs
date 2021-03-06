﻿using System;
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

namespace KingOfPirates.GUI.MenuNassau
{
    public partial class Nassau_form : Form
    {
        private Negozio_form negozio;
        private Locanda_form locanda;
        private Porto_form porto;

        private Bitmap img = Properties.Resources.prova;                                    //immagine prova

        private GestioneDominio gestoreDomino = new GestioneDominio();                      //da spostare nel 'main' per renderlo utilizzabile anche dalla missione
        private NaveGiocatore naveGiocatore;                                                //da spostare nel 'main' per renderlo utilizzabile anche dalla missione
        private ListaCarte listaCarte;

        public Nassau_form()
        {
            //naveGiocatore = new NaveGiocatore("MortadellaBella", img);                      //da spostare nel 'main' per renderlo utilizzabile anche dalla missione
            gestoreDomino.CassaDobloni = 100;   //=
            gestoreDomino.TaglieCaravella = 2;  //=
            gestoreDomino.TaglieMercantile = 3; //=

            InitializeComponent();
            negozio = new Negozio_form();
            locanda = new Locanda_form();
            porto = new Porto_form();
        }
        
        private void NegozioImgButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            negozio.Show();
        }

        private void LocandaImgButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            locanda.Show();
        }

        private void PortoImgButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            porto.Show();
        }

        private void Nassau_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Gioco.startMenu.Show();
        }


        public Locanda_form GetLocanda_Form() { return locanda; }
    }
}
