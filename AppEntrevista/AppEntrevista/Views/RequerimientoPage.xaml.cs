using AppEntrevista.CS;
using AppEntrevista.Model;
using AppEntrevista.Views;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEntrevista
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RequerimientoPage : ContentPage
    {

        private   string url = Servicio.IP + "api/Requerimiento"; 
        private HttpClient _Client = new HttpClient();
        private List<Requerimiento> requerimineto;

        public RequerimientoPage()
        {
            InitializeComponent();
            ListaRequerimiento();
            Pregunta_List.ItemSelected += Pregunta_List_ItemSelected; 
        }
        
        public async void ListaRequerimiento()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<Requerimiento>>(content);
                requerimineto = new List<Requerimiento>(post);
                Pregunta_List.ItemsSource = requerimineto;
              //  base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar");
                waitInidicator.IsRunning = false;
                opacidad.IsVisible = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }


        private void Pregunta_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Requerimiento modelo = (Requerimiento)e.SelectedItem;
                Navigation.PushAsync(new PostulantesRequerPage(modelo));
            }
        }



























        /*
        protected override async void OnAppearing()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);  
                var post = JsonConvert.DeserializeObject<List<Requerimiento>>(content);
                requerimineto = new List<Requerimiento>(post);
                Pregunta_List.ItemsSource = requerimineto;
                base.OnAppearing();
                waitInidicator.IsRunning = false;
                waitInidicator.IsVisible = false;
                opacidad.IsVisible = false;
            }
            catch (Exception e)
            {
                e.ToString();
                await DisplayAlert("Error", "No hay conexion Intente mas Tarde", "Aceptar");
                waitInidicator.IsRunning = false;
                // return;
            }
            waitInidicator.IsRunning = false;
        }*/



    }


 
}
 