using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace IMC
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
            Button btnexecutar;
            Button btnlimpar;
            EditText txtpeso;
            EditText txtaltura;
            TextView result;
            double imc;
            string resultadoimc;
            CheckBox ckhomem;
            CheckBox ckmulher;

        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            btnexecutar = FindViewById<Button>(Resource.Id.btnexecutar);
            btnexecutar.Click += Btnexecutar_Click;

            btnlimpar = FindViewById<Button>(Resource.Id.btnlimpar);
            btnlimpar.Click += Btnlimpar_Click;

            txtaltura = FindViewById<EditText>(Resource.Id.txtaltura);
            txtpeso = FindViewById<EditText>(Resource.Id.txtpeso);
            result = FindViewById<TextView>(Resource.Id.result);
            ckhomem = FindViewById<CheckBox>(Resource.Id.ckhomem);
            ckmulher = FindViewById<CheckBox>(Resource.Id.ckmulher);
        }

        public double calIMC(double peso, double altura)
        {
            imc =  peso/(altura* altura);
            return imc;
        }

        public string tabelaIMC(double imc)
        {
            if(ckhomem.Checked == true)
            {
                if (imc < 20.7)
                {
                    resultadoimc = "Abaixo do peso";
                }
                else if (imc > 20.7 && imc < 26.4)
                {
                    resultadoimc = "Normal";
                }
                else if (imc > 26.4 && imc < 27.8)
                {
                    resultadoimc = "Marginalmente acima do peso";
                }
                else if (imc > 27.8 && imc < 31.1)
                {
                    resultadoimc = "Acima do peso ideal";
                }
                else if (imc > 31.1)
                {
                    resultadoimc = "Obesidade";
                }
            }
            else if(ckmulher.Checked == true)
            {
                if (imc < 19.1)
                {
                    resultadoimc = "Abaixo do peso";
                }
                else if (imc > 19.1 && imc < 25.8)
                {
                    resultadoimc = "Normal";
                }
                else if (imc > 25.8 && imc < 27.3)
                {
                    resultadoimc = "Marginalmente acima do peso";
                }
                else if (imc > 27.3 && imc < 32.3)
                {
                    resultadoimc = "Acima do peso ideal";
                }
                else if (imc > 32.3)
                {
                    resultadoimc = "Obesidade";
                }
            }
            
            return resultadoimc;
        }

        private void Btnlimpar_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();

            try
            {
                txtpeso.Text = "";
                txtaltura.Text = "";
                result.Text = "";
                ckmulher.Checked = false;
                ckhomem.Checked = false;
            }
            catch (Exception)
            {
                Toast.MakeText(ApplicationContext,"A ação não pôde ser concluída, tente novamente.", ToastLength.Short).Show();
            }
        }

        private void Btnexecutar_Click(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
            double peso = double.Parse(txtpeso.Text);
            double altura = double.Parse(txtaltura.Text);
            double valorimc = calIMC(peso, altura);

            result.Text = "Seu IMC é: " + Math.Round(valorimc, 2) + "\n" +
                "Seu diagnóstico é: " + tabelaIMC(valorimc);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}