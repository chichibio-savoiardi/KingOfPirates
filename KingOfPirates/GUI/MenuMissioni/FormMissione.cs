﻿using System;
using System.Drawing;
using System.Windows.Forms;
using KingOfPirates.Missioni;
using KingOfPirates.Missioni.Roba;
using KingOfPirates.Properties;

/* L'Interfaccia grafica e' stata fatta a mano
 * La matrice e' stata pensata come piano cartesiano (x e y invertiti)
 * Corregerla richiede riscrivere la classe, che non ho intenzione di fare
 */

namespace KingOfPirates.GUI.MenuMissioni
{
    /// <summary>
    /// Form che rappresenta la griglia grafica della missione, fatto a mano.
    /// </summary>
    public partial class FormMissione : Form
    {
        internal Missione missione;
        internal Image temp;

        /// <summary>
        /// Costruttore, inizializza i componenti grafici.
        /// </summary>
        /// <param name="missione">Per manipolare la missione nel Form.</param>
        public FormMissione(Missione missione)
        {
            this.missione = missione;
            InitializeComponent(19, 12);

            //Gioco.Giocatore.Loc.X = missione.PosNave.X; Gioco.Giocatore.Loc.Y = missione.PosNave.Y;
            temp = Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage;

            //stampa del giocatore
            //cambia immagine se è sopra una isola
            if (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y + 1] == 1)
                Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage = Resources.omino;
            else
                Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage =
                    Gioco.Giocatore.Immagine;

            //mostra nemici a schermo
            foreach (var n in missione.Nemici) Griglia_pictureBox[n.Loc.X, n.Loc.Y].BackgroundImage = n.Immagine;

            UpdateComponenti();
        }

        private void Update(Direzione dir)
        {
            Gioco.Giocatore.Movimento(missione, dir);

            //Segnala che l'enegia è finità
            if (Gioco.Giocatore.Stats.Pa <= 0)
            {
                EnergiaNave_label.ForeColor = Color.Red;

                Sopra_button.ForeColor = Color.LightCoral;
                Sotto_button.ForeColor = Color.LightCoral;
                Destra_button.ForeColor = Color.LightCoral;
                Sinistra_button.ForeColor = Color.LightCoral;
            }
            else
            {
                EnergiaNave_label.ForeColor = Color.Black;
                missione.Ranking.IncTurni(); //aumenta il conteggio per il ranking

                //riporta tutti i label al colore nero
                Ubriachezza_label.ForeColor = Color.Black;
                Determinazione_label.ForeColor = Color.Black;
                VitaNave_label.ForeColor = Color.Black;
                Rubini_label.ForeColor = Color.Black;
            }

            //puoi scavare solo con abbastanza determinazione
            if (Gioco.Giocatore.Determinazione <= 0)
                Scavo_button.ForeColor = Color.Red;
            else
                Scavo_button.ForeColor = Color.Black;

            //controlla vita nemici
            foreach (var n in missione.Nemici)
                n.Affonda(missione);// controllo automatico della vita in Affonda

            //abbordaggio
            foreach (var n in missione.Nemici)
                if (Gioco.Giocatore.Loc.IsEqualTo(n.Loc) && !n.IsGameOver)
                {
                    MessageBox.Show("Hai abbordato una nave pirata!");
                    Gioco.Giocatore.Abborda(n);
                }


            //bandiera (fine missione)
            if (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y] == 3)
            {
                //TEMP
                MessageBox.Show("Hai completato la missione!");

                //conteggio delle navi affondate
                foreach (var n in missione.Nemici)
                    if (n.IsGameOver)
                        missione.Ranking.IncNaviAffondate();

                missione.Fine.Show();
                Hide();
            }

