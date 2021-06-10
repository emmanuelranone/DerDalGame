using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Base;

namespace Controlador
{
    public class ObjetoRelacional
    {
        public List<string> PuntajeRelacional(List<Puntaje> p)
        {
            List<string> puntos = new List<string>();
            int i = 1;

            foreach( Puntaje pun in p)
            {
                puntos.Add(i.ToString() + "º -- " + pun.Nom + " -- " + pun.Puntos);
                i++;
            }

            return puntos;
        }

        public Puntaje puntajeObjeto(string n,string p)
        {
            Puntaje punt = new Puntaje();
            punt.Nom = n;
            punt.Puntos = p;

            return punt;
        }
    }
}