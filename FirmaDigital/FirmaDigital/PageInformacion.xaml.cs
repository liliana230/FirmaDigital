using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FirmaDigital.Models;

namespace FirmaDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInformacion : ContentPage
    {
        public PageInformacion(Firma Firma)
        {
            InitializeComponent();
            nombre.Text = Firma.nombre;
            descripcion.Text = Firma.descripcion;
            imagefirma.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Firma.codimagen)));
        }
    }
}