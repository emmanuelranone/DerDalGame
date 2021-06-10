using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

namespace DerDal
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtNombre;
        Button btnPrueba, btnSalir, btnPosi;
        protected override void OnCreate(Bundle savedInstanceState)
        {            
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            
            txtNombre = FindViewById<EditText>(Resource.Id.txtNombre);
            btnPrueba = FindViewById<Button>(Resource.Id.btnJugar);
            btnPosi = FindViewById<Button>(Resource.Id.btnPosi);
            btnSalir = FindViewById<Button>(Resource.Id.btnSalir);

            btnPrueba.Click += BtnPrueba_Click;
            btnPosi.Click += BtnPosi_Click;
            btnSalir.Click += BtnSalir_Click;
            
            
        }
       
        protected override void OnRestart()
        {
            base.OnRestart();
            txtNombre.Text = "";
        }

        private void BtnSalir_Click(object sender, System.EventArgs e)
        {
            this.Finish();
        }

        private void BtnPosi_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(puntaje));            
            StartActivity(intent);

        }

        private void BtnPrueba_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(Jugar));
            string n = txtNombre.Text;
            if (txtNombre.Text != "")
            {
                intent.PutExtra(Jugar.Key, n);
                StartActivity(intent);                
            }
            else
            {
                var toast = Toast.MakeText(Application.Context, "Escribí tu Nombre", ToastLength.Short);
                toast.Show();
            }
           

        }

       
    }
}