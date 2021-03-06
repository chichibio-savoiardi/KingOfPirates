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
using KingOfPirates.Nassau;
using KingOfPirates.Missioni.ScontroCarte.Carte;
using KingOfPirates.Missioni.ScontroCarte.Opponenti;
using KingOfPirates.Missioni;
using KingOfPirates.Missioni.Roba;
using KingOfPirates.Missioni.Navi.Nemici.Generici;
using KingOfPirates.Properties;

namespace KingOfPirates.GUI.MenuNassau
{
    public partial class Porto_form : Form
    {

        private Porto porto = new Porto();
        private Cartina cartina = new Cartina();

        int indiceMazzo;
        bool[] isSelected;
        int nCarteSelezionate;
        int nCarteMax;

        public Porto_form()
        {
            indiceMazzo = 0;
            isSelected = new bool[20];
            nCarteMax = 10 - 1;
            nCarteSelezionate = 0;

            InitializeComponent();

            LoadData();
        }

        private void Porto_Salpa_Button_Click(object sender, EventArgs e)
        {
            Porto_Missioni_Panel.Show();
        }

        private void Porto_UpCannoni_Button_Click(object sender, EventArgs e)
        {
            porto.PotenziaCannoni();
        }

        private void Porto_UpScafo_Button_Click(object sender, EventArgs e)
        {
            porto.PotenziaScafo();
        }

        private void Porto_UpVela_Button_Click(object sender, EventArgs e)
        {
            porto.PotenziaVele();
        }

        private void LoadData() {
            Porto_CanPrezzo_Label.Text = (porto.PrezzoCannoni[porto.LivelloCannoni]).ToString() + " $";
            Porto_ScaPrezzo_Label.Text = (porto.PrezzoScafo[porto.LivelloScafo]).ToString() + " $";
            Porto_VelPrezzo_Label.Text = (porto.PrezzoVele[porto.LivelloVele]).ToString() + " $";
        }

        private void Porto_Back_Button_Click(object sender, EventArgs e)
        {
            this.Hide();
            Gioco.nassauForm.Show();
        }

        private void Porto_MissioniBack_Button_Click(object sender, EventArgs e)
        {
            Porto_Missioni_Panel.Hide();
        }


        //Selezione missione

        private void Porto_Salpa2_Button_Click(object sender, EventArgs e)
        {
            Porto_SelezioneCarte_Panel.Show();
            LoadSelezioneCarte();
        }

        private void Porto_Missione1_Button_Click(object sender, EventArgs e)
        {
            cartina.CurrentMissionIndex = 0;


            Porto_Missione1_Button.ForeColor = Color.Black;
            Porto_Missione2_Button.ForeColor = Color.Black;
            Porto_Missione3_Button.ForeColor = Color.Black;

            Porto_Missione1_Button.ForeColor = Color.Green;

            //mostra bottone salpa
            Porto_Salpa2_Button.Visible = true;
        }

        private void Porto_Missione2_Button_Click(object sender, EventArgs e)
        {
            cartina.CurrentMissionIndex = 1;


            Porto_Missione1_Button.ForeColor = Color.Black;
            Porto_Missione2_Button.ForeColor = Color.Black;
            Porto_Missione3_Button.ForeColor = Color.Black;

            Porto_Missione2_Button.ForeColor = Color.Green;


            //mostra bottone salpa
            Porto_Salpa2_Button.Visible = true;
        }

        private void Porto_Missione3_Button_Click(object sender, EventArgs e)
        {
            cartina.CurrentMissionIndex = 2;

            Porto_Missione1_Button.ForeColor = Color.Black;
            Porto_Missione2_Button.ForeColor = Color.Black;
            Porto_Missione3_Button.ForeColor = Color.Black;

            Porto_Missione3_Button.ForeColor = Color.Green;

            //mostra bottone salpa
            Porto_Salpa2_Button.Visible = true;
        }


        //Selezione carte mazzo

        private Carta[] mazzoFiller()
        {
            int count = 0, indiceSelezionato = - 1;

            for(int i = 0; i < 20; i++)
            {
                if (isSelected[i])
                    count ++;
            }

            Carta[] mazzo = new Carta[count];

            for(int i = 0; i < count; i++)
            {
                indiceSelezionato = getIsSelectedIndex(indiceSelezionato);
                //mazzo[i] = ListaCarte.GetCartaClone(indiceSelezionato);
                mazzo[i] = ListaCarte.GetCarta(indiceSelezionato);
            }

            return mazzo;
        }

