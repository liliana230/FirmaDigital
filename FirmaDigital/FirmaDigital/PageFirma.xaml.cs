using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignaturePad.Forms;
using FirmaDigital.Models;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;
using FirmaDigital.Controller;

namespace FirmaDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageFirma : ContentPage
    {
        string valueBase64;
        public PageFirma()
        {
            InitializeComponent();
        }

        private async void guardar_Clicked(object sender, EventArgs e)
        {
            Stream image = await vista.GetImageStreamAsync(SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(nombre.Text) || String.IsNullOrWhiteSpace(descrip.Text))
            {
               // await DisplayAlert("ERROR", "SE DEBEN DE LLENAR LOS DATOS DE NOMBRE Y DESCRIPCION PARA GUARDAR", "ACEPTAR");
            }

            var firmaG = new Firma
            {
                codimagen = valueBase64,
                nombre = nombre.Text,
                descripcion = descrip.Text
            };

            var result = await App.BaseDatos.GuardarFirma(firmaG);

            if (result != 1)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR, INTENTE DE NUEVO", "ACEPTAR");
            }

            await DisplayAlert("AVISO", "GUARDADO CON EXITO", "ACEPTAR");
        }

        private async void lista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFirmas());
        }

        private void borrar_Clicked(object sender, EventArgs e)
        {
            vista.Clear();
        }
    }
}