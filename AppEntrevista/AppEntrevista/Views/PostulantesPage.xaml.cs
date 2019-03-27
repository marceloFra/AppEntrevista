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
	public partial class PostulantesPage : ContentPage
	{
        private  string url = Servicio.IP + "api/Postulante";

        private HttpClient _Client = new HttpClient();
        private List<Postulante> requerimineto;

        public PostulantesPage ()
		{
			InitializeComponent ();
            ListaPostulante();

        }

        public async void ListaPostulante()
        {
            waitInidicator.IsRunning = true;
            try
            {
                var content = await _Client.GetStringAsync(url);
                var post = JsonConvert.DeserializeObject<List<Postulante>>(content);
                requerimineto = new List<Postulante>(post);
                Postulante_List.ItemsSource = requerimineto;
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
                // return;
            }
            waitInidicator.IsRunning = false;
        }

        private void Postulante_List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Postulante modelo = (Postulante)e.SelectedItem;
                //Navigation.PushAsync(new PostulantesPregPage(modelo)); 
                 Navigation.PushAsync(new RequerimientoPostPage(modelo));
            }
        }
    }
}