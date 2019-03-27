using AppEntrevista.CS;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEntrevista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreguntasPage : ContentPage
	{
        private   string url = Servicio.IP + "api/ListaPregunta";
        private HttpClient _Client = new HttpClient();
        private List<ListPreguntaCab> preguntas;

        public PreguntasPage ()
		{
			InitializeComponent ();
            ListaPreguntas();
            Preguntas_List.ItemSelected += Preguntas_List_ItemSelected;
        }


        public async void ListaPreguntas()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<ListPreguntaCab>>(content);
                preguntas = new List<ListPreguntaCab>(post);
                Preguntas_List.ItemsSource = preguntas;
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

        private void Preguntas_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            { 
                ListPreguntaCab modelo = (ListPreguntaCab)e.SelectedItem;
                Navigation.PushAsync(new ListaPreguntasPage(modelo));
            }
        }




    }
}