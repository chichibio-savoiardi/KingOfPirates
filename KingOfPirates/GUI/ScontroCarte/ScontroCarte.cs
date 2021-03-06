﻿using KingOfPirates.Missioni.ScontroCarte.Carte;
using KingOfPirates.Missioni.ScontroCarte.Carte.CarteEffetto;
using KingOfPirates.Missioni.ScontroCarte.Opponenti;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace KingOfPirates.GUI.ScontroCarte
{
    /// <summary>
    /// Componente grafica dello scontro a carte.
    /// </summary>
    public partial class ScontroCarte : Form
    {

        //due sfindanti dello scontro a carte
        Player_carte player;
        //Nemico_carte nemico;
        Nemico_carte nemico;

        int cartaSelezionata;

        bool tuoTurno;

        //Componenti grafiche
        PictureBox[] img_carta;
        Label[] nomeCarta;
        Label[] det;
        Label[] att;
        Label[] def;
        PictureBox[] elem;

        SoundPlayer musicBox; //FIXME
        bool isPlaying;

        /// <summary>
        /// Costruttore semplice
        /// </summary>
        /// <param name="nemico_">Bersaglio con cui iniziare lo scontro.</param>
        public ScontroCarte(Nemico_carte nemico_)
        {
            InitializeComponent();
            player = Gioco.Giocatore.GiocatoreCarte;
            nemico = nemico_;
        }

        private void OnLoad(object sender, EventArgs e)
        {

            musicBox = new SoundPlayer(Properties.Resources.Rude_Buster_HQ); //il volume non è regolabile
            musicBox.PlayLooping();
            isPlaying = true;

            cartaSelezionata = -1;
            tuoTurno = true; //inizi sempre tu 

            //display grafico degli sfindanti
            img_avversario.Image = nemico.Img;
            label_avversario.Text = nemico.Nome;
            vita_avversario.Text = "HP: " + nemico.CurHp + "/" + nemico.MaxHp;


            img_giocatore.Image = player.Img;
            label_giocatore.Text = player.Nome;
            vita_giocatore.Text = "HP: " + player.CurHp + "/" + player.MaxHp;

            //Componenti grafiche
            img_carta = new PictureBox[4];
            img_carta[0] = img_carta1;
            img_carta[1] = img_carta2;
            img_carta[2] = img_carta3;
            img_carta[3] = img_carta4;

            nomeCarta = new Label[4];
            nomeCarta[0] = nomeCarta1;
            nomeCarta[1] = nomeCarta2;
            nomeCarta[2] = nomeCarta3;
            nomeCarta[3] = nomeCarta4;

            det = new Label[4];
            det[0] = det1;
            det[1] = det2;
            det[2] = det3;
            det[3] = det4;

            att = new Label[4];
            att[0] = att1;
            att[1] = att2;
            att[2] = att3;
            att[3] = att4;

            def = new Label[4];
            def[0] = def1;
            def[1] = def2;
            def[2] = def3;
            def[3] = def4;

            elem = new PictureBox[4];
            elem[0] = elem1;
            elem[1] = elem2;
            elem[2] = elem3;
            elem[3] = elem4;

            //Prima mano
            for (int i = 0; i < player.CarteInMano.Length; i++)
            {
                player.CarteInMano[i].Visualizza(img_carta[i], nomeCarta[i], det[i], att[i], def[i], elem[i]);
                if (player.CarteInMano[i].Tipo != "attacco")
                {
                    att[i].Hide();
                    def[i].Hide();
                    elem[i].Hide();
                }
            }

        }

        private void ScegliCarta(int indice)
        {
            if (cartaSelezionata == -1) //Se nessuna carta è stata selezionata puoi interagire
            {
                player.CarteInMano[indice].Nascondi(img_carta[indice], nomeCarta[indice], det[indice], att[indice], def[indice], elem[indice]);
                cartaSelezionata = indice;

                //Mostra carta selezionata
                player.CarteInMano[indice].Visualizza(img_carta0, nomeCarta0, det0, att0, def0, elem0);

                if (tuoTurno)
                {
                    def0.BackColor = Color.LightGray;
                    att0.BackColor = Color.LightBlue;
                }
                else
                {
                    def0.BackColor = Color.LightBlue;
                    att0.BackColor = Color.LightGray;
                }
                elem0.BackColor = Color.LightBlue;

                det0.BackColor = Color.LightGoldenrodYellow;

                //Mostra bottone attacco e nascondi
                bt_attacco.Show();
                bt_nascondi.Show();

                //Buff a livello grafico
                if (player.BuffApplicato)
                {
                    att0.Text += "+" + player.ValBuff;
                    def0.Text += "+" + player.ValBuff;

                    att0.ForeColor = Color.BlueViolet;
                    def0.ForeColor = Color.BlueViolet;
                }
                else
                {
                    att0.ForeColor = Color.Black;
                    def0.ForeColor = Color.Black;
                }

            }
        }

        private int Scontro(CartaBase attaccante, CartaBase difensore, PictureBox elemAtt, PictureBox elemDif, Giocatore_carte_base vittima, Label vita_vittima)
        {

            //Controlla gli elementi

            //fuoco, sasso, ghiaccio
            //fuoco - sasso (fuoco)
            //ghiaccio - sasso (sasso)
            //fuoco - ghiaccio (ghiaccio)

            bool vittoria = attaccante.Elemento == 'f' && difensore.Elemento == 's' ||
                              attaccante.Elemento == 's' && difensore.Elemento == 'g' ||
                              attaccante.Elemento == 'g' && difensore.Elemento == 'f';

            int plus = 0;
            if (vittoria) //vittoria elementale
            {
                plus = 1;
                elemAtt.BackColor = Color.LightGreen;
                elemDif.BackColor = Color.LightCoral;
            }
            else if (attaccante.Elemento == difensore.Elemento) //parità
            {
                elemAtt.BackColor = Color.Bisque;
                elemDif.BackColor = Color.Bisque;
            }
            else //sconfitta elementale
            {
                plus = -1;
                elemAtt.BackColor = Color.LightCoral;
                elemDif.BackColor = Color.LightGreen;
            }

            //Per ora la determinazione non conta
            int dmg = attaccante.Atk - difensore.Def;
            dmg += plus;

            if (dmg < 0)
                dmg = 0;

            vittima.LessHp(dmg);

            //Output vita

            vita_vittima.Text = "HP: " + vittima.CurHp + "/" + vittima.MaxHp;
            vita_vittima.ForeColor = Color.Red;

            return dmg;

        }

        private void img_carta1_Click(object sender, EventArgs e)
        {
            ScegliCarta(0);
        }

        private void img_carta2_Click(object sender, EventArgs e)
        {
            ScegliCarta(1);
        }

        private void img_carta3_Click(object sender, EventArgs e)
        {
            ScegliCarta(2);
        }

        private void img_carta4_Click(object sender, EventArgs e)
        {
            ScegliCarta(3);
        }

        private void bt_attacco_Click(object sender, EventArgs e)
        {
            bt_attacco.Hide();
            bt_nascondi.Hide();

            bt_successivo.Show();

            string tipo = player.CarteInMano[cartaSelezionata].Tipo;

            if (tipo == "attacco")
            {
                CartaBase cartaTua = (CartaBase)(player.CarteInMano[cartaSelezionata]);
                cartaTua.SetBuff(player.ValBuff);

                cartaTua.UsaCarta(player);

                if (tuoTurno)
                {
                    //Il nemico sceglie una carta
                    nemico.ScegliCarta();

                    CartaBase cartaNemico = (CartaBase)(nemico.CartaUsata);

                    cartaNemico.Visualizza(img_cartaA, nomeCartaA, detA, attA, defA, elemA);

                    detA.BackColor = Color.LightGoldenrodYellow;

                    defA.BackColor = Color.LightBlue;
                    attA.BackColor = Color.LightGray;

                    //Buff a livello grafico
                    if (nemico.DebuffApplicato)
                    {
                        attA.Text += nemico.DebuffVal;
                        defA.Text += nemico.DebuffVal;

                        attA.ForeColor = Color.BlueViolet;
                        defA.ForeColor = Color.BlueViolet;
                    }
                    else
                    {
                        attA.ForeColor = Color.Black;
                        defA.ForeColor = Color.Black;
                    }

                    int dmg = Scontro(cartaTua, cartaNemico, elem0, elemA, nemico, vita_avversario);

                    if (dmg >= 3)//aggiungi determinazione quando fai un buon danno
                    {
                        cartaTua.AddDeterminazione(2);

                        det0.Text = cartaTua.Determinazione.ToString();
                        det0.ForeColor = Color.GreenYellow;
                    }
                    else //comunque ogni turni perdi punti
                    {
                        cartaTua.DimDeterminazione(1); //perdi un punto
                        det0.Text = cartaTua.Determinazione.ToString(); //aggiorni la scritta
                    }

                }
                else
                {
                    CartaBase cartaNemico = (CartaBase)(nemico.CartaUsata);

                    cartaNemico.SetBuff(nemico.DebuffVal);
                    int dmg = Scontro(cartaNemico, cartaTua, elemA, elem0, player, vita_giocatore);
                    cartaNemico.SetBuff(0);

                    if (dmg >= 2)  //perdi determinazione quando subisci troppi danni
                    {
                        cartaTua.DimDeterminazione(2);

                        det0.Text = cartaTua.Determinazione.ToString();
                        det0.ForeColor = Color.Crimson;
                    }
                    else //comunque ogni turni perdi punti
                    {
                        cartaTua.DimDeterminazione(1); //perdi un punto
                        det0.Text = cartaTua.Determinazione.ToString(); //aggiorni la scritta
                    }

                }
                cartaTua.SetBuff(0); //finito il turno levo il buff
            }
            else
            {
                Carta cartaTua = player.CarteInMano[cartaSelezionata];
                if (tipo == "cura")
                {
                    ((CartaCura)cartaTua).UsaCarta(player);
                }
                else if (tipo == "curaEstesa")
                {
                    ((CartaCuraEstesa)cartaTua).UsaCarta(player);

                    curaEstesa.Show();
                }
                else if (tipo == "buff")
                {
                    ((CartaBuff)cartaTua).UsaCarta(player);

                    img_buff.Show();
                }
                else if (tipo == "debuff")
                {
                    ((CartaDebuff)cartaTua).UsaCarta(nemico); //applica l'effetto sul nemico

                    img_debuff.Show();
                }
                else if (tipo == "dannoContiuno")
                {
                    ((CartaDannoContinuo)cartaTua).UsaCarta(nemico); //applica l'effetto sul nemico

                    img_dannoPerpetuo.Show();
                }

                if (!tuoTurno)
                {
                    //Per ora la determinazione non conta
                    int dmg = ((CartaBase)(nemico.CartaUsata)).Atk;

                    if (dmg < 0)
                        dmg = 0;

                    player.LessHp(dmg);

                    //Output vita

                    vita_giocatore.Text = "HP: " + player.CurHp + "/" + player.MaxHp;
                    vita_giocatore.ForeColor = Color.Red;
                }

                //Ogni volta che usi una carta effetto perdi determinazione 

                cartaTua.DimDeterminazione(1); //perdi un punto
                det0.Text = cartaTua.Determinazione.ToString(); //aggiorni la scritta
            }

            //icone buff/debuff

            if (tuoTurno)
            {
                if (player.CuraEstesa)
                {
                    player.ApplicaBuffCura();
                    vita_giocatore.Text = "HP: " + player.CurHp + "/" + player.MaxHp;
                    vita_giocatore.ForeColor = Color.YellowGreen;
                    curaEstesa.Show();
                }

                if (player.BuffApplicato)
                {
                    player.ApplicaBuffStats();
                    img_buff.Show();
                }
            }
            else
            {
                if (nemico.DebuffApplicato)
                {
                    nemico.ApplicaDebuff();
                }

                if (nemico.DannoApplicato)
                {
                    nemico.ApplicaDannoPerpetuo();
                    vita_avversario.Text = "HP: " + nemico.CurHp + "/" + nemico.MaxHp;
                    vita_avversario.ForeColor = Color.Red;
                }
            }

            //Allo scadere dei turni toglie i flags di status
            if (!player.CuraEstesa)
            {
                curaEstesa.Hide();
            }

            if (!player.BuffApplicato)
            {
                img_buff.Hide();
            }

            if (!nemico.DebuffApplicato)
            {
                img_debuff.Hide();
            }

            if (!nemico.DannoApplicato)
            {
                img_dannoPerpetuo.Hide();
            }


            //controlla vita del nemico
            if (nemico.CurHp <= 0)
            {
                MessageBox.Show("Hai vinto lo scontro!");

                /*
                //Pesca una nuova carta per non rompere il sistema
                player.PescaCarta(cartaSelezionata);

                player.CarteInMano[cartaSelezionata]
                   .Visualizza(img_carta[cartaSelezionata], nomeCarta[cartaSelezionata], det[cartaSelezionata],
                   att[cartaSelezionata], def[cartaSelezionata], elem[cartaSelezionata]);*/

                nemico.GameOver();
            }
            else if (player.CurHp <= 0)
            {
                MessageBox.Show("Hai perso lo scontro.");

                /*
                //Pesca una nuova carta per non rompere il sistema
                player.PescaCarta(cartaSelezionata);

                player.CarteInMano[cartaSelezionata]
                   .Visualizza(img_carta[cartaSelezionata], nomeCarta[cartaSelezionata], det[cartaSelezionata],
                   att[cartaSelezionata], def[cartaSelezionata], elem[cartaSelezionata]);
                */

                player.GameOver();
            }

            //controlla determinazione
            if (player.CarteInMano[cartaSelezionata].Determinazione <= 0 &&
                player.CarteInMano[cartaSelezionata].Tipo != "morto") //ovviamente la carta non deve essere già morta
            {

                //nascondi la carta vecchia
                player.CarteInMano[cartaSelezionata].Nascondi(img_carta0, nomeCarta0, det0, att0, def0, elem0);

                //la carta viene rimpiazzata con la carta morto
                int indice = player.CarteInMano[cartaSelezionata].Indice; //salvo il vecchio indice
                player.CarteInMano[cartaSelezionata].SetUtilizzabile(false); //la carta verrà rimossa dal mazzo

                player.CarteInMano[cartaSelezionata] = ListaCarte.GetMorto();
                player.CarteInMano[cartaSelezionata].Indice = indice;

                player.Mazzo.MorteCarta(indice); //uccide la carta

                //mostra la carta nuova
                player.CarteInMano[cartaSelezionata].Visualizza(img_carta0, nomeCarta0, det0);

            }

        }

        private void bt_nascondi_Click(object sender, EventArgs e)
        {
            //rimetti carta in mano
            player.CarteInMano[cartaSelezionata]
                .Visualizza(img_carta[cartaSelezionata], nomeCarta[cartaSelezionata], det[cartaSelezionata],
                att[cartaSelezionata], def[cartaSelezionata], elem[cartaSelezionata]);

            //rimuovi dalla selezione
            player.CarteInMano[cartaSelezionata].Nascondi(img_carta0, nomeCarta0, det0, att0, def0, elem0);

            img_carta0.Show();
            img_carta0.Image = Properties.Resources.SpazioVuoto;


            bt_attacco.Hide();
            bt_nascondi.Hide();

            cartaSelezionata = -1;
        }

        private void bt_successivo_Click(object sender, EventArgs e)
        {
            bt_successivo.Hide();

            det0.ForeColor = Color.Black;

            //rimuovi dalla selezione
            player.CarteInMano[cartaSelezionata].Nascondi(img_carta0, nomeCarta0, det0, att0, def0, elem0);

            img_carta0.Show();
            img_carta0.Image = Properties.Resources.SpazioVuoto;

            //peschi una nuova carta
            player.PescaCarta(cartaSelezionata);

            player.CarteInMano[cartaSelezionata]
               .Visualizza(img_carta[cartaSelezionata], nomeCarta[cartaSelezionata], det[cartaSelezionata],
               att[cartaSelezionata], def[cartaSelezionata], elem[cartaSelezionata]);

            cartaSelezionata = -1;

            tuoTurno = !tuoTurno; //cambia turno

            //Entrambi tornano neri nel caso uno dei due fosse rosso
            vita_avversario.ForeColor = Color.Black;
            vita_giocatore.ForeColor = Color.Black;


            if (!tuoTurno)
            {
                //Il nemico sceglie una nuova carta con cui attaccare
                nemico.ScegliCarta();
                CartaBase cartaNemico = (CartaBase)(nemico.CartaUsata);

                cartaNemico.Visualizza(img_cartaA, nomeCartaA, detA, attA, defA, elemA);

                defA.BackColor = Color.LightGray;

                attA.BackColor = Color.LightBlue;
                elemA.BackColor = Color.LightBlue;

                detA.BackColor = Color.LightGoldenrodYellow;

                messaggioGiocatore.Hide();
                messaggioNemico.Show();


                //Buff a livello grafico
                if (nemico.DebuffApplicato)
                {
                    attA.Text += nemico.DebuffVal;
                    defA.Text += nemico.DebuffVal;

                    attA.ForeColor = Color.BlueViolet;
                    defA.ForeColor = Color.BlueViolet;
                }
                else
                {
                    attA.ForeColor = Color.Black;
                    defA.ForeColor = Color.Black;
                }


            }
            else
            {
                ((CartaBase)(nemico.CartaUsata)).Nascondi(img_cartaA, nomeCartaA, detA, attA, defA, elemA);

                img_cartaA.Show();
                img_cartaA.Image = Properties.Resources.SpazioVuoto;

                messaggioGiocatore.Show();
                messaggioNemico.Hide();

            }

        }

        private void audio_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                musicBox.Stop();
                audio.Image = Properties.Resources.play;
                isPlaying = false;
            }
            else
            {
                musicBox.PlayLooping();
                audio.Image = Properties.Resources.mute;
                isPlaying = true;
            }
        }

        private void ScontroCarte_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            Gioco.startMenu.Show();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                musicBox.PlayLooping(); //attiva musica al riavvio
            }
            else
            {
                musicBox.Stop(); //disattiva la musica alla chiusura
            }

            //TEMP
            musicBox.Stop();
        }
    }
}
