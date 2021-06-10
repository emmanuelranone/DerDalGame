using System;
using System.Collections.Generic;
using Controlador;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using IO.Github.Krtkush.Lineartimer;
using System.Timers;

namespace DerDal
{
    [Activity(Label = "Jugar")]
    public class Jugar : Activity
    {
        internal static string Key = "key";
        List<Pregunta> preguntas;
        List<int> rep;
        Button btn1, btn2, btn3, btn4, btnSiguiente;
        TextView txtPregunta, txtCategoria;
        string correcta, nombre;
        int correctas, count;
        bool empezo, salir;
        Random rnd;
        Controlador.Controlador c;
        LinearTimer lTimer;
        LinearTimerView ltView;
        Timer timer;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.activity_jugar);

            c = new Controlador.Controlador();
            preguntas = new List<Pregunta>();
            preguntas = c.getPreguntas();

            // var nombre = Intent.Extras.GetString("key");
            nombre = Intent.GetStringExtra("key");

            ltView = FindViewById<LinearTimerView>(Resource.Id.timer1);
            lTimer = new LinearTimer(ltView);

            count = 1;
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;


            txtPregunta = FindViewById<TextView>(Resource.Id.txtPregunta);
            txtCategoria = FindViewById<TextView>(Resource.Id.txtCategoria);
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn2 = FindViewById<Button>(Resource.Id.btn2);
            btn3 = FindViewById<Button>(Resource.Id.btn3);
            btn4 = FindViewById<Button>(Resource.Id.btn4);
            btnSiguiente = FindViewById<Button>(Resource.Id.btnSiguiente);

            btn1.Click += Btn1_Click;
            btn2.Click += Btn2_Click;
            btn3.Click += Btn3_Click;
            btn4.Click += Btn4_Click;
            btnSiguiente.Click += BtnSiguiente_Click;

            // creaPreguntas();
            rep = new List<int>();
            correctas = 0;
            empezo = salir = false;

            btnSiguiente.Text = "COMENZAR";
            btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
            txtCategoria.Visibility = Android.Views.ViewStates.Invisible;
            txtPregunta.Visibility = Android.Views.ViewStates.Invisible;
            btn1.Visibility = btn2.Visibility = btn3.Visibility = btn4.Visibility = Android.Views.ViewStates.Invisible;