        private int getIsSelectedIndex(int indiceSelezionato)
        {
            for(int j = indiceSelezionato + 1; j < 20; j++)
            {
                if(isSelected[j])
                    return j;
            }
            return - 1;
        }

        private void Porto_SelCarBack_Button_Click(object sender, EventArgs e)
        {
            Porto_SelezioneCarte_Panel.Hide();
        }


        private void Porto_Salpa3_Button_Click(object sender, EventArgs e)
        {
            if(nCarteSelezionate >= 5 && nCarteSelezionate <= nCarteMax + 1)
            {
                Carta[] mazzo = mazzoFiller();
                //TODO avvio missione

                //Passo il mazzo al giocatore
                Gioco.Giocatore.GiocatoreCarte.Mazzo = new Mazzo(mazzo);
                Gioco.Giocatore.GiocatoreCarte.Init();

                int index = cartina.CurrentMissionIndex;

                Gioco.MissioneSelezionata = ListaMissioni.GetMissione(index);

                //fa partire la missione selezionata
                Gioco.MissioneSelezionata.StartMissione();
                this.Hide();
            }
        }

        private void UpdateSelezioneCarte()
        {
            Porto_SelCarNum_Label.Text = nCarteSelezionate.ToString() + " / " + (nCarteMax + 1).ToString();
        }

