﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KingOfPirates.GUI.MenuNassau;

namespace KingOfPirates.GUI.MenuPrincipale
{
    /// <summary>
    /// Menu principale dell'app
    /// </summary>
    public partial class StartMenu : Form
    {
        private MenuNassau.Nassau_form NassauForm { get; set; }
        /// <summary>
        /// Inizializza il form di Nassau
        /// </summary>
        public StartMenu()
        {
            InitializeComponent();
            NassauForm = new Nassau_form();
        }

        private void Nassau_button_Click(object sender, EventArgs e)
        {
            Gioco.nassauForm.Show();
            this.Hide();
        }

        private void Missioni_button_Click(object sender, EventArgs e)
        {
            Gioco.MissioneSelezionata.StartMissione();
            this.Hide();
        }

        private void ScontroCarte_button_Click(object sender, EventArgs e)
        {
            Gioco.scontroCarte.Show();
            this.Hide();
        }

        private void StartMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Gioco.End();
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            Gioco.nassauForm.Show();
            this.Hide();
        }

        private void Crediti_button_Click(object sender, EventArgs e)
        {
            new CreditiForm().Show();
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Gioco.End();
        }
    }
}
