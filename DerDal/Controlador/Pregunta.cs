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

namespace Controlador
{
    public class Pregunta
    {
        string preg, opc1, opc2, opc3, opc4;
        string categoria;

        public string Preg { get => preg; set => preg = value; }
        public string Opc1 { get => opc1; set => opc1 = value; }
        public string Opc2 { get => opc2; set => opc2 = value; }
        public string Opc3 { get => opc3; set => opc3 = value; }
        public string Opc4 { get => opc4; set => opc4 = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}