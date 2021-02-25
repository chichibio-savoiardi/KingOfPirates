﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingOfPirates.Missioni.Roba
{
    /// <summary>
    /// Contenitore di variabili per le navi
    /// </summary>
    public class Stats
    {
        public int Hp { get; set; } // Punti Vita (Health Points)
        public int HpMax { get; set; }
        public int Pa { get; set; } // Punti Azione
        public int PaMax { get; set; }
        public int MaxHit { get; set; } // Danno minimo
        public int MinHit { get; set; } // Danno massimo

        /// <summary>
        /// Inizializza le Stats per navi con tutti parametri
        /// </summary>
        /// <param name="hp"></param>
        /// <param name="hpMax"></param>
        /// <param name="pa"></param>
        /// <param name="paMax"></param>
        /// <param name="minHit"></param>
        /// <param name="maxHit"></param>

        public Stats(int hp,int hpMax , int pa, int paMax, int minHit, int maxHit)
        {
            Hp = hp;
            HpMax = hpMax;
            Pa = pa;
            PaMax = paMax;
            MinHit = minHit;
            MaxHit = maxHit;
        }

        /// <summary>
        /// Inizializza le Stats per navi con nessun parametro
        /// </summary>

        public Stats()
        {
            Hp = 10;
            HpMax = 20;
            Pa = 10;
            PaMax = 10;
            MinHit = 1;
            MaxHit = 5;
        }
    }
}
