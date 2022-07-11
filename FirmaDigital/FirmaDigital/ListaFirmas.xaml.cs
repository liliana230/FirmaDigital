using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FirmaDigital.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirmaDigital
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFirmas : ContentPage
    {
        public ListaFirmas()
        {
            InitializeComponent();
        }

        private async void lista_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Firma)e.SelectedItem;

            var FirmA = await App.BaseDatos.GetCodFirma(itemSelected.cod);

           var PageInformacion = new PageInformacion(FirmA);

           await Navigation.PushAsync(PageInformacion);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCollectionView();

        }

        private async void LoadCollectionView()
        {
            lista.ItemsSource = await App.BaseDatos.GetListFirma();
        }

    }
}