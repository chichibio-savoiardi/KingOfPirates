﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using KingOfPirates.Missioni.ScontroCarte.Carte;

namespace KingOfPirates.Missioni.ScontroCarte.Opponenti
{
    abstract class ListaCarte
    {
        private static Carta[] cartaProva = { new CartaBase("PunPun1", 4, Properties.Resources.pun_pun, 5, 6, 'f'),
                               new CartaBase("PunPun2", 4, Properties.Resources.pun_pun1, 7, 2, 'g'),
                               new CartaBase("PunPun3", 4, Properties.Resources.pun_pun2, 2, 2, 's')};

       public static Carta GetCarta(int indice)
       {
            return cartaProva[indice];
       }
    }
}
