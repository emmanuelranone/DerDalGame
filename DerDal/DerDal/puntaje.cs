using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Controlador;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DerDal
{
    [Activity(Label = "puntaje")]
    public class puntaje : Activity
    {
        ListView listPuntaje;
        List<string> lista;
        Button btnVolver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_puntaje);
            // Create your application here

            btnVolver = FindViewById<Button>(Resource.Id.btnVolver);
            listPuntaje = FindViewById<ListView>(Resource.Id.listView1);
            
            btnVolver.Click += BtnVolver_Click;

            Controlador.Controlador controlador = new Controlador.Controlador();
            lista = new List<string>();                     
            lista = controlador.darPuntos();            

            listPuntaje.Adapter = new DataAdapter(this, lista);
           
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}