        private void Locanda_Carta1_Panel_Click(object sender, EventArgs e)
        {
            if(isSelected[0] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[0] = true;
                Porto_Selected1_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate ++;
            }
            else if(isSelected[0])
            {
                isSelected[0] = false;
                Porto_Selected1_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate --;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta2_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[1] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[1] = true;
                Porto_Selected2_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[1])
            {
                isSelected[1] = false;
                Porto_Selected2_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta3_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[2] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[2] = true;
                Porto_Selected3_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[2])
            {
                isSelected[2] = false;
                Porto_Selected3_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta4_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[3] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[3] = true;
                Porto_Selected4_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[3])
            {
                isSelected[3] = false;
                Porto_Selected4_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta5_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[4] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[4] = true;
                Porto_Selected5_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[4])
            {
                isSelected[4] = false;
                Porto_Selected5_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta6_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[5] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[5] = true;
                Porto_Selected6_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[5])
            {
                isSelected[5] = false;
                Porto_Selected6_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta7_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[6] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[6] = true;
                Porto_Selected7_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[6])
            {
                isSelected[6] = false;
                Porto_Selected7_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta8_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[7] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[7] = true;
                Porto_Selected8_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[7])
            {
                isSelected[7] = false;
                Porto_Selected8_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta9_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[8] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[8] = true;
                Porto_Selected9_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[8])
            {
                isSelected[8] = false;
                Porto_Selected9_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta10_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[9] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[9] = true;
                Porto_Selected10_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[9])
            {
                isSelected[9] = false;
                Porto_Selected10_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta11_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[10] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[10] = true;
                Porto_Selected11_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[10])
            {
                isSelected[10] = false;
                Porto_Selected11_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta12_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[11] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[11] = true;
                Porto_Selected12_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[11])
            {
                isSelected[11] = false;
                Porto_Selected12_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta13_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[12] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[12] = true;
                Porto_Selected13_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[12])
            {
                isSelected[12] = false;
                Porto_Selected13_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta14_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[13] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[13] = true;
                Porto_Selected14_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[13])
            {
                isSelected[13] = false;
                Porto_Selected14_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta15_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[14] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[14] = true;
                Porto_Selected15_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[14])
            {
                isSelected[14] = false;
                Porto_Selected15_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta16_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[15] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[15] = true;
                Porto_Selected16_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[15])
            {
                isSelected[15] = false;
                Porto_Selected16_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta17_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[16] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[16] = true;
                Porto_Selected17_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[16])
            {
                isSelected[16] = false;
                Porto_Selected17_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta18_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[17] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[17] = true;
                Porto_Selected18_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[17])
            {
                isSelected[17] = false;
                Porto_Selected18_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta19_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[18] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[18] = true;
                Porto_Selected19_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[18])
            {
                isSelected[18] = false;
                Porto_Selected19_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        private void Locanda_Carta20_Panel_Click(object sender, EventArgs e)
        {
            if (isSelected[19] == false && nCarteSelezionate <= nCarteMax)
            {
                isSelected[19] = true;
                Porto_Selected20_PB.BackgroundImage = Properties.Resources._checked;
                nCarteSelezionate++;
            }
            else if (isSelected[19])
            {
                isSelected[19] = false;
                Porto_Selected20_PB.BackgroundImage = Properties.Resources._unchecked;
                nCarteSelezionate--;
            }
            UpdateSelezioneCarte();
        }

        

        private void LoadSelezioneCarte()
        {
            Porto_SelCarNum_Label.Text = nCarteSelezionate.ToString() + " / " + (nCarteMax + 1).ToString();

            if (!ListaCarte.GetCarta(0).GetUtilizzabile()){
                Locanda_Carta1_Panel.Hide();
            }
            else
            {
                Locanda_Carta1_Panel.BackgroundImage = ListaCarte.GetCarta(0).Immagine;
                Locanda_Carta1_Panel.Show();
            }

            if (!ListaCarte.GetCarta(1).GetUtilizzabile())
            {
                Locanda_Carta2_Panel.Hide();
            }
            else
            {
                Locanda_Carta2_Panel.BackgroundImage = ListaCarte.GetCarta(1).Immagine;
                Locanda_Carta2_Panel.Show();
            }

            if (!ListaCarte.GetCarta(2).GetUtilizzabile())
            {
                Locanda_Carta3_Panel.Hide();
            }
            else
            {
                Locanda_Carta3_Panel.BackgroundImage = ListaCarte.GetCarta(2).Immagine;
                Locanda_Carta3_Panel.Show();
            }

            if (!ListaCarte.GetCarta(3).GetUtilizzabile())
            {
                Locanda_Carta4_Panel.Hide();
            }
            else
            {
                Locanda_Carta4_Panel.BackgroundImage = ListaCarte.GetCarta(3).Immagine;
                Locanda_Carta4_Panel.Show();
            }

            if (!ListaCarte.GetCarta(4).GetUtilizzabile())
            {
                Locanda_Carta5_Panel.Hide();
            }
            else
            {
                Locanda_Carta5_Panel.BackgroundImage = ListaCarte.GetCarta(4).Immagine;
                Locanda_Carta5_Panel.Show();
            }

            if (!ListaCarte.GetCarta(5).GetUtilizzabile())
            {
                Locanda_Carta6_Panel.Hide();
            }
            else
            {
                Locanda_Carta6_Panel.BackgroundImage = ListaCarte.GetCarta(5).Immagine;
                Locanda_Carta6_Panel.Show();
            }

            if (!ListaCarte.GetCarta(6).GetUtilizzabile())
            {
                Locanda_Carta7_Panel.Hide();
            }
            else
            {
                Locanda_Carta7_Panel.BackgroundImage = ListaCarte.GetCarta(6).Immagine;
                Locanda_Carta7_Panel.Show();
            }

            if (!ListaCarte.GetCarta(7).GetUtilizzabile())
            {
                Locanda_Carta8_Panel.Hide();
            }
            else
            {
                Locanda_Carta8_Panel.BackgroundImage = ListaCarte.GetCarta(7).Immagine;
                Locanda_Carta8_Panel.Show();
            }

            if (!ListaCarte.GetCarta(8).GetUtilizzabile())
            {
                Locanda_Carta9_Panel.Hide();
            }
            else
            {
                Locanda_Carta9_Panel.BackgroundImage = ListaCarte.GetCarta(8).Immagine;
                Locanda_Carta9_Panel.Show();
            }

            if (!ListaCarte.GetCarta(9).GetUtilizzabile())
            {
                Locanda_Carta10_Panel.Hide();
            }
            else
            {
                Locanda_Carta10_Panel.BackgroundImage = ListaCarte.GetCarta(9).Immagine;
                Locanda_Carta10_Panel.Show();
            }

            if (!ListaCarte.GetCarta(10).GetUtilizzabile())
            {
                Locanda_Carta11_Panel.Hide();
            }
            else
            {
                Locanda_Carta11_Panel.BackgroundImage = ListaCarte.GetCarta(10).Immagine;
                Locanda_Carta11_Panel.Show();
            }

            if (!ListaCarte.GetCarta(11).GetUtilizzabile())
            {
                Locanda_Carta12_Panel.Hide();
            }
            else
            {
                Locanda_Carta12_Panel.BackgroundImage = ListaCarte.GetCarta(11).Immagine;
                Locanda_Carta12_Panel.Show();
            }

            if (!ListaCarte.GetCarta(12).GetUtilizzabile())
            {
                Locanda_Carta13_Panel.Hide();
            }
            else
            {
                Locanda_Carta13_Panel.BackgroundImage = ListaCarte.GetCarta(12).Immagine;
                Locanda_Carta13_Panel.Show();
            }

            if (!ListaCarte.GetCarta(13).GetUtilizzabile())
            {
                Locanda_Carta14_Panel.Hide();
            }
            else
            {
                Locanda_Carta14_Panel.BackgroundImage = ListaCarte.GetCarta(13).Immagine;
                Locanda_Carta14_Panel.Show();
            }

            if (!ListaCarte.GetCarta(14).GetUtilizzabile())
            {
                Locanda_Carta15_Panel.Hide();
            }
            else
            {
                Locanda_Carta15_Panel.BackgroundImage = ListaCarte.GetCarta(14).Immagine;
                Locanda_Carta15_Panel.Show();
            }

            if (!ListaCarte.GetCarta(15).GetUtilizzabile())
            {
                Locanda_Carta16_Panel.Hide();
            }
            else
            {
                Locanda_Carta16_Panel.BackgroundImage = ListaCarte.GetCarta(15).Immagine;
                Locanda_Carta16_Panel.Show();
            }

            if (!ListaCarte.GetCarta(16).GetUtilizzabile())
            {
                Locanda_Carta17_Panel.Hide();
            }
            else
            {
                Locanda_Carta17_Panel.BackgroundImage = ListaCarte.GetCarta(16).Immagine;
                Locanda_Carta17_Panel.Show();
            }

            if (!ListaCarte.GetCarta(17).GetUtilizzabile())
            {
                Locanda_Carta18_Panel.Hide();
            }
            else
            {
                Locanda_Carta18_Panel.BackgroundImage = ListaCarte.GetCarta(17).Immagine;
                Locanda_Carta18_Panel.Show();
            }

            if (!ListaCarte.GetCarta(18).GetUtilizzabile())
            {
                Locanda_Carta19_Panel.Hide();
            }
            else
            {
                Locanda_Carta19_Panel.BackgroundImage = ListaCarte.GetCarta(18).Immagine;
                Locanda_Carta19_Panel.Show();
            }

            if (!ListaCarte.GetCarta(19).GetUtilizzabile())
            {
                Locanda_Carta20_Panel.Hide();
            }
            else
            {
                Locanda_Carta20_Panel.BackgroundImage = ListaCarte.GetCarta(19).Immagine;
                Locanda_Carta20_Panel.Show();
            }

        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
               Porto_Missioni_Panel.Hide();
               Porto_SelezioneCarte_Panel.Hide();

               //deseleziona tutto
               for(int i = 0; i < isSelected.Length; i++)
                    isSelected[i] = false;

               nCarteSelezionate = 0;

               Porto_Selected1_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected2_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected3_PB.BackgroundImage = Resources.emptyCheckBox;

               Porto_Selected4_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected5_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected6_PB.BackgroundImage = Resources.emptyCheckBox;
               
               Porto_Selected7_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected8_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected9_PB.BackgroundImage = Resources.emptyCheckBox;
               
               Porto_Selected10_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected11_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected12_PB.BackgroundImage = Resources.emptyCheckBox;
               
               Porto_Selected13_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected14_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected15_PB.BackgroundImage = Resources.emptyCheckBox;
               
               Porto_Selected16_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected17_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected18_PB.BackgroundImage = Resources.emptyCheckBox;
               
               Porto_Selected19_PB.BackgroundImage = Resources.emptyCheckBox;
               Porto_Selected20_PB.BackgroundImage = Resources.emptyCheckBox;
            }
        }
    }
}
