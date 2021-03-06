﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KingOfPirates.Missioni.ScontroCarte.Carte;

namespace KingOfPirates.Missioni.ScontroCarte.Opponenti
{
    public abstract class Giocatore_carte_base
    {
        private int maxHp;
        private int curHp;

        private string nome;
        private Bitmap img;

        public bool IsGameOver { get; set; }

        public Giocatore_carte_base(int maxHp_, Bitmap img_, string nome_)
        {
            maxHp = maxHp_;
            curHp = maxHp;

            img = img_;
            nome = nome_;

            IsGameOver = false;
        }

        public void GameOver()
        {
            IsGameOver = true;

            Gioco.scontroCarte.Hide();
            Gioco.MissioneSelezionata.Mappa.Show();
        }

        public void AddHp(int val)
        {
            curHp += val;
            if (curHp >= maxHp)
                curHp = maxHp;
        }

        public void LessHp(int val)
        {
            curHp -= val;
            if (curHp < 0)
                curHp = 0;
        }

        public int CurHp {get => curHp;}
        public int MaxHp { get => maxHp; }

        public string Nome { get => nome; }
        public Bitmap Img { get => img; }
    }
}