            UpdateComponenti();
        }

        internal void UpdateComponenti()
        {
            void CercaNemico()
            {
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        foreach (var n in missione.Nemici)
                        {
                            var tempLoc = new Loc2D(Gioco.Giocatore.Loc.X + i, Gioco.Giocatore.Loc.Y + j);
                            if (tempLoc.IsEqualTo(n.Loc) && !n.IsGameOver)
                            {
                                Attacca_button.Enabled = true;
                                Attacca_button.Show();
                                Attacca_button.Text = "Attacca: " + n.Nome + "\nHP: " + n.Stats.Hp + "/" + n.Stats.HpMax;
                                return;
                            }
                            else
                            {
                                Attacca_button.Hide();
                            }
                        }
                    }
                }
            }

            if (Gioco.Giocatore.Stats.Pa > 0)// controllo attacco
            {
                CercaNemico();
            }
            else
            {
                Attacca_button.Text = "Attacca:\nNon hai energia";
                Attacca_button.Enabled = false;
            }


            // Controllo per scavare
            if (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y] == 1)
                Scavo_button.Show();
            else
                Scavo_button.Hide();

            //aggiorno il label ubriachezza
            AntiUbriachezza_label.Text = "AntiUbriachezza rimasti: " + Gioco.Giocatore.Inventario.AntiUbriachezza;
            Ubriachezza_label.Text =
                "Ubriachezza: " + Gioco.Giocatore.Ubriachezza + "/" + Gioco.Giocatore.UbriachezzaMax;
            //aggiorno il label determinazione
            BevandaDet_label.Text = "Bevande Det Rimaste: " + Gioco.Giocatore.Inventario.BevandaDeterminazione;
            Determinazione_label.Text = "Determinazione: " + Gioco.Giocatore.Determinazione + "/" +
                                        Gioco.Giocatore.DeterminazioneMax;
            //aggiorno label assi legno
            AssLeg_label.Text = "Assi rimaste: " + Gioco.Giocatore.Inventario.AssiLegno;
            //aggiorno label rum
            Rum_label.Text = "Rum rimasto: " + Gioco.Giocatore.Inventario.Rum;
            //aggiorna energia_label
            EnergiaNave_label.Text = "Punti azione: " + Gioco.Giocatore.Stats.Pa + "/" + Gioco.Giocatore.Stats.PaMax;
            // aggiorna label vita
            VitaNave_label.Text = "Punti Vita: " + Gioco.Giocatore.Stats.Hp + "/" + Gioco.Giocatore.Stats.HpMax;
        }


        private void Sopra_button_Click(object sender, EventArgs e)
        {
            Update(Direzione.SOPRA);
        }

        private void Sotto_button_Click(object sender, EventArgs e)
        {
            Update(Direzione.SOTTO);
        }

        private void Sinistra_button_Click(object sender, EventArgs e)
        {
            Update(Direzione.SINISTRA);
        }

        private void Destra_button_Click(object sender, EventArgs e)
        {
            Update(Direzione.DESTRA);
        }

        private void Azione_button_Click(object sender, EventArgs e)
        {
            Gioco.Giocatore.Stats.Pa = Gioco.Giocatore.Stats.PaMax;
            EnergiaNave_label.Text =
                "Punti azione: " + Gioco.Giocatore.Stats.Pa + "/" +
                Gioco.Giocatore.Stats.PaMax; //aggiorna energia_label

            //riporta tutti i label al colore nero
            EnergiaNave_label.ForeColor = Color.Black;
            Ubriachezza_label.ForeColor = Color.Black;
            Determinazione_label.ForeColor = Color.Black;
            VitaNave_label.ForeColor = Color.Black;
            Rubini_label.ForeColor = Color.Black;

            missione.TurnoNemico();

            //GameOver
            if (Gioco.Giocatore.Stats.Hp <= 0)
            {
                missione.Ranking.IncGameOver(); //viene contato come gameover

                MessageBox.Show("Sei morto! Riparti dall'ultimo check-point.");

                //cambia vecchia posizione
                switch (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y])
                {
                    case 0:
                        Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage = Resources.mare;
                        break;
                    case 1:
                        Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage = Resources.isola1;
                        break;
                    case -1:
                        Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage = Resources.cross;
                        break;
                }

                Gioco.Giocatore.Restart();

                //nuova posizione
                Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage =
                       Resources.nave_pirata;

                //nuovo temp
                switch (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y])
                {
                    case 0:
                        missione.Mappa.temp = Resources.mare;
                        break;
                    case 1:
                        missione.Mappa.temp = Resources.isola1;
                        break;
                    case -1:
                        missione.Mappa.temp = Resources.cross;
                        break;
                }

            }

            UpdateComponenti();

            //VitaNave_label.ForeColor = Color.Red;

            Sopra_button.ForeColor = Color.Black;
            Sotto_button.ForeColor = Color.Black;
            Destra_button.ForeColor = Color.Black;
            Sinistra_button.ForeColor = Color.Black;

            //abbordaggio
            foreach (var n in missione.Nemici)
            {
                if (Gioco.Giocatore.Loc.IsEqualTo(n.Loc) && !n.IsGameOver)
                {
                    MessageBox.Show("Il nemico ti ha abbordato!");
                    Gioco.Giocatore.Abborda(n);
                    n.IsGameOver = true;
                }
            }
        }

        private void Rum_button_Click(object sender, EventArgs e)
        {
            if (Gioco.Giocatore.Inventario.Rum > 0)
            {
                Gioco.Giocatore.Inventario.DecRum(); //consumi una unità di rum

                Gioco.Giocatore.IncUbriachezza(1); //aumenta l'ubriachezza

                Gioco.Giocatore.IncDeterminazione(5); //aumenta la determinazione

                //aggiorno label
                Rum_label.Text = "Rum rimasto: " + Gioco.Giocatore.Inventario.Rum;
                Ubriachezza_label.Text =
                    "Ubriachezza: " + Gioco.Giocatore.Ubriachezza + "/" + Gioco.Giocatore.UbriachezzaMax;
                Determinazione_label.Text = "Determinazione: " + Gioco.Giocatore.Determinazione + "/" +
                                            Gioco.Giocatore.DeterminazioneMax;
                UpdateComponenti();

                //cambia i colori
                Ubriachezza_label.ForeColor = Color.Red;
                Determinazione_label.ForeColor = Color.Green;

                //Se è l'ultimo rum
                if (Gioco.Giocatore.Inventario.Rum == 0)
                    Rum_button.ForeColor = Color.Red;
            }
        }

        private void AssLeg_button_Click(object sender, EventArgs e)
        {
            if (Gioco.Giocatore.Inventario.AssiLegno > 0)
            {
                Gioco.Giocatore.Inventario.DecAssiLegno(); //consumi un'asse di legno

                Gioco.Giocatore.IncPuntiVita(3); //aumenta punti vita

                //aggiorno label
                AssLeg_label.Text = "Assi rimaste: " + Gioco.Giocatore.Inventario.AssiLegno;
                VitaNave_label.Text = "Punti Vita: " + Gioco.Giocatore.Stats.Hp + "/" + Gioco.Giocatore.Stats.HpMax;


                UpdateComponenti();
                //cambia colori
                VitaNave_label.ForeColor = Color.Green;

                //Se è l'utima asse di legno
                if (Gioco.Giocatore.Inventario.AssiLegno == 0)
                    AssLeg_button.ForeColor = Color.Red;
            }
        }

        private void BevandaDet_button_Click(object sender, EventArgs e)
        {
            if (Gioco.Giocatore.Inventario.BevandaDeterminazione > 0)
            {
                Gioco.Giocatore.Inventario.DecBevandaDeterminazione(); //consumi una bevanda della determinazione

                Gioco.Giocatore.IncDeterminazione(2); //aumenta determinazione
                //aggiorno il label
                BevandaDet_label.Text = "Bevande Det Rimaste: " + Gioco.Giocatore.Inventario.BevandaDeterminazione;
                Determinazione_label.Text = "Determinazione: " + Gioco.Giocatore.Determinazione + "/" +
                                            Gioco.Giocatore.DeterminazioneMax;


                Gioco.Giocatore.IncDeterminazione(2); //aumenta determinazione

                //cambia colori
                Determinazione_label.ForeColor = Color.Green;

                if (Gioco.Giocatore.Determinazione > 0)
                    Scavo_button.ForeColor = Color.Black;

                //Se e' l'utima bevandaDet
                if (Gioco.Giocatore.Inventario.BevandaDeterminazione == 0)
                    BevandaDet_button.ForeColor = Color.Red;
            }

            UpdateComponenti();
        }

        private void AntiUbriachezza_button_Click(object sender, EventArgs e)
        {
            if (Gioco.Giocatore.Inventario.AntiUbriachezza > 0)
            {
                Gioco.Giocatore.Inventario.DecAntiUbriachezza(); //consumi una bevanda anti ubriachezza
                Gioco.Giocatore.DecUbriachezza(2); //diminuisce l'ubriachezza

                //aggiorno il label
                AntiUbriachezza_label.Text = "AntiUbriachezza rimasti: " + Gioco.Giocatore.Inventario.AntiUbriachezza;
                Ubriachezza_label.Text =
                    "Ubriachezza: " + Gioco.Giocatore.Ubriachezza + "/" + Gioco.Giocatore.UbriachezzaMax;

                UpdateComponenti();
                //cambia colori
                Ubriachezza_label.ForeColor = Color.Green;

                //Se è l'utima anti ubriachezza
                if (Gioco.Giocatore.Inventario.AntiUbriachezza == 0)
                    AntiUbriachezza_button.ForeColor = Color.Red;
            }
        }

        private void Scavo_button_Click(object sender, EventArgs e)
        {
            if (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y] != -1)
                //Puoi scavare solo se hai abbastanza determinazione
                if (Gioco.Giocatore.Determinazione > 0)
                {
                    //riporto i label ai colori normali
                    Ubriachezza_label.ForeColor = Color.Black;
                    Determinazione_label.ForeColor = Color.Black;
                    VitaNave_label.ForeColor = Color.Black;

                    Gioco.Giocatore.DecDeterminazione(3);
                    //aggiorna label
                    Determinazione_label.Text = "Determinazione: " + Gioco.Giocatore.Determinazione + "/" +
                                                Gioco.Giocatore.DeterminazioneMax;
                    //cambia colore
                    Determinazione_label.ForeColor = Color.Red;


                    var rand = new Random();

                    var rng = rand.Next() * 100;

                    if (rng < 70)
                    {
                        temp = Resources.cross; //sostituisco la texure sabbia con quella scavo
                    }
                    else
                    {
                        temp = Resources.ruby; //sostituisco la texure sabbia con rubino
                        Gioco.Dominio.CassaRubini++; //ottieni un rubino

                        missione.Ranking.IncRubini(); //aumenta il conteggio per il ranking

                        //aggiorna label
                        Rubini_label.Text = "Rubini: " + Gioco.Dominio.CassaRubini;
                        //cambia colore
                        Rubini_label.ForeColor = Color.Green;
                    }

                    //uso la matrice di inizializzazione per verificare se le celle sono già state scavate
                    missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y] = -1;
                    Scavo_button.Hide(); //la componente non serve più quindi la si nasconde
                }

            UpdateComponenti();
        }

        private void Attacca_button_Click(object sender, EventArgs e)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    foreach (var n in missione.Nemici)
                    {
                        var pLoc = new Loc2D(Gioco.Giocatore.Loc.X + i, Gioco.Giocatore.Loc.Y + j);
                        if (pLoc.IsEqualTo(n.Loc) && !n.IsGameOver)
                        {
                            Gioco.Giocatore.Attacca(missione, n);
                            Gioco.Giocatore.Stats.Pa = 0;

                            //affonda se la vita è pari o inferiore a 0
                            n.Affonda(missione);

                            if(n.IsGameOver)
                            {
                                Attacca_button.Hide();
                            }
                            //return;
                            break;
                        }
                    }
                }
            }

            UpdateComponenti();

            //modifica colori perchè è finita l'energia
            EnergiaNave_label.Text =
            "Punti azione: " + Gioco.Giocatore.Stats.Pa + "/" +
             Gioco.Giocatore.Stats.PaMax; //aggiorna energia_label

            EnergiaNave_label.ForeColor = Color.Red;


            Sopra_button.ForeColor = Color.LightCoral;
            Sotto_button.ForeColor = Color.LightCoral;
            Destra_button.ForeColor = Color.LightCoral;
            Sinistra_button.ForeColor = Color.LightCoral;

            //gli attacchi contano come turni
            missione.Ranking.IncTurni(); 


        }

        private void MenuMissioni_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show("Finisci la missione");
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
                if (Gioco.Giocatore.GiocatoreCarte.IsGameOver)
                {
                    Gioco.Giocatore.Restart();
                    missione.TurnoNemico(); //faccio muovere i nemici per mettere apposto le celle

                    missione.Ranking.IncGameOver(); //aumenta il conteggio dei tuoi game over

                    Gioco.Giocatore.Stats.Pa = Gioco.Giocatore.Stats.PaMax;
                    EnergiaNave_label.Text =
                        "Punti azione: " + Gioco.Giocatore.Stats.Pa + "/" +
                        Gioco.Giocatore.Stats.PaMax; //aggiorna energia_label

                    Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage =
                        Resources.nave_pirata;

                    switch (missione.Griglia_numerica.Mat[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y])
                    {
                        case 0:
                            missione.Mappa.temp = Resources.mare;
                            break;
                        case 1:
                            missione.Mappa.temp = Resources.isola1;
                            break;
                        case -1:
                            missione.Mappa.temp = Resources.cross;
                            break;
                    }
                }

            foreach (var n in missione.Nemici)
                n.Affonda(missione);// controllo automatico della vita in Affonda

            //se la nave nemico e quella giocatore sono sovrapposte
            //la giocatore viene ripristinata
            Griglia_pictureBox[Gioco.Giocatore.Loc.X, Gioco.Giocatore.Loc.Y].BackgroundImage =
                        Resources.nave_pirata;

            Attacca_button.Hide();
        }
    }
}