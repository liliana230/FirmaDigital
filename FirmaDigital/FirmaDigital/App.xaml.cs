using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.IO;
using FirmaDigital.Controller;
namespace FirmaDigital
{
    public partial class App : Application
    {
        static BaseDatos Datos;

        public static BaseDatos BaseDatos
        {
            get
            {
                if (Datos == null)
                {
                    Datos = new BaseDatos(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BaseDatos.db3"));
                }

                return Datos;
            }


        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage ( new MainPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