            rnd = new Random(Convert.ToInt32(DateTime.Now.Millisecond));


        }

        protected override void OnPause()
        {
            base.OnPause();
            timer.Stop();
        }

        public void guardarEnBase()
        {
            c.guardarPuntaje(nombre, correctas.ToString());
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            if (salir)
            {
                if (correctas > 0)
                    guardarEnBase();

                this.Finish();
            }

            if (!empezo && !salir)
            {
                txtCategoria.Visibility = Android.Views.ViewStates.Visible;
                txtPregunta.Visibility = Android.Views.ViewStates.Visible;
                btn1.Visibility = btn2.Visibility = btn3.Visibility = btn4.Visibility = Android.Views.ViewStates.Visible;
                asociaPregunta();
                btnSiguiente.Text = "Próxima Pregunta";

                empezo = true;
                lTimer.StartTimer(360, 100 * 100);

                timer.Start();

                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = true;
                btnSiguiente.Enabled = false;
            }
            else if (!salir)
            {
                asociaPregunta();
                btn1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn2.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn3.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn4.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = true;
                lTimer.RestartTimer();
                timer.Start();

            }

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (count < 10)
            {
                count++;               
            }
            else
            {
                RunOnUiThread(() =>
                {
                    timer.Stop();
                    var toast = Toast.MakeText(Application.Context, "Perdiste", ToastLength.Short);
                    toast.Show();
                    btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                    btnSiguiente.Enabled = true;
                    btnSiguiente.Text = "SALIR";
                    salir = true;
                });

            }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            if (btn4.Text.Equals(correcta))
            {
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "Próxima Pregunta";
                correctas++;                

                btn4.SetBackgroundColor(Android.Graphics.Color.Green);
                //  btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;

            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Perdiste", ToastLength.Short);
                toast.Show();
                btn4.SetBackgroundColor(Android.Graphics.Color.Red);
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "SALIR";
                salir = true;
            }
            paraReloj();
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            if (btn3.Text.Equals(correcta))
            {
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "Próxima Pregunta";
                correctas++;
                                
                btn3.SetBackgroundColor(Android.Graphics.Color.Green);
                // btn3.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Perdiste", ToastLength.Short);
                toast.Show();
                btn3.SetBackgroundColor(Android.Graphics.Color.Red);
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "SALIR";
                salir = true;
            }
            paraReloj();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (btn2.Text.Equals(correcta))
            {
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "Próxima Pregunta";
                correctas++;                             

                btn2.SetBackgroundColor(Android.Graphics.Color.Green);
                //btn2.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Perdiste", ToastLength.Short);
                toast.Show();
                btn2.SetBackgroundColor(Android.Graphics.Color.Red);
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "SALIR";
                salir = true;
            }
            paraReloj();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            if (btn1.Text.Equals(correcta))
            {
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "Próxima Pregunta";
                correctas++;
                                
                btn1.SetBackgroundColor(Android.Graphics.Color.Green);//#ff95edf0
                // btn1.SetBackgroundColor(Android.Graphics.Color.ParseColor("#ff95fdff"));
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Perdiste", ToastLength.Short);
                toast.Show();
                btn1.SetBackgroundColor(Android.Graphics.Color.Red);
                btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;
                btnSiguiente.Enabled = true;
                btnSiguiente.Text = "SALIR";
                salir = true;
            }
            paraReloj();
        }

        private void asociaPregunta()
        {
            bool agrega = true;
            //  Random rnd = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            int nro;
            btnSiguiente.Enabled = false;

            if (rep.Count < preguntas.Count) // cantidad de numeros generados no puede ser mayor o igual que preguntas existentes
            {
                do
                {
                    agrega = true;
                    nro = rnd.Next(preguntas.Count);
                    for (int i = 0; i < rep.Count; i++) // recorro para evitar repetidos
                    {
                        if (nro == Convert.ToInt32(rep[i]))
                        {
                            agrega = false;
                        }
                    }
                } while (!agrega);

                rep.Add(nro);
               // botonRep = new List<int>();
                c.BotonRep();

                //tenemos numero de pregunta no repetida.
                txtCategoria.Text = preguntas[nro].Categoria;
                txtPregunta.Text = preguntas[nro].Preg;

                #region ASIGNA BOTONES
                // BOTON 1
                int b = c.dameNroBoton();
                switch (b)
                {
                    case 1:
                        btn1.Text = preguntas[nro].Opc1;
                        break;
                    case 2:
                        btn1.Text = preguntas[nro].Opc2;
                        break;
                    case 3:
                        btn1.Text = preguntas[nro].Opc3;
                        break;
                    case 4:
                        btn1.Text = preguntas[nro].Opc4;
                        break;
                }
                //BOTON 2
                b = c.dameNroBoton();
                switch (b)
                {
                    case 1:
                        btn2.Text = preguntas[nro].Opc1;
                        break;
                    case 2:
                        btn2.Text = preguntas[nro].Opc2;
                        break;
                    case 3:
                        btn2.Text = preguntas[nro].Opc3;
                        break;
                    case 4:
                        btn2.Text = preguntas[nro].Opc4;
                        break;
                }
                //BOTON 3
                b = c.dameNroBoton();
                switch (b)
                {
                    case 1:
                        btn3.Text = preguntas[nro].Opc1;
                        break;
                    case 2:
                        btn3.Text = preguntas[nro].Opc2;
                        break;
                    case 3:
                        btn3.Text = preguntas[nro].Opc3;
                        break;
                    case 4:
                        btn3.Text = preguntas[nro].Opc4;
                        break;
                }
                //BOTON 4
                b = c.dameNroBoton();
                switch (b)
                {
                    case 1:
                        btn4.Text = preguntas[nro].Opc1;
                        break;
                    case 2:
                        btn4.Text = preguntas[nro].Opc2;
                        break;
                    case 3:
                        btn4.Text = preguntas[nro].Opc3;
                        break;
                    case 4:
                        btn4.Text = preguntas[nro].Opc4;
                        break;
                }
                #endregion

                correcta = preguntas[nro].Opc1;

            }
            else
            {
                // guardar usuario en base
                var toast = Toast.MakeText(Application.Context, "CAMPEÓN", ToastLength.Short);
                toast.Show();
                this.Finish();
            }

        }  

        public void paraReloj()
        {
            timer.Stop();
            count = 1;
            lTimer.ResetTimer();
        }
        
        
        

    }
}