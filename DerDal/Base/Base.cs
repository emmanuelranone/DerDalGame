using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;



namespace Base
{
    public class Base 
    {
       string folder, rutaDB;    
        public Base()
        {            
            creaBase();           
        }

        public void creaBase()
        {
            // CREO LA BASE Y LA TABLA SI NO EXISTEN
            folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            rutaDB = System.IO.Path.Combine(folder, "base.db");
            var db = new SQLiteConnection(rutaDB);
            db.CreateTable<Puntaje>();
        }

        public void guardarRegistro(Puntaje p)
        {
            creaBase();
            var db = new SQLiteConnection(rutaDB);
            db.Insert(p);
        }

        public List<Puntaje> obtenerPuntaje()
        {
            List<Puntaje> p = new List<Puntaje>();
            folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            rutaDB = System.IO.Path.Combine(folder, "base.db");
            var db = new SQLiteConnection(rutaDB);

            p = db.Table<Puntaje>().OrderByDescending(x => x.Puntos).ToList();
           // p = db.Table<Puntaje>().ToList();
            return p;
        }


    }
}